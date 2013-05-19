using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using HunterCV.Common;

namespace HunterCV.FrontSite.ApiControllers
{
    public class AccountController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Post(LogOnModel model)
        {
            if (Membership.ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return true;
            }

            return false;
        }

        // Create user

        //        Area areaRow = null;
        //Company companyRow = null;
        //CandidateRole roleRow = null;
        //Status statusRow = null;

        //if (areas == null)
        //{
        //    string areasXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/areas.xml"));

        //    areaRow = new Area();
        //    areaRow.Username = username;
        //    areaRow.Xml = areasXml;

        //    context.AddToAreas(areaRow);
        //    context.SaveChanges();
        //}
        //else
        //{
        //    areaRow = areas;
        //}wb   m

    }
}