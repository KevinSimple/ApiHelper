using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ApiProxy.Model;

namespace WebApi.Models
{
    public class ClientContext: DbContext
    {
        public DbSet<Client> Clients;

      
    }
}