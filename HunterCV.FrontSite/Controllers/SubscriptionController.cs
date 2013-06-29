using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HunterCV.Model;
using System.Web.Security;

namespace HunterCV.FrontSite.Controllers
{
    [Authorize]
    public class SubscriptionController : BaseController
    {
        public ActionResult Cancel(string role)
        {
            return View();
        }

        public ActionResult Success(string role)
        {
            return View();
        }

        public ActionResult Download(string role)
        {
            return View();
        }

    }
}
