using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.Basket.Core.Exceptions
{
    public class CsBusinessException : Exception
    {
        public CsBusinessException(string message):base(message)
        {

        }
    }
}
