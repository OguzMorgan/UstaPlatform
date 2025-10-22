using System;
using System.IO;
using System.Linq;
using UstaPlatform.Domain.Models;
using UstaPlatform.Infrastructure.Repositories;
using UstaPlatform.Infrastructure.Services;
using UstaPlatform.Pricing.Engine;

Console.WriteLine("=== UstaPlatform Başlatılıyor ===\n");

// 1️⃣ Demo verilerini oluştur
var vatandas = new Vatandas
{
    AdSoyad = "Ahmet Yılmaz",
    Adres = "Merkez Mah. No:1"
};

var usta1 = new Usta { AdSoyad = "Mehmet Usta", Uzmanlik = "Tesisat", Puan = 4.8 };
var usta2 = new Usta { AdSoyad = "Ali Usta", Uzmanlik = "Tesisat", Puan = 4.5 };

var talep = new Talep
{
    TalepEden = vatandas,
    IsTanimi = "Lavabo sızıntısı",
    IstekTarihi = DateOnly.FromDateTime(DateTime.UtcNow),
    BaslangicFiyati = 150m
};

// 2️⃣ Fiyat motorunu hazırla
var engine = new PricingEngine();

var exeFolder = AppContext.BaseDirectory;
var pluginsFolder = Path.Combine(exeFolder, "Plugins");

Console.WriteLine($"🔍 Plugin klasörü: {pluginsFolder}");
Directory.CreateDirectory(pluginsFolder);
engine.LoadRulesFromFolder(pluginsFolder);

Console.WriteLine($"📦 Yüklenen Kurallar: {string.Join(", ", engine.Rules.Select(r => r.Name))}\n");

// 3️⃣ Eşleştirme
var match = new MatchingService();
var chosenUsta = match.ChooseBestUsta(new[] { usta1, usta2 });

// 4️⃣ İş emri oluştur
var workOrder = new WorkOrder
{
    Talep = talep,
    AtananUsta = chosenUsta,
    BaslangicZamani = DateTime.UtcNow.AddDays(1)
};

// 5️⃣ Fiyat hesapla
workOrder.Fiyat = engine.CalculatePrice(talep.BaslangicFiyati, workOrder);

// 6️⃣ İş emrini kaydet
var repo = new InMemoryWorkOrderRepository();
repo.Add(workOrder);
chosenUsta.Cizelge.Add(workOrder);

// 7️⃣ Sonuçları yaz
Console.WriteLine("------ İŞ EMRİ OLUŞTURULDU ------");
Console.WriteLine($"Talep Eden: {vatandas.AdSoyad}");
Console.WriteLine($"İş: {talep.IsTanimi}");
Console.WriteLine($"Atanan Usta: {chosenUsta.AdSoyad}");
Console.WriteLine($"Temel Fiyat: {talep.BaslangicFiyati}");
Console.WriteLine($"Son Fiyat: {workOrder.Fiyat}");
Console.WriteLine($"Ustanın {DateOnly.FromDateTime(workOrder.BaslangicZamani)} tarihli iş sayısı: {chosenUsta.Cizelge[DateOnly.FromDateTime(workOrder.BaslangicZamani)].Count}");
Console.WriteLine("----------------------------------\n");
Console.WriteLine("✅ Demo tamamlandı!");

