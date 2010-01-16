using System;
using UnitTestingExamples.Models;

namespace UnitTestingExamples.Services
{
    public class Repository<TEntity> : IRepository, IRepository<TEntity>
        where TEntity : PersistentObject
    {
        public TEntity GetById(Guid id)
        {
            return default(TEntity);
        }

        PersistentObject IRepository.GetById(Guid id)
        {
            return GetById(id);
        }
    }
}