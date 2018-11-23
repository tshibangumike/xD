using xd.DAL.Context;
using xd.Interface;
using xd.Model;
using Xd.DAL;
namespace xd.DAL.Repositories
{
    public class CredentialsRepository : Repository<Credentials>, ICredentialsRepository
    {
        public CredentialsRepository(XdContext context) : base(context)
        {
        }
        public XdContext XdContext
        {
            get { return Context as XdContext; }
        }
    }
}

