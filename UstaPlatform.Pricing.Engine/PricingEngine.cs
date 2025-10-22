using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Loader;
using UstaPlatform.Pricing.Abstractions;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Pricing.Engine
{
    public class PricingEngine
    {
        private readonly List<IPricingRule> _rules = new();

        public IReadOnlyList<IPricingRule> Rules => _rules;

        // 1️⃣ Klasördeki DLL dosyalarını tarayıp IPricingRule implementasyonlarını yükler
        public void LoadRulesFromFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath)) return;

            var dlls = Directory.GetFiles(folderPath, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (var dll in dlls)
            {
                try
                {
                    var asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(dll));
                    var types = asm.GetTypes()
                        .Where(t => typeof(IPricingRule).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    foreach (var type in types)
                    {
                        if (Activator.CreateInstance(type) is IPricingRule rule)
                        {
                            _rules.Add(rule);
                            Console.WriteLine($"✅ Kural yüklendi: {rule.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Plugin yüklenirken hata oluştu: {dll} -> {ex.Message}");
                }
            }
        }

        // 2️⃣ Kuralları sırayla uygular
        public decimal CalculatePrice(decimal basePrice, WorkOrder workOrder)
        {
            decimal price = basePrice;

            foreach (var rule in _rules)
            {
                price = rule.Apply(price, workOrder);
            }

            return price;
        }
    }
}
