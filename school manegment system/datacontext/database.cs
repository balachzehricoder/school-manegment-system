using Microsoft.EntityFrameworkCore;
using school_manegment_system.Models;

namespace school_manegment_system.datacontext
{
    public class database : DbContext
    {

        public database(DbContextOptions options) : base(options) { }


        public DbSet<school> school { get; set; }

        public DbSet<teacherslogin> teacherslogins { get; set; }

        public DbSet<adminlogin> adminlogin { get; set; }

    }
}
