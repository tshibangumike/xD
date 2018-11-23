using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using xd.Model;
namespace xd.DAL.Context
{
    public class XdContext : DbContext
    {
        public XdContext() : base("Name = xdContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<AddressInformation> AddressInformations { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoles { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Credentials> Credentials { get; set; }
        public virtual DbSet<DbType> DbTypes { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<EntityType> EntityTypes { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FieldRequirementLevel> FieldRequirementLevels { get; set; }
        public virtual DbSet<FieldType> FieldTypes { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormType> FormTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tab> Tabs { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<View> Views { get; set; }
        public virtual DbSet<ViewType> ViewTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}

