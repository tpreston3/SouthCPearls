using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SouthSea.Models;

namespace SouthSea.Models
{
    public class SouthSeaContext : DbContext
    {
        public SouthSeaContext (DbContextOptions<SouthSeaContext> options)
            : base(options)
        {
        }

        public DbSet<SouthSea.Models.Merchandise> Merchandise { get; set; }
        public DbSet<SouthSea.Models.GemStone> GemStone { get; set;  }
        public DbSet<SouthSea.Models.Customer> Customer { get; set; }
    }
}
