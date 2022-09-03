using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes
{
    public class UpdatableDBEntity : DBEntityBase
    {
        public UpdatableDBEntity()
        {

        }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
