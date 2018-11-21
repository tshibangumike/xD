using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xd.Model;

namespace xd.DAL.Context
{
    public class XdContext : DbContext
    {
        public XdContext() : base("Name=xdContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<DbType> DbTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
