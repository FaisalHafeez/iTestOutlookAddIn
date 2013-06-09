using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HunterCV.Model;
using System.Web.Security;

namespace HunterCV.FrontSite.AutoMapper
{
    public class FavoritesUserResolver : ValueResolver<Candidate, bool>
    {
        protected override bool ResolveCore(Candidate source)
        {
            string user = Membership.GetUser().UserName;

            return source.FavoriteUsers.Select(u => u.UserName).Contains(user);
        }

    }
}