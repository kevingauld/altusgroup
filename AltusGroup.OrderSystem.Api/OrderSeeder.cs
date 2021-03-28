#region Namespace imports

using System;
using System.Collections.Generic;
using AltusGroup.OrderSystem.Data.Context;
using AltusGroup.OrderSystem.Entities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

#endregion

namespace AltusGroup.OrderSystem.Api
{
    public static class OrderSeeder
    {
        public static void Seed(string orderData, string orderItemData, IServiceProvider serviceProvider)
        {
            var orders = JsonConvert.DeserializeObject<List<Order>>(orderData);
            var orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(orderItemData);

            using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<DbOrdersContext>();

            context.Orders.AddRange(orders);
            context.OrderItems.AddRange(orderItems);

            context.SaveChanges();
        }
    }
}
