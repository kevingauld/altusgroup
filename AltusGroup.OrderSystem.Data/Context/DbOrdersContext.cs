#region Namespace imports

using AltusGroup.OrderSystem.Entities;
using Microsoft.EntityFrameworkCore;

#endregion

namespace AltusGroup.OrderSystem.Data.Context
{
    public class DbOrdersContext : DbContext
    {

        #region ctor

        public DbOrdersContext(DbContextOptions options) : base(options)
        {
        }

        #endregion
              
        #region DbSets

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        #endregion
    }
}
