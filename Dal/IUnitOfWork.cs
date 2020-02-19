
using System;

namespace Dal
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
    }
}
