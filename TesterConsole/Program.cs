using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Data.SqlServerCe;
using System.IO;
using System.Net.Http.Headers;
using System.Xml.Serialization;
using System.Xml;
using System.Net;

namespace TesterConsole
{
    class Program
    {
        static void Upgrade()
        {
            string connStringCI = @"Data Source= C:\Projects\iTestOutlookAddIn\TesterConsole\App_Data\iTestData.sdf;";

            // Set "Case Sensitive" to true to change the collation from CI to CS.
            //string connStringCS = "Data Source= Northwind.sdf; LCID= 1033; Case Sensitive=true";

            SqlCeEngine engine = new SqlCeEngine(connStringCI);

            // The collation of the database will be case sensitive because of 
            // the new connection string used by the Upgrade method.                
            engine.Upgrade();
        }


        static void Main()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsJsonAsync(
                    "http://localhost:3136/api/account",
                    new { username = "itest", password = "yamit@02" },
                    CancellationToken.None
                ).Result;
                response.EnsureSuccessStatusCode();

                var aspxauth = response.Headers.First(h => h.Key.ToLower() == "set-cookie").Value.First().Split('=')[1].Split(';')[0];

                bool success = response.Content.ReadAsAsync<bool>().Result;
                if (success)
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        //var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(@"C:\Users\Administrator\Desktop\testresume.docx"));
                        var filestream = new FileStream(@"C:\Users\Administrator\Desktop\testresume.docx", FileMode.Open);
                        //fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        //{
                        //    FileName = "testresume.docx"
                        //};
                        //content.Add(fileContent);
                        content.Add(new StreamContent(filestream), "file", "testresume.docx");

                        HttpResponseMessage responseUpload = httpClient.PostAsync("http://localhost:3136/api/resumes?CandidateId=E47FF5D8-B79F-4568-84DD-018AD1BD5E14", content).Result;
                        responseUpload.EnsureSuccessStatusCode();
                    }

                    //var message = new HttpRequestMessage();
                    //var content = new MultipartFormDataContent();
                    //content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    //    {
                    //        FileName = "testresume.docx"
                    //    };
                    //var filestream = new FileStream(@"C:\Users\Administrator\Desktop\testresume.docx", FileMode.Open);
                    //var fileName = System.IO.Path.GetFileName(@"C:\Users\Administrator\Desktop\testresume.docx");
                    //content.Add(new StreamContent(filestream), "file", fileName);

                    //message.Method = HttpMethod.Post;
                    //message.Content = content;
                    //message.RequestUri = new Uri("http://localhost:3136/api/resumes?CandidateId=E47FF5D8-B79F-4568-84DD-018AD1BD5E14");

                    //httpClient.SendAsync(message).ContinueWith(task =>
                    //{
                    //    if (task.Result.IsSuccessStatusCode)
                    //    {
                    //        //do something with response
                    //    }
                    //});


                    //var res2 = httpClient.GetAsync("http://localhost:3136/api/resumes/E47FF5D8-B79F-4568-84DD-018AD1BD5E14").Result;
                    //var res2 = httpClient.GetByteArrayAsync("http://localhost:3136/api/resumes/content/27").Result;
                    //var ress = res2  .Content.ReadAsAsync<byte[]>().Result;


                    //if ( ress.Documents != null )
                    //{
                    //    foreach (iTest.Common.Resume resume in ress.Documents)
                    //    {
                    //        Console.WriteLine(resume.FileName);
                    //    }
                    //}
                }
                else
                {
                    Console.WriteLine("Sorry you provided wrong credentials");
                }
            }

            Console.ReadKey();
        }
    }
}
