using System.IO;
using System.Linq;
using Pluralize.NET;

namespace xd.CA.Manager
{
    class ModelManager
    {
        public static void CreateModels()
        {

            var xdContextContent = "";
            var iUnitOfWork = "";
            var unitOfWork1 = "";
            var unitOfWork2 = "";

            var models = new string[] {
                "AddressInformation",
                "AppUser",
                "AppUserRole",
                "Contact",
                "Credentials",
                "DbType",
                "Entity",
                "EntityType",
                "Field",
                "FieldRequirementLevel",
                "FieldType",
                "Form",
                "FormType",
                "Gender",
                "MaritalStatus",
                "MenuItem",
                "Role",
                "Tab",
                "Title",
                "View",
                "ViewType"
            };

            foreach (var model in models.OrderBy(x => x))
            {
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\" + model + ".cs"))
                {
                    var classContent = @"using System;
                namespace xd.Model
                {
                    public class " + model + @"
                    {
                        public int Id { get; set; }
                        public string Name { get; set; }
                    }
                }
                ";
                    writer.WriteLine(classContent);
                }
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.DAL\Repositories\" + model + "Repository.cs"))
                {
                    var classContent = @"using xd.DAL.Context;
                using xd.Interface;
                using xd.Model;
                using Xd.DAL;
                namespace xd.DAL.Repositories
                {
                    public class " + model + @"Repository : Repository<" + model + @">, I" + model + @"Repository
                    {
                        public " + model + @"Repository(XdContext context) : base(context)
                        {
                        }
                        public XdContext XdContext
                        {
                            get { return Context as XdContext; }
                        }
                    }
                }
                ";
                    writer.WriteLine(classContent);
                }
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Interface\I" + model + "Repository .cs"))
                {
                    var classContent = @"using xd.Model;
                namespace xd.Interface
                {
                    public interface I" + model + @"Repository : IRepository<" + model + @">
                    {
                    }
                }
                ";
                    writer.WriteLine(classContent);
                }

                xdContextContent += @"public virtual DbSet<" + model + "> " + new Pluralizer().Pluralize(model) + " { get; set; }" + System.Environment.NewLine;
                iUnitOfWork += @"I" + model + "Repository " + new Pluralizer().Pluralize(model) + " { get; }" + System.Environment.NewLine;
                unitOfWork1 += "public I" + model + "Repository " + new Pluralizer().Pluralize(model) + " { get; private set; }" + System.Environment.NewLine;
                unitOfWork2 += new Pluralizer().Pluralize(model) + " = new " + model + "Repository(_context);" + System.Environment.NewLine;
            }

            using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.DAL\XdContext.cs"))
            {
                xdContextContent = @"using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using xd.Model;
namespace xd.DAL.Context
{
    public class XdContext : DbContext
    {
        public XdContext() : base(""Name = xdContext"")
        {
                Configuration.LazyLoadingEnabled = false;
            }
        " + xdContextContent + @"
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
";
                writer.WriteLine(xdContextContent);
            }
            using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Interface\IUnitOfWork.cs"))
            {
                iUnitOfWork = @"using System;
namespace xd.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        " + iUnitOfWork + @"
        int Commit();
    }
}
";
                writer.WriteLine(iUnitOfWork);
            }
            using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.DAL\UnitOfWork.cs"))
            {
                var unitOfWork = @"using xd.DAL.Context;
using xd.DAL.Repositories;
using xd.Interface;
namespace xd.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly XdContext _context;

        public UnitOfWork(XdContext context)
        {
            _context = context;
            " + unitOfWork2 + @"
        }
        " + unitOfWork1 + @"
        public int Commit()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
";
                writer.WriteLine(unitOfWork);
            }

        }
        public static void InsertDbTypes()
        {
            //var uow = new UnitOfWork(new XdContext());
            //var dbType1 = new DbType()
            //{
            //    Name = "VARCHAR"
            //};
            //uow.DbTypes.Add(dbType1);
            //uow.Commit();
            //var dbtypes = uow.DbTypes.GetAll();
        }
    }
}
