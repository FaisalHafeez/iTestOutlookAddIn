using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HunterCV.Model;

namespace HunterCV.FrontSite.AutoMapper
{
    public class PositionUserResolver : ValueResolver<Position, string>
    {
        protected override string ResolveCore(Position source)
        {
            return source.User.UserName;
        }
    }
}