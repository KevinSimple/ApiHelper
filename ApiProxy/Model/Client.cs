using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProxy.ApiHelpers;
using ApiProxy.Shared;


namespace ApiProxy.Model
{
    public class Client : ModelBaseClass
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Client>> GetAll()
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.Client;

            return await GetAll<Client>(apiUrl);
        }

        /// <summary>
        /// Get a client by client id
        /// </summary>
        /// <returns></returns>
        public static async Task<Client> GetClientById(long id)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.Client;

            return await GetById<Client>(apiUrl, id);
        }


        /// <summary>
        /// Create a new client
        /// </summary>
        /// <returns></returns>
        public static async Task<Client> Create(Client model)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.Client;

            return await Post<Client>(apiUrl, model);
        }

        /// <summary>
        /// Update a client by id
        /// </summary>
        /// <returns></returns>
        public static async Task<Client> Update(long id, Client model)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.Client;

            return await Put<Client>(apiUrl, id, model);
        }

        /// <summary>
        /// Delete a client by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> Delete(long id)
        {
            var apiUrl = BaseWebApiUrl.ApiUrl + ApiEndPoints.Client;

            return await Delete(apiUrl, id);

        }
    }

}
