using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAppInfrastructure.Data.ApplicationContext
{
    public class MyContextApp:IdentityDbContext
    {
        public MyContextApp(DbContextOptions options):base(options)
        {

        }

        public DbSet<AppUser> AppUserTable { get; set; }

    }
}
