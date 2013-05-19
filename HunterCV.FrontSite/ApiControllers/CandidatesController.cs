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

namespace HunterCV.FrontSite.ApiControllers
{
    [Authorize]
    public class CandidatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Post(HunterCV.Common.Candidate candidate)
        {
            string userName = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);

                Candidate target = Mapper.Map<HunterCV.Common.Candidate, Candidate>(candidate);
                target.User = user;

                context.Candidates.AddObject(target);
                context.SaveChanges();
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
        public void Put(HunterCV.Common.Candidate candidate)
        {
            string userName = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var curruser = context.Users.Single(user => user.UserName == userName);

                var entity = Mapper.Map<HunterCV.Common.Candidate, Candidate>(candidate);

                var existsPositions = entity.CandidatePositions.Select(p => p.PositionId);

                //delete positions
                IEnumerable<Guid> guids  = context.CandidatePositions.Where(c => c.CandidateId == candidate.CandidateID).Where(f => !existsPositions.Contains( f.PositionId )).Select( p => p.PositionId);

                foreach (var guid in guids)
                {
                    context.CandidatePositions.DeleteObject(context.CandidatePositions.Where(c => c.CandidateId == candidate.CandidateID && c.PositionId == guid).Single());
                }

                entity.UserId = curruser.UserId;
               
                context.Candidates.Attach(entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

                foreach (HunterCV.Common.CandidatePosition position in candidate.CandidatePositions)
                {
                    var exists = context.CandidatePositions.Where(c => c.CandidateId == position.CandidateId && c.PositionId == position.PositionId).FirstOrDefault();

                    if (exists != null)
                    {
                        context.ObjectStateManager.ChangeObjectState(entity.CandidatePositions.Where(p => p.PositionId == position.PositionId).Single(), EntityState.Modified);
                    }
                    else
                    {
                        context.ObjectStateManager.ChangeObjectState(entity.CandidatePositions.Where(p => p.PositionId == position.PositionId).Single(), EntityState.Added);
                    }
                }

                //// Don't consider the child items we have just added above.
                //// (We need to make a copy of the list by using .ToList() because
                //// _dbContext.ChildItems.Remove in this loop does not only delete
                //// from the context but also from the child collection. Without making
                //// the copy we would modify the collection we are just interating
                //// through - which is forbidden and would lead to an exception.)
                //foreach (var originalChildItem in
                //             originalParent.ChildItems.Where(c => c.ID != 0).ToList())
                //{
                //    // Are there child items in the DB which are NOT in the
                //    // new child item collection anymore?
                //    if (!parent.ChildItems.Any(c => c.ID == originalChildItem.ID))
                //        // Yes -> It's a deleted child item -> Delete
                //        _dbContext.ChildItems.Remove(originalChildItem);
                //}

                //context.SaveChanges();




                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HunterCV.Common.UserData Get()
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var candidates = context.Users.Single( user => user.UserName == userName )
                                 .Roles.Single().Users
                                 .SelectMany(p => p.Candidates);

                var positions = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single().Users
                                 .SelectMany(p => p.Positions);

                var role = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single();

                var templates = role.MailTemplates;

                var areas = role.CandidatesAreas;
                var companies = role.CandidatesCompanies;
                var roles = role.CandidatesRoles;
                var candidateStatuses = role.CandidatesStatuses;
                var positionsStatuses = role.PositionsStatuses;
                var settings = role.Settings;

                return new HunterCV.Common.UserData
                    {
                        roleId = role.RoleId,
                        candidates = candidates.Select(p => Mapper.Map<Candidate, HunterCV.Common.Candidate>(p)).ToList(),
                        positions = positions.Select(p => Mapper.Map<Position, HunterCV.Common.Position>(p)).ToList(),
                        areas = areas,
                        companies = companies,
                        roles = roles,
                        candidatesStatuses = candidateStatuses,
                        positionsStatuses = positionsStatuses,
                        templates = templates.Select(p => Mapper.Map<MailTemplate, HunterCV.Common.MailTemplate>(p)).ToList(),
                        settings = settings
                    };
            }
        }

    }
}