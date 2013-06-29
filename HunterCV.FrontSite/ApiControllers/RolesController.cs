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

namespace HunterCV.FrontSite.ApiControllers
{
    [Authorize]
    public class RolesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HunterCV.Common.UserData Get()
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var positions = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single().Users
                                 .SelectMany(p => p.Positions);

                var role = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single();

                var users = new Dictionary<string, string>();
                users.Add("","");
                
                role.Users.Each( (u) => 
                {
                    users.Add(u.UserId.ToString(), u.UserName);
                });
               

                var templates = role.MailTemplates;

                var areas = role.CandidatesAreas;
                var companies = role.CandidatesCompanies;
                var roles = role.CandidatesRoles;
                var candidateStatuses = role.CandidatesStatuses;
                var positionsStatuses = role.PositionsStatuses;
                var settings = role.Settings;

                Guid licenseGuid = Guid.Empty;

                switch (role.LicenseType)
                {
                    case "Free":
                        licenseGuid = Common.Role.FreeLicenseGuid;
                        break;
                    case "Standard":
                        licenseGuid = Common.Role.StandardLicenseGuid;
                        break;
                    case "Premium":
                        licenseGuid = Common.Role.PremiumLicenseGuid;
                        break;
                }

                return new HunterCV.Common.UserData
                {
                    license = licenseGuid,
                    roleId = role.RoleId,
                    positions = positions.Select(p => Mapper.Map<Position, HunterCV.Common.Position>(p)).ToList(),
                    areas = areas,
                    companies = companies,
                    roles = roles,
                    candidatesStatuses = candidateStatuses,
                    positionsStatuses = positionsStatuses,
                    templates = templates.Select(p => Mapper.Map<MailTemplate, HunterCV.Common.MailTemplate>(p)).ToList(),
                    settings = settings,
                    users = users
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Put(HunterCV.Common.Role role)
        {
            string username = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var roleEntity = context.Users.Single(user => user.UserName == username)
                                 .Roles.Single();

                roleEntity.CandidatesRoles = role.Xml;
                context.SaveChanges();
            }
        }


    }
}