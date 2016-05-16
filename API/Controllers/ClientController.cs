using System.Linq;
using ApiProxy.Model;
using Microsoft.AspNet.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        readonly Client[] _clients = new ApiProxy.Model.Client[]
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
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var client = _clients.FirstOrDefault((p) => p.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return Ok(client);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        [HttpGet("{companyName}")]
        public IActionResult GetClientName(string companyName)
        {
            var clients = _clients.Where((p) => p.CompanyName.Contains(companyName)).ToList();
            if (!clients.Any())
            {
                return HttpNotFound();
            }
            return Ok(clients);
        }


        /// <summary>
        /// Get All Clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clients);
        }

        /// <summary>
        /// Create a new client
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody]Client client)
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
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]Client client)
        {
            var returnC = client;
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
