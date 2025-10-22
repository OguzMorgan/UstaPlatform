using UstaPlatform.Domain.Models;
using UstaPlatform.Pricing.Abstractions;

namespace WeekendPriceIncreaseRule
{
    public class WeekendPriceIncreaseRule : IPricingRule
    {
        public string Name => "WeekendPriceIncreaseRule (%20 Hafta Sonu Zammı)";

        public decimal Apply(decimal currentPrice, WorkOrder workOrder)
        {
            var day = workOrder.BaslangicZamani.DayOfWeek;
            if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            {
                // Hafta sonu için %20 zam uygula
                return currentPrice * 1.2m;
            }
            return currentPrice;
        }
    }
}
