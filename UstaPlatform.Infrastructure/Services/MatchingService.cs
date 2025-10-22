using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Infrastructure.Services
{
    public class MatchingService
    {
        // Basit algoritma: en az iş yüküne sahip ustayı seç
        public Usta ChooseBestUsta(IEnumerable<Usta> ustalar)
        {
            return ustalar.OrderBy(u => u.AktifAtananIsSayisi).First();
        }
    }
}
