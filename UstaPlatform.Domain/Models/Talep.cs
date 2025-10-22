using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Talep
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Vatandas TalepEden { get; set; } = default!;
        public string IsTanimi { get; set; } = default!;
        public DateOnly IstekTarihi { get; set; }
        public bool Acil { get; set; } = false;
        public decimal BaslangicFiyati { get; set; } = 100m;
    }
}
