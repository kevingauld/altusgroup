#region Namespace imports

using System.ComponentModel.DataAnnotations;

#endregion

namespace AltusGroup.OrderSystem.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Amount { get; set; }
        public string Color { get; set; }

    }
}
