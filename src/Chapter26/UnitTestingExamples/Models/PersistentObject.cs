using System;

namespace UnitTestingExamples.Models
{
    public abstract class PersistentObject
    {
        public virtual Guid Id { get; set; }
    }
}