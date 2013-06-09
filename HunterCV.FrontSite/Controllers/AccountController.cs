using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using HunterCV.FrontSite.Models;
using HunterCV.Model;

namespace HunterCV.FrontSite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);

                using (hunterCVEntities context = new hunterCVEntities())
                {
                    var role = context.Users.Where(u => u.UserName == model.UserName).Single().Roles.Single();

                    if (role.LicenseType == "Free")
                    {
                        return RedirectToAction("Manage", "Account");
                    }
                }
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (Roles.RoleExists(model.Company))
                {
                    ModelState.AddModelError("", "Company name allready exists");
                }
                else
                {
                    // Attempt to register the user
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        Roles.CreateRole(model.Company);
                        Roles.AddUserToRole(model.UserName, model.Company);

                        using (hunterCVEntities context = new hunterCVEntities())
                        {
                            var role = context.Roles.Single(r => r.RoleName == model.Company);

                            role.CandidatesCompanies = @"<?xml version=""1.0"" encoding=""utf-8""?><companies><company title=""Coca-Cola, Inc.""></company></companies>";
                            role.CandidatesAreas = @"<?xml version=""1.0"" encoding=""utf-8"" ?><areas><area title=""Security""></area><area title=""Management""></area><area title=""System""></area><area title=""BI""></area><area title=""Hardware""></area><area title=""QA""><area title=""Automation""></area><area title=""Manual""></area><area title=""Mobile""></area><area title=""Security""></area><area title=""Finance""></area></area><area title=""Developing""><area title=""JAVA""></area><area title=""WEB""></area><area title=""C""></area><area title=""C++""></area></area><area title=""Sales""></area><area title=""Administrator""></area><area title=""IT""></area><area title=""ERP""></area><area title=""Product""></area><area title=""Algorithem""></area><area title=""Embedded""></area><area title=""Electricity Engeneering""></area><area title=""Industrial Management""></area><area title=""Support""></area><area title=""Media""></area><area title=""Analist""></area><area title=""Internet""></area><area title=""UX/UI""></area><area title=""Marketing""></area><area title=""PMO""></area></areas>";
                            role.CandidatesStatuses = @"<?xml version=""1.0"" encoding=""utf-8""?><statuses>  <status title=""Classification""></status>  <status title=""Interview Process"">  </status>  <status title=""Before Contract Signing"">  </status>  <status title=""Signed""></status></statuses>";
                            role.CandidatesRoles = @"<?xml version=""1.0"" encoding=""utf-8""?>" +
                                                                           @"<roles>" +
                                                                             @"<role title=""Team Leader""/>" +
                                                                             @"<role title=""Manager""/>" +
                                                                             @"<role title=""Director""/>" +
                                                                             @"<role title=""VP""/>" +
                                                                             @"<role title=""Programmer""/>" +
                                                                             @"<role title=""Junior Programmer""/>" +
                                                                             @"<role title=""Junior QA""/>" +
                                                                             @"<role title=""Student""/>" +
                                                                             @"<role title=""QA""/>" +
                                                                             @"</roles>";


                            role.PositionsStatuses = @"<?xml version=""1.0"" encoding=""utf-8"" ?><statuses><status title=""Open""></status><status title=""Before Contract Signing""></status><status title=""Manned""></status></statuses>";
                            role.Settings = @"<?xml version=""1.0"" encoding=""utf-8"" ?><settings><setting title=""PositionsStartIndex"" value=""100"" /><setting title=""CandidatesStartIndex"" value=""1600"" /><setting title=""PhoneFormat"" value=""(999) 000-0000"" /><setting title=""MobileFormat"" value=""(999) 000-0000"" /><setting title=""MSWordPhone2WildCards"" value=""[0-9]{3}-[0-9]{7}"" /><setting title=""MSWordPhone1WildCards"" value=""[0-9]{2}-[0-9]{7}"" /><setting title=""MSWordMobile2WildCards"" value=""[0-9][5][0-9][0-9]{7}"" /><setting title=""MSWordMobile1WildCards"" value=""[0-9][5][0-9]-[0-9]{7}"" /></settings>";
                            role.LicenseType = "Free";

                            context.SaveChanges();
                        }


                        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                        return RedirectToAction("Download", "Subscription");
                    }
                    else
                    {
                        ModelState.AddModelError("", ErrorCodeToString(createStatus));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

   

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
