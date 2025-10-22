using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Vatandas
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string AdSoyad { get; set; } = default!;
        public string Adres { get; set; } = default!;
        public DateOnly KayitZamani { get; init; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
