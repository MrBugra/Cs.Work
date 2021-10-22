using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Core.Models
{
    public class KeyValueModel<T>
    {
        public Guid Key { get; set; }
        public T Value { get; set; }
    }
}
