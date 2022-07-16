using Microsoft.EntityFrameworkCore;
using BloodBanK.Models;

namespace BloodBanK.Models
{
    public class BBMSContext:DbContext
    {
        public BBMSContext()
        {
                
        }

        public BBMSContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("dbconn"));

            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-NDS1S0S\\SQLEXPRESS;Initial Catalog=BBMS;Integrated Security=true;");

        }

        public DbSet<User> users { get; set; }
        public DbSet<BloodReq> Reqs { get; set; }
        

    }
}
