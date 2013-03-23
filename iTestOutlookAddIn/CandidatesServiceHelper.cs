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

namespace iTestOutlookAddIn
{
    public static class CandidatesServiceHelper
    {
        private static bool m_isLoggedIn;
        private static string m_aspxauthCookie;
        private static bool m_canceledLogin;

        static CandidatesServiceHelper()
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

                m_aspxauthCookie = response.Headers.First(h => h.Key.ToLower() == "set-cookie").Value.First().Split('=')[1].Split(';')[0];

                m_isLoggedIn = response.Content.ReadAsAsync<bool>().Result;

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
                cookie.Domain = "localhost";
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
        public static void Update(Candidate candidate)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = "localhost";
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
                cookie.Domain = "localhost";
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<iTest.Common.Candidate> GetCandidates()
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = "localhost";
                cookieContainer.Add(cookie);

                using (var httpClient = new HttpClient(new HttpClientHandler() { CookieContainer = cookieContainer }))
                {
                    var response = httpClient.GetStringAsync(ConfigurationManager.AppSettings["iTest.Service.CandidatesUrl"]).Result;

                    var des = (CandidateCollection)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(CandidateCollection));

                    return new List<iTest.Common.Candidate>(des.data);
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
