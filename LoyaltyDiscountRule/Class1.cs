using UstaPlatform.Domain.Models;
using UstaPlatform.Pricing.Abstractions;

namespace LoyaltyDiscountRule
{
    public class LoyaltyDiscountRule : IPricingRule
    {
        public string Name => "LoyaltyDiscountRule (%10 Sadakat İndirimi)";

        public decimal Apply(decimal currentPrice, WorkOrder workOrder)
        {
            // Basit örnek: Her müşteriye %10 indirim uygula
            return currentPrice * 0.9m;
        }
    }
}
