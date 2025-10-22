using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Helpers
{
    public static class MoneyFormatter
    {
        
        public static string Format(decimal amount)
        {
            return string.Format("{0:C}", amount);
        }
    }
}
