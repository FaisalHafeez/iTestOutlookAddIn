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
    public class MailTemplatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Post(IEnumerable<HunterCV.Common.MailTemplate> templates)
        {
            string userName = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var role = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single();

                var exists = context.MailTemplates.Where(t => t.RoleId == role.RoleId);

                foreach (MailTemplate tmpl in exists)
                {
                    context.MailTemplates.DeleteObject(tmpl);
                }

                foreach (HunterCV.Common.MailTemplate tmpl in templates)
                {
                    tmpl.RoleId = role.RoleId;
                    MailTemplate target = Mapper.Map<HunterCV.Common.MailTemplate, MailTemplate>(tmpl);

                    context.MailTemplates.AddObject(target);
                }

                context.SaveChanges();
            }
        }


    }
}