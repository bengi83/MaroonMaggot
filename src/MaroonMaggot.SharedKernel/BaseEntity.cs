using System;
using System.Collections.Generic;

namespace MaroonMaggot.SharedKernel
{
    public abstract class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
        public List<BaseDomainEvent> Events = new();
    }
}