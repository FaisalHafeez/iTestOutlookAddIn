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
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;

namespace iTestService.Controllers
{
    [Authorize]
    public class ResumesController : ApiController
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

            using (invidiadbEntities context = new invidiadbEntities())
            {
                var cvs = context.Resumes.Include("ResumeContent")
                    .Where(p => p.ResumeID == id);

                if (cvs.Any())
                {
                    response.Content = new StreamContent(new MemoryStream(cvs.FirstOrDefault().ResumeContent.FileContent));
                }
            }

            return response;
        }

        /// <summary>
        /// returns list of resume
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("documents")]
        public iTest.Common.DocumentCollection Get(string id)
        {
            Guid gid = new Guid(id);
            iTest.Common.DocumentCollection result = new iTest.Common.DocumentCollection();
            var documents = new List<iTest.Common.Resume>();

            using (invidiadbEntities context = new invidiadbEntities())
            {
                var cvs = context.Resumes
                    .Where(p => p.CandidateID == gid);

                if (cvs.Any())
                {
                    cvs.Each(p =>
                    {
                        documents.Add(new iTest.Common.Resume
                        {
                            ResumeID = p.ResumeID,
                            FileName = p.FileName,
                            CandidateID = p.CandidateID
                        });
                    });
                }
            }

            result.Documents = documents;

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public Task<HttpResponseMessage> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var streamProvider = new MultipartMemoryStreamProvider();
            var query = Request.GetQueryNameValuePairs();
            string candidateId = string.Empty;

            if (query != null)
            {
                var matches = query.Where(kv => kv.Key.ToLower() == "candidateid");
                if (matches.Count() > 0)
                {
                    candidateId = matches.First().Value;
                }
            }

            // Read the form data and return an async task.
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }

                    if (string.IsNullOrEmpty(candidateId))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Missing CandidateId parameter");
                    }

                    //Select the appropriate content item this assumes only 1 part
                    var fileContent = streamProvider.Contents.SingleOrDefault();
                    string fileName = fileContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                    Stream fileStream = fileContent.ReadAsStreamAsync().Result;

                    using (invidiadbEntities context = new invidiadbEntities())
                    {
                        Resume resume = new Resume();
                        resume.FileName = fileName;
                        resume.CandidateID = new Guid(candidateId);
                        context.AddToResumes(resume);
                        context.SaveChanges();

                        ResumeContent content = new ResumeContent();
                        content.ResumeID = resume.ResumeID;
                        content.FileContent = ReadAllBytes(fileStream);
                        context.AddToResumeContents(content);
                        context.SaveChanges();

                    }

                    return Request.CreateResponse(HttpStatusCode.OK);
                });

            return task;
        }

        private byte[] ReadAllBytes(Stream source)
        {
            long originalPosition = source.Position;
            source.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = source.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = source.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                source.Position = originalPosition;
            }
        }
    }
}