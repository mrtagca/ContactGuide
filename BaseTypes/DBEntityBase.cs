using System;

namespace BaseTypes
{
    public class DBEntityBase : IDisposable
    {
        public DBEntityBase()
        {

        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
