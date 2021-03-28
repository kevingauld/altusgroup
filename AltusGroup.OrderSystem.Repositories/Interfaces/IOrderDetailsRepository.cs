#region Namespace imports

using System.Collections.Generic;
using System.Threading.Tasks;
using AltusGroup.OrderSystem.Entities;

#endregion

namespace AltusGroup.OrderSystem.Repositories.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<IEnumerable<OrderItem>> FindByOrderId(int id);
    }
}
