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
    public class PositionsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Post(HunterCV.Common.Position position)
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);

                var role = context.Users.Single(uu => uu.UserName == userName)
                 .Roles.Single();

                if (role.LicenseType == "Free")
                {
                    int count = context.Positions.Where(c => c.UserId == user.UserId).Count();

                    if (count >= 1)
                    {
                        throw new HttpResponseException(
                            new HttpResponseMessage { 
                                    StatusCode = HttpStatusCode.Forbidden, 
                                    Content = new StringContent("License"),
                                    ReasonPhrase = "This license type does not allow the operation"
                                });

                    }
                }

                Position target = Mapper.Map<HunterCV.Common.Position, Position>(position);
                target.User = user;

                context.Positions.AddObject(target);
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
                var position = context.Positions.Where(c => c.PositionId == new Guid(id)).FirstOrDefault();

                context.Positions.DeleteObject(position);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public void Put(HunterCV.Common.Position position)
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var curruser = context.Users.Single(user => user.UserName == userName);

                var entity = Mapper.Map<HunterCV.Common.Position, Position>(position);

                entity.UserId = curruser.UserId;

                context.Positions.Attach(entity);

                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HunterCV.Common.Position> Get()
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var positions = context.Users.Single(user => user.UserName == userName)
                                 .Roles.Single().Users
                                 .SelectMany(p => p.Positions);

                return positions.Select(p => Mapper.Map<Position, HunterCV.Common.Position>(p)).ToList();
            }
        }

    }
}