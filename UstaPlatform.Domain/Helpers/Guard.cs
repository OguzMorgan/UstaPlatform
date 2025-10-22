using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Helpers
{
    public static class Guard
    {
        // Bir nesne null ise uyarı fırlatır
        public static void AgainstNull(object? obj, string name)
        {
            if (obj is null)
                throw new ArgumentNullException(name);
        }

        // Belirli bir koşul sağlanırsa uyarı fırlatır
        public static void Against(bool condition, string message)
        {
            if (condition)
                throw new InvalidOperationException(message);
        }
    }
}
