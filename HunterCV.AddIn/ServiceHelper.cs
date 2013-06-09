using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Configuration;
using Newtonsoft.Json;
using System.Net;
using HunterCV.Common;
using System.IO;
using System.ComponentModel;
using HunterCV.AddIn.ExtensionMethods;

namespace HunterCV.AddIn
{
    public class LoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class ServiceHelper
    {
        private static bool m_isLoggedIn;
        private static string m_aspxauthCookie;
        private static bool m_canceledLogin;
        private static LoginDetails m_lastLogin;
        private static bool m_isDevelopingServer;

        public static LoginDetails LastLogin
        {
            get { return ServiceHelper.m_lastLogin; }
            set { ServiceHelper.m_lastLogin = value; }
        }

        public static bool IsDevelopingMachine { get { return m_isDevelopingServer; } }

        static ServiceHelper()
        {
            m_canceledLogin = false;
            m_isDevelopingServer = System.Environment.MachineName == "ARIEL8804";
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

        public static bool Login(string userName, string password)
        {
            return Login(new LoginDetails
            {
                Username = userName,
                Password = password
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Login(LoginDetails login)
        {

            WebProxy proxy = null;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
            {
                proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
            }

            using (var httpClient = new HttpClient(new HttpClientHandler()
            {
                UseProxy = Properties.Settings.Default.UseProxy,
                Proxy = proxy
            }))
            {
                var response = httpClient.PostAsJsonAsync(
                    ConfigurationManager.AppSettings["HunterCV.Service.AccountsUrl"],
                    new { username = login.Username, password = login.Password },
                    CancellationToken.None
                ).Result;

                response.EnsureSuccessStatusCode();

                m_isLoggedIn = response.Content.ReadAsAsync<bool>().Result;

                if (m_isLoggedIn)
                {
                    m_lastLogin = login;
                    m_aspxauthCookie = response.Headers.First(h => h.Key.ToLower() == "set-cookie").Value.First().Split('=')[1].Split(';')[0];
                }

                return m_isLoggedIn;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static int Add(Candidate candidate)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy,
                    CookieContainer = cookieContainer
                }))
                {
                    var response = httpClient.PostAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"],
                        candidate,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();

                    PostCandidateApiResponse result = response.Content.ReadAsAsync<PostCandidateApiResponse>().Result;

                    if (result.Duplicates != null && result.Duplicates.Any())
                    {
                        throw new DuplicateCandidatesException
                        {
                            Duplicates = result.Duplicates
                        };
                    }
                    else
                    {
                        return result.NewCandidate.CandidateNumber.Value;
                    }
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void AddFavorite(Candidate candidate)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.FavoriteCandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PostAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.FavoriteCandidatesUrl"],
                        candidate,
                        CancellationToken.None
                    ).Result;


                    response.EnsureSuccessStatusCode();
                }
            }
            catch (LicenseException)
            {
                throw;
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Add(Position position)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PostAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"],
                        position,
                        CancellationToken.None
                    ).Result;

                    if (response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        throw new LicenseException(typeof(ThisAddIn), null, response.ReasonPhrase);
                    }

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (LicenseException)
            {
                throw;
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.AreasUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.AreasUrl"],
                        area,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.RolesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.RolesUrl"],
                        role,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(CandidateStatus status)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.StatusesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.StatusesUrl"],
                        status,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Settings settings)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.SettingsUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.SettingsUrl"],
                        settings,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(PositionStatus status)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.PositionsStatusesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.PositionsStatusesUrl"],
                        status,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.CompaniesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.CompaniesUrl"],
                        company,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void Update(Resume resume)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"],
                        resume,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        public static void Add(IEnumerable<MailTemplate> templates)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.MailTemplatesUrl"]).Host;
            cookieContainer.Add(cookie);

            WebProxy proxy = null;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
            {
                proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
            }

            try
            {
                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PostAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.MailTemplatesUrl"],
                        templates,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        public static void UpdateMailTemplate(MailTemplate template)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.MailTemplatesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.MailTemplatesUrl"],
                        template,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public static void Update(Position position)
        {
            var cookieContainer = new CookieContainer();
            Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
            cookie.Secure = false;
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"],
                        position,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
            cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"]).Host;
            cookieContainer.Add(cookie);

            try
            {
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.PutAsJsonAsync(
                        ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"],
                        candidate,
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"], "/?id=" + candidate.CandidateID.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void DeleteFavorite(Guid id)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.FavoriteCandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.FavoriteCandidatesUrl"], "/?id=" + id.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public static void Delete(Position position)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.PositionsUrl"], "/?id=" + position.PositionID.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void DeletePreview(Preview preview)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.PreviewsUrl"], "/?id=" + preview.PreviewID.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidate"></param>
        public static void DeleteResume(Resume resume)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.DeleteAsync(
                        new Uri(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"], "/?id=" + resume.ResumeID.ToString())),
                        CancellationToken.None
                    ).Result;

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }


        public static Stream GetGoogleDocStream(string url)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var stream = httpClient.GetStreamAsync(url)
                             .Result;


                    return stream;
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var stream = httpClient.GetStreamAsync(string.Concat(
                             ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"], "/content/", resumeId.ToString()))
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
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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

        public static void Upload(Preview preview)
        {
            try
            {
                var cookieContainer = new CookieContainer();

                FileInfo fi = new FileInfo(preview.FileName);

                    if (fi.Exists)
                    {
                        WebProxy proxy = null;

                        if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                        {
                            proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                        }

                        using (var httpClient = new HttpClient(new HttpClientHandler()
                        {
                            UseProxy = Properties.Settings.Default.UseProxy,
                            Proxy = proxy
                        }))
                        {
                            using (var content = new MultipartFormDataContent())
                            {
                                var filestream = new FileStream(fi.FullName, FileMode.Open);
                                content.Add(new StreamContent(filestream), "file", fi.Name);

                                HttpResponseMessage responseUpload = httpClient.PostAsync(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.PreviewsUrl"], "?PreviewId=", preview.PreviewID.ToString()), content).Result;
                                responseUpload.EnsureSuccessStatusCode();
                            }
                        }
                    }
                
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }


        }


        public static void Upload(Guid candidateId, IEnumerable<Resume> documents)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                IEnumerable<Resume> not_cloudy = documents.Where(d => !d.IsCloudy);

                foreach (Resume doc in not_cloudy)
                {
                    FileInfo fi = new FileInfo(doc.FileName);

                    if (fi.Exists)
                    {
                        WebProxy proxy = null;

                        if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                        {
                            proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                        }

                        using (var httpClient = new HttpClient(new HttpClientHandler()
                        {
                            CookieContainer = cookieContainer,
                            UseProxy = Properties.Settings.Default.UseProxy,
                            Proxy = proxy
                        }))
                        {
                            using (var content = new MultipartFormDataContent())
                            {
                                var filestream = new FileStream(fi.FullName, FileMode.Open);
                                content.Add(new StreamContent(filestream), "file", fi.Name);
                                content.Add(new StringContent(doc.Description ?? string.Empty));

                                HttpResponseMessage responseUpload = httpClient.PostAsync(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"], "?CandidateID=", candidateId.ToString()), content).Result;
                                responseUpload.EnsureSuccessStatusCode();
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
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
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.GetAsync(string.Concat(ConfigurationManager.AppSettings["HunterCV.Service.ResumesUrl"], "/documents/", candidateId.ToString())).Result;
                    var documents = response.Content.ReadAsAsync<HunterCV.Common.DocumentCollection>().Result;

                    response.EnsureSuccessStatusCode();

                    return documents.Documents;
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }

        public static CandidatesApiResponse SearchCandidates(CandidatesApiRequest request)
        {
            try
            {
                var cookieContainer = new CookieContainer();
                Cookie cookie = new Cookie(".ASPXAUTH", m_aspxauthCookie);
                cookie.Secure = false;
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.GetAsync( string.Concat( ConfigurationManager.AppSettings["HunterCV.Service.CandidatesUrl"], "?" ,
                            
                       request.GetQueryString() )).Result;

                    var des = (CandidatesApiResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result, typeof(CandidatesApiResponse));

                    return des;
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
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
                cookie.Domain = new Uri(ConfigurationManager.AppSettings["HunterCV.Service.RolesUrl"]).Host;
                cookieContainer.Add(cookie);

                WebProxy proxy = null;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.ProxyAddress))
                {
                    proxy = new WebProxy(Properties.Settings.Default.ProxyAddress, Properties.Settings.Default.ProxyPort);
                }

                using (var httpClient = new HttpClient(new HttpClientHandler()
                {
                    CookieContainer = cookieContainer,
                    UseProxy = Properties.Settings.Default.UseProxy,
                    Proxy = proxy
                }))
                {
                    var response = httpClient.GetStringAsync(ConfigurationManager.AppSettings["HunterCV.Service.RolesUrl"]).Result;

                    var des = (UserData)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(UserData));

                    return des;
                }
            }
            catch (HttpRequestException hre)
            {
                throw hre;
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }

        }
    }
}
