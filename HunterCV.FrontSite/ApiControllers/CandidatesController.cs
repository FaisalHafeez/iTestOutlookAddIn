using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using System.IO;
using System.Web;
using HunterCV.Model;
using System.Data;
using System.Xml.Linq;

namespace HunterCV.FrontSite.ApiControllers
{
    [Authorize]
    public class CandidatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public HunterCV.Common.PostCandidateApiResponse Post(HunterCV.Common.Candidate candidate)
        {
            string userName = Membership.GetUser().UserName;

            var response = new HunterCV.Common.PostCandidateApiResponse();

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);
                var role = context.Users.Single(u => u.UserName == userName)
                    .Roles.Single();

                if (role.LicenseType == "Free")
                {
                    int count = context.Candidates.Where(c => c.UserId == user.UserId ).Count();

                    if (count >= 10)
                    {
                        throw new HttpResponseException(
                            new HttpResponseMessage
                            {
                                StatusCode = HttpStatusCode.Forbidden,
                                Content = new StringContent("License"),
                                ReasonPhrase = "This license type does not allow the operation"
                            });

                    }
                }

                if (!candidate.SkipDuplicatesCheck)
                {
                    //check duplicates
                    IEnumerable<Candidate> candidates = context.Candidates.Where(c => c.FirstName.ToLower().Trim() == candidate.FirstName.ToLower().Trim()
                        && c.LastName.ToLower().Trim() == candidate.LastName.ToLower().Trim());

                    if (candidates.Any())
                    {
                        response.Duplicates = candidates.Select(p => Mapper.Map<Candidate, HunterCV.Common.Candidate>(p)).ToList();
                        return response;
                    }
                }

                int startIndex = 1000;

                //get start index
                var docSettings = XDocument.Parse(role.Settings);
                var elementsSettings = docSettings.Root.Elements();
                XElement startIndexElement =
                        (from el in docSettings.Root.Elements("setting")
                         where (string)el.Attribute("title") == "CandidatesStartIndex"
                         select el).FirstOrDefault();

                if (startIndexElement != null)
                {
                    startIndex = (int)startIndexElement.Attribute("value");
                }

                if (context.Candidates.Any())
                {
                    startIndex = context.Candidates.Max(c => c.CandidateNumber).Value + 1;
                }

                candidate.CandidateNumber = startIndex;
                response.NewCandidate = candidate;

                Candidate target = Mapper.Map<HunterCV.Common.Candidate, Candidate>(candidate);
                target.User = user;
                context.Candidates.AddObject(target);

                //check favorite
                //if (candidate.IsFavorite)
                //{
                //    target.FavoriteUsers.Add(user);
                //}

                context.SaveChanges();

