using System.Data.Entity;
using xd.DAL.Context;
using xd.Interface;

namespace xd.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly XdContext _context;

        public UnitOfWork(XdContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
