using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiProxy.Model;
using WebApplication.Models;

namespace WebApplication.Code
{

    public static class ClientExtentionMethods
    {
        //Converting Client to ClientViewModel
        public static ClientViewModel ToClientViewModel(this Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                CompanyName=client.CompanyName,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email
            };
        }

        //Converting List of Client to List of ClientViewModel
        public static List<ClientViewModel> ToClientViewModel(this List<Client> clients)
        {
            return clients.Select(client => client.ToClientViewModel()).ToList();
        }
    }
}