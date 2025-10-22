using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UstaPlatform.Domain.Models;

namespace UstaPlatform.Infrastructure.Repositories
{
    public interface IWorkOrderRepository
    {
        void Add(WorkOrder wo);
        WorkOrder? Get(Guid id);
        IEnumerable<WorkOrder> GetAll();
    }
}
