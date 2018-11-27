using System.Security;
using xd.Model;
namespace xd.Interface
{
    public interface ICredentialsRepository : IRepository<Credentials>
    {
        bool IsCredentialValid(string username, SecureString password);
    }
}
                
