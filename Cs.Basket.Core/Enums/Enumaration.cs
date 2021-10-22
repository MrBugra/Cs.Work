using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Core.Enums
{
    public abstract class Enumeration
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }
        private Enumeration()
        {
        }
        public override bool Equals(object obj)
        {
            if (obj == default(object))
            {
                return false;
            }

            return GetType() == obj.GetType() && Id.Equals(((Enumeration) obj).Id);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
