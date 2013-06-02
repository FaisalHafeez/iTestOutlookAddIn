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
    public class PreviewsController : ApiController
    {
        /// <summary>
        /// Gets preview
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ActionName("content")]
        public HttpResponseMessage GetContent(Guid id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            using (hunterCVEntities context = new hunterCVEntities())
            {
                var cvs = context.Previews
                    .Where(p => p.PreviewID == id).FirstOrDefault();

                if (cvs != null)
                {
                    response.Content = new StreamContent(new MemoryStream(cvs.FileContent));

                    response.Content.Headers.ContentType =
                        new MediaTypeHeaderValue(cvs.ContentType);
                }
            }

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public void Delete(Guid id)
        {
            using (hunterCVEntities context = new hunterCVEntities())
            {
                var resume = context.Previews.Where(c => c.PreviewID == id).FirstOrDefault();

                context.Previews.DeleteObject(resume);
                context.SaveChanges();
            }
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
            Guid previewId = Guid.Empty;

            if (query != null)
            {
                var matches = query.Where(kv => kv.Key.ToLower() == "previewid");
                if (matches.Count() > 0)
                {
                    previewId = new Guid( matches.First().Value );
                }
            }

            //Ensure.Argument.NotNull(commands, "commands");

            // Read the form data and return an async task.
            var task = Request.Content.ReadAsMultipartAsync(streamProvider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                    if (t.IsFaulted || t.IsCanceled)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                    }

                    //Select the appropriate content item this assumes only 1 part
                    var fileContent = streamProvider.Contents.First();

                    string fileName = fileContent.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                    Stream fileStream = fileContent.ReadAsStreamAsync().Result;

                    string extension = new FileInfo(fileName).Extension.ToLower();
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

                    var description = streamProvider.Contents.Last().ReadAsStringAsync().Result;

                    using (hunterCVEntities context = new hunterCVEntities())
                    {
                        Preview preview = new Preview();
                        preview.PreviewID = previewId;
                        preview.FileName = fileName;
                        preview.ContentType = contentType;
                        preview.FileContent = ReadAllBytes(fileStream);
                        context.AddToPreviews(preview);
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