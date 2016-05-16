using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProxy.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiProxyUnitTest
{
    [TestClass]
    public class ServerLoginUnitTest
    {
        [TestMethod]
        public async Task GetAllTestMethod()
        {
            var logins = await ServerLogin.GetAll();

            Assert.IsNotNull(logins);
            Assert.IsInstanceOfType(logins, typeof(List<ServerLogin>));

        }

        [TestMethod]
        public async Task GetByIdTestMethod()
        {
            var login = await ServerLogin.GetServerLoginById(1);

            Assert.IsNotNull(login);
            Assert.IsInstanceOfType(login, typeof(ServerLogin));

        }
        [TestMethod]
        public async Task CreateTestMethod()
        {
            var objectToCreate = new ServerLogin
            {
                UserName = "CreatedUser",
                Password = "CreatedPass",
                ClientId = 111,
            };

            var login = await ServerLogin.Create(objectToCreate);
            Assert.IsNotNull(login);
            Assert.AreEqual(login.UserName, objectToCreate.UserName);
            Assert.IsInstanceOfType(login, typeof(ServerLogin));

        }


        [TestMethod]
        public async Task UpdateTestMethod()
        {
            var objectToUpdate = new ServerLogin
            {
                UserName = "UpdateUser",
                Password = "UpdatePass",
                ClientId = 222,
            };

            var login = await ServerLogin.Update(1, objectToUpdate);
            Assert.IsNotNull(login);
            Assert.AreEqual(login.ClientId, objectToUpdate.ClientId);
            Assert.IsInstanceOfType(login, typeof(ServerLogin));

        }
        
        [TestMethod]
        public async Task DeleteTestMethod()
        {

            var login = await ServerLogin.Delete(1);
            Assert.IsTrue(login);

        }
    }
}
