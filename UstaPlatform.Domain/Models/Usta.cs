using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Domain.Models
{
    public class Usta
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string AdSoyad { get; set; } = default!;
        public string Uzmanlik { get; set; } = default!;
        public double Puan { get; set; }
        public int GunlukKapasite { get; set; } = 8;
        public Schedule Cizelge { get; } = new();
        public int AktifAtananIsSayisi => Cizelge.TotalWorkOrders;
    }
}