                return response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Delete(string id)
        {
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var candidate = context.Candidates.Where(c => c.CandidateID == new Guid(id)).FirstOrDefault();

                context.Candidates.DeleteObject(candidate);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public IEnumerable<HunterCV.Common.Candidate> Put(HunterCV.Common.Candidate candidate)
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var curruser = context.Users.Single(user => user.UserName == userName);

                if (!candidate.SkipDuplicatesCheck)
                {
                    //check duplicates
                    IEnumerable<Candidate> candidates = context.Candidates.Where(c => c.FirstName.ToLower().Trim() == candidate.FirstName.ToLower().Trim()
                        && c.LastName.ToLower().Trim() == candidate.LastName.ToLower().Trim() && c.CandidateID != candidate.CandidateID );

                    if (candidates.Any())
                    {
                        return candidates.Select(p => Mapper.Map<Candidate, HunterCV.Common.Candidate>(p)).ToList();
                    }
                }

                var entity = Mapper.Map<HunterCV.Common.Candidate, Candidate>(candidate);

                //delete old positions
                context.CandidatePositions.Where(c => c.CandidateId == candidate.CandidateID).Each( d =>
                    {
                        context.CandidatePositions.DeleteObject( d);
                    });

                entity.UserId = curruser.UserId;

                context.Candidates.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

                foreach (HunterCV.Common.CandidatePosition position in candidate.CandidatePositions)
                {
                        entity.CandidatePositions.Add(new CandidatePosition
                        {
                            CandidateId = candidate.CandidateID,
                            PositionId = position.PositionId,
                            CandidatePositionDate = position.CandidatePositionDate,
                            CandidatePositionStatus = position.CandidatePositionStatus
                        });
                    
                }

                context.SaveChanges();

                return null;
            }
        }

        /// <summary>
        /// Gets candidates
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public HunterCV.Common.CandidatesApiResponse Get([FromUri]HunterCV.Common.CandidatesApiRequest request)
        {
            string userName = Membership.GetUser().UserName;

            request.PageSize = request.PageSize == 0 ? 5 : request.PageSize;

            HunterCV.Common.CandidatesApiResponse response = new Common.CandidatesApiResponse();

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);

                var candidates = user.Roles.Single().Users
                                 .SelectMany(p => p.Candidates);

                var m_filteredCandidates = (from l in candidates select l);

                //name
                if (!string.IsNullOrEmpty(request.FilterFullName))
                {
                    string[] segments = request.FilterFullName.Split(' ');

                    foreach (string s in segments)
                    {
                        m_filteredCandidates = m_filteredCandidates.Where(a => a.FirstName.ToLower().Contains(request.FilterFullName.ToLower()) || a.LastName.ToLower().Contains(request.FilterFullName.ToLower()));
                    }
                }

                //starred
                var selectedStarred = new List<string>();
                if (request.FilterStarredGold)
                {
                    selectedStarred.Add("Gold");
                }
                if (request.FilterStarredRed)
                {
                    selectedStarred.Add("Red");
                }
                if (request.FilterStarredBlue)
                {
                    selectedStarred.Add("Blue");
                }

                if (selectedStarred.Count() > 0)
                {
                    m_filteredCandidates = m_filteredCandidates.Where(a => selectedStarred.Contains(a.Starred) );
                }

                //created by
                if (!string.IsNullOrEmpty(request.FilterCreatedBy))
                {
                    Guid guid = new Guid(request.FilterCreatedBy);
                    m_filteredCandidates = m_filteredCandidates.Where(a => a.UserId == guid);
                }

                //areas
                if (!string.IsNullOrEmpty(request.FilterAreas))
                {
                    IEnumerable<String> areas = request.FilterAreas.Split(',').ToList();

                    if (areas.Count() > 0)
                    {
                        m_filteredCandidates = m_filteredCandidates.Where(p => areas.Contains(p.Areas));
                    }
                }

                if (!string.IsNullOrEmpty(request.FilterRole))
                {
                    m_filteredCandidates = m_filteredCandidates.Where(a => a.Roles == request.FilterRole);
                }

                if (!string.IsNullOrEmpty(request.FilterStatus))
                {
                    m_filteredCandidates = m_filteredCandidates.Where(a => a.Status == request.FilterStatus);
                }

                if (!string.IsNullOrEmpty(request.FilterMailEntryId))
                {
                    m_filteredCandidates = m_filteredCandidates.Where(a => a.MailEntryID == request.FilterMailEntryId);
                }

                if (request.FilterCandidateNumber.HasValue)
                {
                    m_filteredCandidates = m_filteredCandidates.Where(a => a.CandidateNumber.Value == request.FilterCandidateNumber);
                }

                if ( request.FilterRegistrationStartDate.HasValue && request.FilterRegistrationEndDate.HasValue)
                {
                    DateTime start = new DateTime(request.FilterRegistrationStartDate.Value);
                    DateTime end = new DateTime(request.FilterRegistrationEndDate.Value);

                    m_filteredCandidates = m_filteredCandidates.Where(a => a.RegistrationDate.Value >= start && a.RegistrationDate.Value <= end );
                }

                response.TotalRows = m_filteredCandidates.Count();
                response.TotalPages = response.TotalRows / request.PageSize + (response.TotalRows % request.PageSize
                    > 0 ? 1 : 0);

                //Sorting 

                if (request.SortField == "Starred")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.Starred);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.Starred);
                    }
                }

                if (request.SortField == "CandidateNumber")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.CandidateNumber);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.CandidateNumber);
                    }
                }


                if (request.SortField == "RegistrationDate")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.RegistrationDate);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.RegistrationDate);
                    }
                }


                if (request.SortField == "FirstName")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.FirstName);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.FirstName);
                    }
                }

                if (request.SortField == "LastName")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.LastName);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.LastName);
                    }
                }

                if (request.SortField == "Experience")
                {
                    if (request.SortType == 1)
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderByDescending(p => p.Experience);
                    }
                    else
                    {
                        m_filteredCandidates = m_filteredCandidates.OrderBy(p => p.Experience);
                    }
                }

                response.Candidates = m_filteredCandidates
                    .Skip( request.PageSize * request.PageNumber )
                    .Take( request.PageSize )
                    .Select(p => Mapper.Map<Candidate, HunterCV.Common.Candidate>(p)).ToList();

            }

            return response;

        }

        private HunterCV.Common.Candidate CreatePrimitiveCandidate(Candidate candidate)
        {
            HunterCV.Common.Candidate c = new Common.Candidate();

            c.Areas = candidate.Areas;
            c.CandidateID = candidate.CandidateID;
            c.CandidateNumber = candidate.CandidateNumber;
            c.CandidatePositions = new List<Common.CandidatePosition>();

            if (candidate.CandidatePositions != null)
            {
                foreach (var p in candidate.CandidatePositions)
                {
                    c.CandidatePositions.Add(new Common.CandidatePosition
                    {
                        CandidateId = c.CandidateID,
                        PositionId = p.PositionId,
                        CandidatePositionDate = p.CandidatePositionDate,
                        CandidatePositionStatus = p.CandidatePositionStatus
                    });
                }
            }

            c.DateOfBirth = candidate.DateOfBirth;
            c.EMailAddress = candidate.EMailAddress;
            c.Events = candidate.Events;
            c.Experience = candidate.Experience;
            c.FirstName = candidate.FirstName;
            c.Former8200 = candidate.Former8200;
            c.IdentityNumber = candidate.IdentityNumber;
            c.IsActive = candidate.IsActive;
            c.LastName = candidate.LastName;
            c.MailEntryID = candidate.MailEntryID;
            c.Mobile = candidate.Mobile;
            c.Phone = candidate.Phone;
            c.Reference = candidate.Reference;
            c.RegistrationDate = candidate.RegistrationDate;
            c.ResumePath = candidate.ResumePath;
            c.Roles = candidate.Roles;
            c.SigningDate = candidate.SigningDate;
            c.Status = candidate.Status;
            c.Username = candidate.User.UserName;
            c.WorkStartDate = candidate.WorkStartDate;
            return c;
        }

    }
}