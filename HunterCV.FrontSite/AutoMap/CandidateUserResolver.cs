using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HunterCV.Model;

namespace HunterCV.FrontSite.AutoMapper
{
    public class CandidateUserResolver : ValueResolver<Candidate, string>
    {
        protected override string ResolveCore(Candidate source)
        {
            return source.User.UserName;
        }
    }
}