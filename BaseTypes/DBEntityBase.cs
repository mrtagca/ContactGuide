using System;

namespace BaseTypes
{
    public abstract class DBEntityBase : IDisposable
    {
        public DBEntityBase()
        {
            
        }

        public Guid Id { get; set; }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
