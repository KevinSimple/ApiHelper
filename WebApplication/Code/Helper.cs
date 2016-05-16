using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication.Code
{
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