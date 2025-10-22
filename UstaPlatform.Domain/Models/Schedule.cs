using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
    public class Schedule
    {
        private readonly Dictionary<DateOnly, List<WorkOrder>> _byDate = new();

        public List<WorkOrder> this[DateOnly day]
        {
            get
            {
                if (!_byDate.TryGetValue(day, out var list))
                {
                    list = new List<WorkOrder>();
                    _byDate[day] = list;
                }
                return list;
            }
        }

        public void Add(WorkOrder wo)
        {
            var day = DateOnly.FromDateTime(wo.BaslangicZamani);
            this[day].Add(wo);
        }

        public int TotalWorkOrders => _byDate.Values.Sum(l => l.Count);
    }
}
