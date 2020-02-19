using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AirportService.Models
{
    public class DbTestContext : DbContext
    {
        public DbTestContext() : base("DbConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
