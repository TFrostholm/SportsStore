using System.Collections.Generic;

namespace SportsStore.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order); 
    }
}