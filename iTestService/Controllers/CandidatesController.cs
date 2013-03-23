using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iTestService.Models;
using System.Web.Security;
using AutoMapper;

namespace iTestService.Controllers
{
    [Authorize]
    public class CandidatesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Post(iTest.Common.Candidate candidate)
        {
            using (iTestData context = new iTestData())
            {
                context.Candidates.AddObject(Mapper.Map<iTest.Common.Candidate, Candidate>(candidate));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Delete(string id)
        {
            using (iTestData context = new iTestData())
            {
                var candidate = context.Candidates.Where(c => c.CandidateID == new Guid(id)).FirstOrDefault();

                context.Candidates.DeleteObject(candidate);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Put(iTest.Common.Candidate candidate)
        {
            using (iTestData context = new iTestData())
            {
                context.Candidates.Attach(Mapper.Map<iTest.Common.Candidate, Candidate>(candidate));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iTest.Common.CandidateCollection Get()
        {
            using (iTestData context = new iTestData())
            {
                var result = context.Candidates.ToList();

                return new iTest.Common.CandidateCollection
                    {
                        data = result.Select(p => Mapper.Map<Candidate, iTest.Common.Candidate>(p))
                    };
            }
        }

    }
}