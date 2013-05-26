using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
using HunterCV.Model;
using System.Net.Http.Headers;

namespace HunterCV.FrontSite.ApiControllers
{
    public class ResumeServicesController : ApiController
    {
        /// <summary>
        /// Gets resume content
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("content")]
        public HttpResponseMessage GetContent(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var cvs = context.Resumes.Include("ResumeContent")
                    .Where(p => p.ResumeID == id);

                if (cvs.Any())
                {
                    response.Content = new StreamContent(new MemoryStream(cvs.FirstOrDefault().ResumeContent.FileContent));

                    string extension = new FileInfo(cvs.FirstOrDefault().FileName).Extension.ToLower();
                    string contentType = string.Empty;
                    switch (extension)
                    {
                        case ".pdf":
                            contentType = "application/pdf";
                            break;
                        case ".doc":
                            contentType = "application/msword";
                            break;
                        case ".docx":
                            contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                            break;
                    }
                    
                    response.Content.Headers.ContentType =
                        new MediaTypeHeaderValue(contentType);
                }
            }

            return response;
        }

    }
}