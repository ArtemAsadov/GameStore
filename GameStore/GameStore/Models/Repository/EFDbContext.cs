using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStore.Models.Repository
{
    public class EFDbContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
    }
}