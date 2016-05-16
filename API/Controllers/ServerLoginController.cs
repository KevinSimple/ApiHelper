using System.Linq;
using ApiProxy.Model;
using Microsoft.AspNet.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ServerLoginController : Controller
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
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var serverLogin = _serverLogins.FirstOrDefault((p) => p.Id == id);
            if (serverLogin == null)
            {
                return HttpNotFound();
            }
            return Ok(serverLogin);
        }

        /// <summary>
        /// Get Server Logins by client id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetClientName(long clientId)
        {
            var serverLogins = _serverLogins.Where((x) => x.ClientId.Equals(clientId)).ToList();
            if (!serverLogins.Any())
            {
                return HttpNotFound();
            }
            return Ok(serverLogins);
        }

        
        /// <summary>
        /// Get All the Server Logins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serverLogins.ToList());
        }

        /// <summary>
        /// Create a new client
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]ServerLogin serverLogin)
        {
            var returnC = serverLogin;
            returnC.Id = 999;
           
            return Ok(returnC);
        }

        /// <summary>
        /// Update a Client Record
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]ServerLogin serverLogin)
        {
            var returnC = serverLogin;
            returnC.Id = 999;
            return Ok(returnC);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return Ok();
        }
    }
}
