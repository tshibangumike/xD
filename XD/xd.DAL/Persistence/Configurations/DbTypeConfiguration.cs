using System.Data.Entity.ModelConfiguration;
using xd.Model;

namespace xd.DAL.Persistence.Configurations
{
    public class DbTypeConfiguration : EntityTypeConfiguration<DbType>
    {
        public DbTypeConfiguration()
        {
            ToTable("DbType");
            HasKey(x => x.Id);
            Property(x => x.Id);
            Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);
        }
    }
}
