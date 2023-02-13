using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinTicker.Core
{
    public abstract class EntityBase<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public abstract class EntityBase : EntityBase<int>
    {
    }
}
