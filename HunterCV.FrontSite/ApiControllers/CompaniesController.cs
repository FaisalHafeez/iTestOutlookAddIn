﻿using System;
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
    public class CompaniesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Put(HunterCV.Common.Company company)
        {
            string username = Membership.GetUser().UserName;
            
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var role = context.Users.Single(user => user.UserName == username)
                                 .Roles.Single();

                role.CandidatesCompanies = company.Xml;
                context.SaveChanges();
            }
        }


    }
}