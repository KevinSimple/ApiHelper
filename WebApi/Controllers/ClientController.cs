using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ApiProxy.Model;

namespace WebApi.Controllers
{
    public class ClientController : ApiController
    {
        readonly Client[] _clients = new Client[]
       {
            new Client { Id = 1, FirstName = "Kevin", LastName = "Wang", CompanyName = "CompanyOne",Email="Kevin.wang@test.com"},
            new Client { Id = 2, FirstName = "Joe", LastName = "Left", CompanyName = "CompanyTwo",Email="Joe@test.com"},
           new Client { Id = 3, FirstName = "Anil", LastName = "Parak", CompanyName = "CompanyThree",Email="Anil@test.com"},
       };
        
        /// <summary>
        /// Get Client by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get([FromUri]long id)
        {
            var client = _clients.FirstOrDefault((p) => p.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public IHttpActionResult GetClientName([FromUri]string companyName)
        {
            var clients = _clients.Where((p) => p.CompanyName.Contains(companyName)).ToList();
            if (!clients.Any())
            {
                return NotFound();
            }
            return Ok(clients);
        }

        
        /// <summary>
        /// Get All Clients
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            return Ok(_clients);
        }
        
        /// <summary>
        /// Create a new client
        /// </summary>
        public IHttpActionResult Post([FromBody]Client client)
        {
            var returnC = client;
            returnC.Id = 999;
            return Ok(returnC);
        }

        /// <summary>
        /// Update a Client Record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="client"></param>
        public IHttpActionResult Put([FromUri]long id, [FromBody]Client client)
        {
            var returnC = client;
            returnC.Id = 999;
            return Ok(returnC);
        }

        // DELETE: api/Client/5
        public IHttpActionResult Delete([FromUri]long id)
        {
            return Ok();
        }
    }
}
