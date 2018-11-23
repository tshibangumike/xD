using xd.DAL.Context;
using xd.Interface;
using xd.Model;
using Xd.DAL;
namespace xd.DAL.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(XdContext context) : base(context)
        {
        }
        public XdContext XdContext
        {
            get { return Context as XdContext; }
        }
    }
}

