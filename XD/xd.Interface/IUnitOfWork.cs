using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace xd.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IFieldRepository Fields { get; }
        int Complete();
    }
}
