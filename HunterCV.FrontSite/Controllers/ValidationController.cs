using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.Security;
using System.Globalization;

namespace HunterCV.FrontSite.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        public JsonResult IsUsernameAvailable(string Username)
        {
            var user = Membership.GetUser(Username);

            if (user != null)
            {
                string msg = String.Format(CultureInfo.InvariantCulture,
                "Sorry but this user name is taken, try another one", Username);

                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }

    }

}
