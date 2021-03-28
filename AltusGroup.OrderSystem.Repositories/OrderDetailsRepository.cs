#region Namespace imports

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltusGroup.OrderSystem.Data.Context;
using AltusGroup.OrderSystem.Entities;
using AltusGroup.OrderSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion


namespace AltusGroup.OrderSystem.Repositories
{
    public class OrderDetailsRepository : RepositoryBase, IOrderDetailsRepository
    {
        #region ctor

        public OrderDetailsRepository(DbOrdersContext orderContext) : base(orderContext) { }

        #endregion

        public async Task<IEnumerable<OrderItem>> FindByOrderId(int id)
        {
            return await _ordersContext.OrderItems
                .Where(x => x.OrderId == id)
                .OrderBy(x => x.ProductName)
                .ToListAsync();
        }
    }
}
