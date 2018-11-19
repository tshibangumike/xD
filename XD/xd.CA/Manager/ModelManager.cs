using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace xd.CA.Manager
{
    class ModelManager
    {
        public static void CreateModels()
        {

            #region Base Domain
            using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\Domain\BaseDomain.cs"))
            {
                var content = @"using System;
                                namespace xd.Model
                                {
                                    public class BaseDomain
                                    {
                                        public Guid Id { get; set; }
                                        public string Name { get; set; }
                                        public DateTime CreatedOn { get; set; }
                                        public Guid CreatedById { get; set; }
                                        public Guid ModifiedById { get; set; }
                                        public DateTime ModifiedOn { get; set; }
                                    }
                                }";
                writer.WriteLine(content);
            }
            #endregion

            #region Base Type Domain
            using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\Domain\BaseTypeDomain.cs"))
            {
                var content = @"using System;
                                namespace xd.Model
                                {
                                    public class BaseTypeDomain
                                    {
                                        public int Id { get; set; }
                                        public string Name { get; set; }
                                        public string Description { get; set; }
                                    }
                                }";
                writer.WriteLine(content);
            }
            #endregion

            var models = new string[] {
                "Entity",
                "Field",
                "Form",
                "View",
                "Role"
            };
            foreach (var model in models)
            {
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\Domain\" + model + ".cs"))
                {
                    var classContent = @"using System;
                                    using System.Collections.Generic;
                                    namespace xd.Model
                                    {
                                        public partial class " + model + @" : BaseDomain
                                        {
                                        }
                                    }";
                    writer.WriteLine(classContent);
                }
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.DAL\Repositories\" + model + ".cs"))
                {
                    var classContent = @"namespace Xd.DAL.Repositories
{
    public class " + model + @" : Repository<" + model + @">, I" + model + @"Repository
	{
        public " + model + @"(XdContext context)
			: base(context)
		{
		}

    }
}
";
                    writer.WriteLine(classContent);
                }
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Interface\" + model + ".cs"))
                {
                    var classContent = @"
namespace xd.Interface
{
    public interface I" + model + @"Repository : IRepository<" + model + @">
    {
    }
}
";
                    writer.WriteLine(classContent);
                }
            }

            models = new string[] {
                "DbType",
                "FieldType",
                "FieldRequirementLevel",
                "FormType",
                "ViewType"
            };
            foreach (var model in models)
            {
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\Domain\" + model + @".cs"))
                {
                    var classContent = @"using System;
                                    using System.Collections.Generic;
                                    namespace xd.Model
                                    {
                                        public partial class " + model + @" : BaseTypeDomain
                                        {
                                        }
                                    }";
                    writer.WriteLine(classContent);
                }
            }

            models = new string[] {
                "Tab",
                "Column",
                "Section",
                "SectionField",
                "ViewColumn",
                "OrderByType",
                "ViewColumn",
                "ViewColumn",
                "ViewColumn"
            };
            foreach (var model in models)
            {
                using (StreamWriter writer = new StreamWriter(@"D:\_PRSNL\Git\Repo\xD\XD\xd.Model\Domain\" + model + @".cs"))
                {
                    var classContent = @"using System;
                                        namespace xd.Model
                                        {
                                            public class " + model + @"
                                            {
                                                public int Id { get; set; }
                                                public string Name { get; set; }
                                            }
                                        }";
                    writer.WriteLine(classContent);
                }
            }

        }
    }
}
