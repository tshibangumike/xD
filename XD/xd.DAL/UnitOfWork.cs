using xd.DAL.Context;
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
            DbTypes = new DbTypeRepository(_context);
        }
        public IDbTypeRepository DbTypes { get; private set; }
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
