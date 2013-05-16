using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iTestService.Models;
using System.Web.Security;
using AutoMapper;
using System.IO;
using System.Web;

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
            using (invidiadbEntities context = new invidiadbEntities())
            {
                Candidate target = Mapper.Map<iTest.Common.Candidate, Candidate>(candidate);
                target.Username = Membership.GetUser().UserName;

                context.Candidates.AddObject(target);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Delete(string id)
        {
            using (invidiadbEntities context = new invidiadbEntities())
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
            using (invidiadbEntities context = new invidiadbEntities())
            {
                context.Candidates.Attach(Mapper.Map<iTest.Common.Candidate, Candidate>(candidate));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public iTest.Common.UserData Get()
        {
            string username = Membership.GetUser().UserName;

            using (invidiadbEntities context = new invidiadbEntities())
            {
                var candidates = context.Candidates
                    .Where(p => p.Username == username).ToList();

                var areas = context.Areas.Where(p => p.Username == username).FirstOrDefault();
                var companies = context.Companies.Where(p => p.Username == username).FirstOrDefault();
                var roles = context.CandidateRoles.Where(p => p.Username == username).FirstOrDefault();
                var statuses = context.Statuses.Where(p => p.Username == username).FirstOrDefault();

                Area areaRow = null;
                Company companyRow = null;
                CandidateRole roleRow = null;
                Status statusRow = null;

                if (areas == null)
                {
                    string areasXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/areas.xml"));

                    areaRow = new Area();
                    areaRow.Username = username;
                    areaRow.Xml = areasXml;

                    context.AddToAreas(areaRow);
                    context.SaveChanges();
                }
                else
                {
                    areaRow = areas;
                }

                if (companies == null)
                {
                    string companiesXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/companies.xml"));

                    companyRow = new Company();
                    companyRow.Username = username;
                    companyRow.Xml = companiesXml;

                    context.AddToCompanies(companyRow);
                    context.SaveChanges();
                }
                else
                {
                    companyRow = companies;
                }


                if (roles == null)
                {
                    string rolesXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/roles.xml"));

                    roleRow = new CandidateRole();
                    roleRow.Username = username;
                    roleRow.Xml = rolesXml;

                    context.AddToCandidateRoles(roleRow);
                    context.SaveChanges();
                }
                else
                {
                    roleRow = roles;
                }

                if (statuses == null)
                {
                    string statusesXml = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/statuses.xml"));

                    statusRow = new Status();
                    statusRow.Username = username;
                    statusRow.Xml = statusesXml;

                    context.AddToStatuses(statusRow);
                    context.SaveChanges();
                }
                else
                {
                    statusRow = statuses;
                }

                return new iTest.Common.UserData
                    {
                        candidates = candidates.Select(p => Mapper.Map<Candidate, iTest.Common.Candidate>(p)),
                        areas = areaRow.Xml,
                        companies = companyRow.Xml,
                        roles = roleRow.Xml,
                        statuses = statusRow.Xml
                    };
            }
        }

    }
}