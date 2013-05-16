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
    public class StatusesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Put(iTest.Common.Status status)
        {
            string username = Membership.GetUser().UserName;
            
            using (invidiadbEntities context = new invidiadbEntities())
            {
                var row = context.Statuses.Where(p => p.Username == username).FirstOrDefault();

                row.Xml = status.Xml;
                context.SaveChanges();
            }
        }


    }
}