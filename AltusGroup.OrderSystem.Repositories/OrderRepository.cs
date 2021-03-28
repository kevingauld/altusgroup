#region Namespace imports

using System.Collections.Generic;
using System.Threading.Tasks;
using AltusGroup.OrderSystem.Data.Context;
using AltusGroup.OrderSystem.Entities;
using AltusGroup.OrderSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

#endregion

namespace AltusGroup.OrderSystem.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        #region ctor

        public OrderRepository(DbOrdersContext orderContext) : base(orderContext) { }

        #endregion

        public async Task<IEnumerable<Order>> FindAll()
        {
            return await _ordersContext.Orders.ToListAsync();
        }

        public async Task<Order> FindById(int id)
        {
            return await _ordersContext.Orders.FindAsync(id);
        }        
    }
}
