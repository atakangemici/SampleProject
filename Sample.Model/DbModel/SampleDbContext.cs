using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model.DbModel
{
    public class SampleDbContext : DbContext
    {
        static SampleDbContext()
        {
            Database.SetInitializer<SampleDbContext>(null);
        }

        public SampleDbContext() : base("Name=myConnectionString")
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
