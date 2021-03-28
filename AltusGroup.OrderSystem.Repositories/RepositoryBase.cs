#region Namespace imports

using System.Threading.Tasks;
using AltusGroup.OrderSystem.Data.Context;
using AltusGroup.OrderSystem.Repositories.Interfaces;

#endregion

namespace AltusGroup.OrderSystem.Repositories
{
    public abstract class RepositoryBase
    {
        protected DbOrdersContext _ordersContext;

        #region ctor

        public RepositoryBase(DbOrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        #endregion
    }
}
