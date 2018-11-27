using System;
using xd.DAL.Context;
using xd.Interface;
using xd.Model;
using Xd.DAL;
using System.Linq;
namespace xd.DAL.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(XdContext context) : base(context)
        {
        }
        public XdContext XdContext
        {
            get { return Context as XdContext; }
        }
        public AppUser GetAppUser(Guid id)
        {
            return XdContext.AppUsers.FirstOrDefault(x => x.Id == id);
        }
    }
}
                
