using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiProxy.Shared
{
    public class ModelBaseClass
    {
        #region member vairable 

        //Common property that Models shared, e.g Id for the primary key 
        public long Id { get; set; }

        public static string ApiUrl { get; set; }
        #endregion

        /// <summary>
        /// Get all the data for a model  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <returns></returns>
        public static async Task<List<T>> GetAll<T>(string apiEndPoint)
        {
            try
            {
                var client = BuildHttpClient(apiEndPoint, ContenType.ApplicationJson);
                var response = await client.GetAsync(apiEndPoint);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var listOfT = JsonConvert.DeserializeObject<List<T>>(jsonString);
                    return listOfT;
                }
                else
                {
                    return new List<T>();
                }
            }
            catch (Exception ex)
            {
                //TODO LOG EXCEPTION
                return null;
            }

        }

        /// <summary>
        /// Get data for a specific resource id  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<T> GetById<T>(string apiEndPoint,long id) where T: new()
        {
            try
            {
                var urlWithId = $"{apiEndPoint}?id={id}";
                var client = BuildHttpClient(urlWithId, ContenType.ApplicationJson);
                var response = await client.GetAsync(urlWithId);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<T>(jsonString);
                    return returnModel;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                //TODO LOG EXCEPTION
                return default(T);
            }

        }

        /// <summary>
        /// Create a new record
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<T> Post<T>(string apiEndPoint, T model)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync(apiEndPoint, model);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<T>(jsonString);
                    return returnModel;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                //TODO LOG EXCEPTION
                return default(T);
            }
        }


        /// <summary>
        /// Update Model with specific id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<T> Put<T>(string apiEndPoint, long id,T model)
        {
            try
            {
                var urlWithId = $"{apiEndPoint}?id={id}";
                var client = new HttpClient();
                var response = await client.PutAsJsonAsync(urlWithId, model);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var returnModel = JsonConvert.DeserializeObject<T>(jsonString);
                    return returnModel;
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                //TODO LOG EXCEPTION
                return default(T);
            }
        }

        /// <summary>
        /// Delete a record by id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<bool> Delete(string apiEndPoint, long id)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.DeleteAsync($"{apiEndPoint}?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //TODO LOG EXCEPTION
                return false;
            }
        }


        /// <summary>
        /// Build HttpClient with api endpoint and content type
        /// </summary>
        /// <param name="apiEndPoint"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        private static HttpClient BuildHttpClient(string apiEndPoint, string contentType)
        {
            var client = new HttpClient {BaseAddress = new Uri(apiEndPoint)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            return client;

        }



    }
}