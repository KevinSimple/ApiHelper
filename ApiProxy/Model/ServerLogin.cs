using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProxy.ApiHelpers;
using ApiProxy.Shared;

namespace ApiProxy.Model
{public class ServerLogin : ModelBaseClass
    {
        public string ServerUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long ClientId { get; set; }


        /// <summary>
        /// Get all Server Logins
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ServerLogin>> GetAll()
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.ServerLogin;

            return await GetAll<ServerLogin>(apiUrl);
        }

        /// <summary>
        /// Get a Login by Server Login id
        /// </summary>
        /// <returns></returns>
        public static async Task<ServerLogin> GetServerLoginById(long id)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.ServerLogin;

            return await GetById<ServerLogin>(apiUrl, id);
        }


        /// <summary>
        /// Create a new Server Login
        /// </summary>
        /// <returns></returns>
        public static async Task<ServerLogin> Create(ServerLogin model)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.ServerLogin;

            return await Post<ServerLogin>(apiUrl, model);
        }

        /// <summary>
        /// Update a Server Login by id
        /// </summary>
        /// <returns></returns>
        public static async Task<ServerLogin> Update(long id, ServerLogin model)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.ServerLogin;

            return await Put<ServerLogin>(apiUrl, id, model);
        }

        /// <summary>
        /// Delete a Server Login by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> Delete(long id)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.ServerLogin;

            return await Delete(apiUrl, id);

        }
    }
}