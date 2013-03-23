using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iTestService.Models;
using System.Web.Security;

namespace iTestService.Controllers
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
            if (model.Username == "itest" && model.Password == "ilana")
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return true;
            }

            return false;
        }
    }
}