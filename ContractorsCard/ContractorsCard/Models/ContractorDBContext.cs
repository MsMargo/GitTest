using ContractorsCard.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContractorsCard.Models
{
    public class ContractorDBContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }
    }
}