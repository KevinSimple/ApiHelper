using System;
using System.Configuration;

namespace ApiProxy.ApiHelpers
{
    public class ApiEndPoints
    {
        public const string Client = "/api/Client";

        public const string ServerLogin = "/api/ServerLogin";
    }


    public static class Helpers
    {
        /// <summary>
        /// Get Web Api Url from web.config
        /// </summary>
        /// <returns></returns>
        public static string GetWebApiUrl()
        {
            string apiUrl = ConfigurationManager.AppSettings["WebApiUrl"];

            if (string.IsNullOrEmpty(apiUrl))
            {
                throw new Exception("Web Api Url not specified in web.config");
            }
            else
            {
                return apiUrl;
            }
        }
    }

    
}