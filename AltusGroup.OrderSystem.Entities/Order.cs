#region Namespace imports

using System;
using System.ComponentModel.DataAnnotations;

#endregion

namespace AltusGroup.OrderSystem.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
