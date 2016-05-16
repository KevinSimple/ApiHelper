using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApiProxy.Model;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        /// <summary>
        /// Get All Clients 
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetAllClient()
        {
            try
            {
            var clients = await Client.GetAll();
            return Json(clients, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                //TODO LOG EXCEPTION
                return Json(new List<Client>(), JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Create a new client 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CreateClient(Client model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Data save to database
                    var clientToCreate = await Client.Create(model);

                    if (clientToCreate != null)
                    {
                        var RedirectUrl = Url.Action("Index", "Home", new { area = "" });
                        return Json(new { success = true, redirectUrl = RedirectUrl });
                    }
                }
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });

            }
            catch (Exception)
            {
                //Need Log exception
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
        }

        /// <summary>
        /// Edit Client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> EditClient(Client model)
        {
            try
            {
                var id = model.Id;
                var updatedModel = await Client.Update(id, model);
                if (updatedModel != null)
                {
                    var RedirectUrl = Url.Action("Index", "Home", new { area = "" });
                    return Json(new { success = true, redirectUrl = RedirectUrl });
                }
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
            catch (Exception)
            {
                //TODO LOG EXCEPTION
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
        }

        /// <summary>
        /// Delete Client
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DeleteClient(Client model)
        {
            try
            {
                var id = model.Id;
                var updatedModel = await Client.Delete(id);
                if (updatedModel)
                {
                    var RedirectUrl = Url.Action("Index", "Home", new { area = "" });
                    return Json(new { success = true, redirectUrl = RedirectUrl });
                }
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
            catch (Exception)
            {
                //TODO NEED LOG EXCEPTION
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
                });
            }
        }
    }
}