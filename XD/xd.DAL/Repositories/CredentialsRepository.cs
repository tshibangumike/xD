using xd.DAL.Context;
using xd.Interface;
using xd.Model;
using Xd.DAL;
using System.Linq;
using System.Security;
using System;

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

        public bool IsCredentialValid(string username, SecureString password)
        {
            return XdContext.Credentials.Any(x => x.Username == username && x.Password == password);
        }

        public AppUser GetAppUser(Guid id)
        {
            return XdContext.AppUsers.FirstOrDefault(x=>x.)
        }
    }
}
                
