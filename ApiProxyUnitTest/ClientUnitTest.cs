using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiProxyUnitTest
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public async Task GetAllTestMethod()
        {
            var clients =await Client.GetAll();
            
            Assert.IsNotNull(clients);
            Assert.IsInstanceOfType(clients,typeof(List<Client>));

        }

        [TestMethod]
        public async Task GeneralTest()
        {
            var newRecord = new Client
            {
                CompanyName = "new add company",
                Email = "newemail@sdf.com",
                FirstName = "Kevin",
                LastName = "ww"
            };

            var firstRecord = await Client.GetClientById(1);

            var updatedfirstRecord = await Client.Update(1, newRecord);

            var createdRecord = await Client.Create(newRecord);

            var deleted = await Client.Delete(1);

            Assert.IsInstanceOfType(firstRecord, typeof(Client));
            Assert.IsInstanceOfType(updatedfirstRecord, typeof(Client));
            Assert.IsInstanceOfType(createdRecord, typeof(Client));
            Assert.AreEqual(createdRecord.Email,createdRecord.Email);
            Assert.AreEqual(updatedfirstRecord.Email, newRecord.Email);
            Assert.IsTrue(deleted);

        }
    }
}
