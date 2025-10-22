using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Infrastructure.Repositories
{
    public class InMemoryWorkOrderRepository : IWorkOrderRepository
    {
        private readonly List<WorkOrder> _items = new();

        public void Add(WorkOrder wo)
        {
            _items.Add(wo);
        }

        public WorkOrder? Get(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetAll()
        {
            return _items;
        }
    }
}
