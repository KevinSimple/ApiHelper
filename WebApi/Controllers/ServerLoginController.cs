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
    public class ServerLoginController : ApiController
    {
        readonly ServerLogin[] _serverLogins = new ServerLogin[]
       {
            new ServerLogin { Id = 1, ServerUrl = "rdp://Server01",UserName = "User01",Password = "Password01",ClientId = 1},
           new ServerLogin { Id = 2, ServerUrl = "rdp://Server02",UserName = "User02",Password = "Password02",ClientId = 2},
            new ServerLogin { Id = 3, ServerUrl = "rdp://Server03",UserName = "User03",Password = "Password03",ClientId = 3},
             new ServerLogin { Id = 4, ServerUrl = "rdp://Server04",UserName = "User04",Password = "Password04",ClientId = 3},
       };
        
        /// <summary>
        /// Get Server Login by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get([FromUri]long id)
        {
            var serverLogin = _serverLogins.FirstOrDefault((p) => p.Id == id);
            if (serverLogin == null)
            {
                return NotFound();
            }
            return Ok(serverLogin);
        }

        /// <summary>
        /// Get Server Logins by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public IHttpActionResult GetClientName([FromUri]long clientId)
        {
            var serverLogins = _serverLogins.Where((x) => x.ClientId.Equals(clientId)).ToList();
            if (!serverLogins.Any())
            {
                return NotFound();
            }
            return Ok(serverLogins);
        }

        
        /// <summary>
        /// Get All the Server Logins
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAll()
        {
            return Ok(_serverLogins.ToList());
        }
        
        /// <summary>
        /// Create a new client
        /// </summary>
        public IHttpActionResult Post([FromBody]ServerLogin serverLogin)
        {
            var returnC = serverLogin;
            returnC.Id = 999;
           
            return Ok(returnC);
        }

        /// <summary>
        /// Update a Client Record
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult Put([FromUri]long id, [FromBody]ServerLogin serverLogin)
        {
            var returnC = serverLogin;
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
