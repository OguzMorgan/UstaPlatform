UstaPlatform Projesi

Bu proje, nesne yönelimli programlama (OOP) ve katmanlı mimari ilkelerini göstermek amacıyla hazırlanmıştır.
Sistem, vatandaşların usta çağırabildiği, ustaların iş emirlerini aldığı ve fiyatlamanın dinamik kurallarla belirlendiği bir yapıdadır.

Amaç

Bu projenin amacı, yazılım mimarisinde katmanlı yapı ve SOLID prensiplerini uygulamaktır.
Özellikle Açık/Kapalı Prensibi (Open/Closed Principle - OCP) uygulama içerisinde gösterilmiştir.

Katmanlar
1. UstaPlatform.Domain

Bu katman sistemin temel model sınıflarını içerir.

Usta.cs: Usta bilgilerini ve çizelgesini tutar.

Vatandas.cs: Sistemi kullanan kişiyi temsil eder.

Talep.cs: Vatandaşın oluşturduğu iş talebini ifade eder.

WorkOrder.cs: Oluşturulan iş emrini temsil eder.

Route.cs: Özel IEnumerable koleksiyonu örneğidir.

Schedule.cs: Indexer örneğidir.

Helpers (Guard, GeoHelper, MoneyFormatter): Yardımcı sınıflardır.

Bu katman sadece modellerden oluşur ve hiçbir başka katmana bağımlı değildir.

2. UstaPlatform.Pricing.Abstractions

Bu katmanda fiyatlama kuralları için arayüz tanımlanmıştır:

public interface IPricingRule
{
    decimal Apply(decimal currentPrice, WorkOrder workOrder);
    string Name { get; }
}


Bu yapı sayesinde yeni bir fiyatlama kuralı eklemek için sadece bu arayüzü uygulayan bir sınıf yazmak yeterlidir.
Uygulama yeniden derlenmeden yeni kurallar DLL olarak eklenebilir.

3. UstaPlatform.Pricing.Engine

Bu katman fiyat motorudur.
Verilen klasördeki .dll dosyalarını tarar, içinde IPricingRule uygulayan sınıfları bulur ve çalıştırır.
Tüm kuralları sırayla uygulayarak son fiyatı hesaplar.

Bu sayede Açık/Kapalı Prensibi sağlanmıştır. Yeni kural eklenmek istendiğinde sistemin mevcut koduna dokunulmaz, sadece yeni bir DLL eklenir.

4. UstaPlatform.Infrastructure

Bu katmanda veri erişimi ve iş mantığı yer alır.

Repositories: InMemoryWorkOrderRepository sınıfı bellekte veri tutar.

Services: MatchingService sınıfı uygun ustayı seçer (en az iş yüküne sahip olan).

Bu katman Domain’e bağımlıdır. Bağımlılıkların Tersine Çevrilmesi (DIP) burada uygulanmıştır.

5. UstaPlatform.App

Bu katman uygulamanın çalıştırıldığı yerdir.
Konsol arayüzünde sistemin akışı şu şekildedir:

Vatandaş ve usta nesneleri oluşturulur.

Talep hazırlanır.

PricingEngine çalıştırılır ve Plugins klasöründen kurallar yüklenir.

MatchingService ile uygun usta seçilir.

WorkOrder oluşturulur, fiyat hesaplanır ve çizelgeye eklenir.

Sonuçlar ekrana yazdırılır.

6. Plugins (Eklentiler)

Plugins klasörü, fiyatlama kurallarının dinamik olarak eklendiği yerdir.

Örnek olarak iki kural hazırlanmıştır:

LoyaltyDiscountRule.dll → %10 indirim uygular.

WeekendPriceIncreaseRule.dll → Hafta sonu için %20 zam uygular.

Bu DLL dosyaları Plugins klasörüne kopyalandığında uygulama otomatik olarak bunları yükler ve çalıştırır.

Sonuç

Bu proje, katmanlı mimari, SOLID prensipleri ve plugin temelli esnek bir yapı örneği sunmaktadır.
Sisteme yeni fiyatlama kuralları eklemek için sadece yeni bir DLL eklemek yeterlidir.
Bu sayede kodun genişletilebilirliği ve sürdürülebilirliği artırılmıştır.