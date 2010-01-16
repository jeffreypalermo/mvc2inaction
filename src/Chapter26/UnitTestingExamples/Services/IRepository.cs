using System;
using UnitTestingExamples.Models;

namespace UnitTestingExamples.Services
{
    public interface IRepository
    {
        PersistentObject GetById(Guid id);
    }

    public interface IRepository<TEntity>
        where TEntity : PersistentObject
    {
        TEntity GetById(Guid id);
    }
}