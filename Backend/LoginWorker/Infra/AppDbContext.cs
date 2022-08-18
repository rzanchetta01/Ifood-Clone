using LoginWorker.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWorker.Infra
{
    internal class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<UserLogin>? UserLogins { get; set; }
    }
}
