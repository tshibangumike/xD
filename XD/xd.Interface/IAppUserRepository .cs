using System;
using xd.Model;
namespace xd.Interface
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        AppUser GetAppUser(Guid id);
    }
}
                
