using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace HunterCV.FrontSite.ExtensionMethods
{
    public static class HelpersExtensionsMethods
    {
        public static bool Has(this object obj, string propertyName)
        {
            var dynamic = obj as DynamicObject;
            if (dynamic == null) return false;
            return dynamic.GetDynamicMemberNames().Contains(propertyName);
        }

        public static MvcHtmlString CustomValidationSummary(this HtmlHelper helper, string validationMessage = "")
        {
            string retVal = "";
            if (helper.ViewData.ModelState.IsValid)
                return new MvcHtmlString("");

            retVal += "<div class='alert alert-error'>";
            if (!String.IsNullOrEmpty(validationMessage))
                retVal += helper.Encode(validationMessage);
            foreach (var key in helper.ViewData.ModelState.Keys)
            {
                foreach (var err in helper.ViewData.ModelState[key].Errors)
                    retVal += helper.Encode(err.ErrorMessage);
            }
            retVal += "</div>";
            return new MvcHtmlString( retVal.ToString() );
        }
    }
}