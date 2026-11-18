using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class LegacyPayPalClient
    {
        public bool MakePayment(double amountInUsd)
        {
            if (amountInUsd <= 1000)   
                return true;
            return false;            
        }
    }
}
