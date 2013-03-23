using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bootstrap.AutoMapper;
using AutoMapper;

namespace iTestService.AutoMap
{
        public class CandidateCreator : IMapCreator
        {
            public void CreateMap(IProfileExpression mapper)
            {
                mapper.CreateMap<Candidate, iTest.Common.Candidate>().ReverseMap();
                //mapper.CreateMap<iTest.Common.Candidate, Candidate>();
            }
        }
}