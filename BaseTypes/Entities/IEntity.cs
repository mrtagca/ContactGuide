using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Entities
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
    }
}
