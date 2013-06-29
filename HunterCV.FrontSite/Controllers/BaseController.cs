using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HunterCV.Model;

namespace HunterCV.FrontSite.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (requestContext.HttpContext.Request.IsAuthenticated)
            {
                string userName = User.Identity.Name;

                using (hunterCVEntities context = new hunterCVEntities())
                {
                    var role = context.Users.Where(u => u.UserName == userName).Single().Roles.SingleOrDefault();

                    if (role == null)
                    {
                        ViewBag.LicenseType = "None";
                    }
                    else
                    {
                        ViewBag.LicenseType = role.LicenseType;
                    }
                }
            }

        }

        //protected override void Execute(System.Web.Routing.RequestContext requestContext)
        //{
        //    if (requestContext.HttpContext.Request.IsAuthenticated)
        //    {
        //        string userName = User.Identity.Name;

        //        using (hunterCVEntities context = new hunterCVEntities())
        //        {
        //            var role = context.Users.Where(u => u.UserName == userName).Single().Roles.SingleOrDefault();

        //            if (role == null)
        //            {
        //                ViewBag.LicenseType = "None";
        //            }
        //            else
        //            {
        //                ViewBag.LicenseType = role.LicenseType;
        //            }
        //        }
        //    }

        //    base.Execute(requestContext);
        //}
    }
}