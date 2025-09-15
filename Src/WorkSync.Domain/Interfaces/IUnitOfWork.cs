using System;

namespace WorkSync.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
}
