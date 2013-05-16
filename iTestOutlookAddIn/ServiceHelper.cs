using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using iTest.Common;
using System.IO;

namespace iTestOutlookAddIn
{
    public static class ServiceHelper
    {
        private static bool m_isLoggedIn;
        private static string m_aspxauthCookie;
        private static bool m_canceledLogin;

        static ServiceHelper()
        {
            m_canceledLogin = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool CanceledLogin
        {
            get
            {
                return m_canceledLogin;
            }

            set
            {
                m_canceledLogin = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsLoggedIn
        {
            get
            {
                return m_isLoggedIn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(string userName, string password)
        {

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsJsonAsync(
                    ConfigurationManager.AppSettings["iTest.Service.AccountsUrl"],
                    new { username = userName, password = password },
                    CancellationToken.None
                ).Result;

                response.EnsureSuccessStatusCode();

                m_isLoggedIn = response.Content.ReadAsAsync<bool>().Result;

                if (m_isLoggedIn)
                {
                    m_aspxauthCookie = response.Headers.First(h => h.Key.ToLower() == "set-cookie").Value.First().Split('=')[1].Split(';')[0];
                }

                return m_isLoggedIn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Add(Candidate candidate)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PostAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"],
                        candidate,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Area area)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.AreasUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.AreasUrl"],
                        area,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Role role)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.RolesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.RolesUrl"],
                        role,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Status status)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.StatusesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.StatusesUrl"],
                        status,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Company company)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.CompaniesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.CompaniesUrl"],
                        company,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Candidate candidate)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"],
                        candidate,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Delete(Candidate candidate)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"], "/?id=" + candidate.CandidateID.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }

        }

        public static byte[] GetResumeContent(int resumeId)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var stream = httpClient.GetStreamAsync(string.Concat(
                             ConfigurationManager.AppSettings["iTest.Service.ResumesUrl"], "/content/", resumeId.ToString()))
                             .Result;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            byte[] buf = new byte[1024];
                            count = stream.Read(buf, 0, 1024);
                            ms.Write(buf, 0, count);
                        } while (stream.CanRead && count > 0);
                        
                        return ms.ToArray();
                    }
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }

            
        }

        private static byte[] ReadAllBytes(Stream source)
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Resume> GetResumes(Guid candidateId)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.GetAsync(string.Concat(ConfigurationManager.AppSettings["iTest.Service.ResumesUrl"], "/documents/", candidateId.ToString())).Result;
                    var documents = response.Content.ReadAsAsync<iTest.Common.DocumentCollection>().Result;

                    response.EnsureSuccessStatusCode();

                    return documents.Documents;
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static UserData GetUserData()
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.GetStringAsync(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Result;

                    var des = (UserData)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(UserData));

                    return des;
                }
            }
            catch (HttpRequestException hre)
            {
                m_isLoggedIn = false;
                throw hre;
            }
            catch (AggregateException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }
            catch (WebException ex)
            {
                m_isLoggedIn = false;
                throw ex;
            }

        }
    }
}
