using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iTestService.Models;
using System.Web.Security;
using AutoMapper;
using System.IO;
using System.Web;

namespace iTestService.Controllers
{
    [Authorize]
    public class AreasController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Put(iTest.Common.Area area)
        {
            string username = Membership.GetUser().UserName;
            
            using (invidiadbEntities context = new invidiadbEntities())
            {
                var areasRow = context.Areas.Where(p => p.Username == username).FirstOrDefault();

                areasRow.Xml = area.Xml;
                context.SaveChanges();
            }
        }


    }
}