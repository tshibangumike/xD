using System;
using System.Security;
namespace xd.Model
{
    public class Credentials
    {
        public Guid AppUserId { get; set; }
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
                
