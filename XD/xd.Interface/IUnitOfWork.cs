using System;
namespace xd.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTypeRepository DbTypes { get; }
        int Commit();
    }
}
