using System;
using System.Net;
using System.Threading.Tasks;

namespace ApiHelper.Shared
{
    public class ModelBaseClass
    {
        #region member vairable 

        //The primary key in db for the record
        public long Id { get; set; }

        #endregion 


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        //public async Task<T> Post<T>(string apiEndPoint, T model)
        //{
        //    var client = new HttpClient();
        //   var  response = await client.PostAsJsonAsync("api/products", model);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Get the URI of the created resource.
        //        Uri gizmoUrl = response.Headers.Location;
        //    }

        //    return T;
        //}

    }
}