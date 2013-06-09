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
    public class FavoriteCandidatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Post(HunterCV.Common.Candidate favorite)
        {
            string userName = Membership.GetUser().UserName;

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);
                var candidate = context.Candidates.Single(c => c.CandidateID == favorite.CandidateID);

                //check favorite
                if (!user.FavoriteCandidates.Contains(candidate))
                {
                    user.FavoriteCandidates.Add(candidate);
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Delete(string id)
        {
            string userName = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var user = context.Users.Single(u => u.UserName == userName);
                var candidate = context.Candidates.Where(c => c.CandidateID == new Guid(id)).FirstOrDefault();

                if (user.FavoriteCandidates.Contains(candidate))
                {
                    user.FavoriteCandidates.Remove(candidate);
                }

                context.SaveChanges();
            }
        }


    }
}