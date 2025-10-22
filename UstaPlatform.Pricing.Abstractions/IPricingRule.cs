using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Pricing.Abstractions
{
   public interface IPricingRule
    {
        // Her kural mevcut fiyata uygulanır ve yeni bir fiyat döner
        decimal Apply(decimal currentPrice, WorkOrder workOrder);

        // Kuralın adı (örneğin "LoyaltyDiscountRule")
        string Name { get; }
    }
}
