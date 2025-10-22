using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public  class WorkOrder
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Talep Talep { get; set; } = default!;
        public Usta AtananUsta { get; set; } = default!;
        public decimal Fiyat { get; set; }
        public DateTime BaslangicZamani { get; set; }
        public (int X, int Y)? RotaKonumu { get; set; }
    }
}
