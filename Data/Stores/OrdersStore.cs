using Data.Entities;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Stores
{
    public class OrdersStore
    {
        private List<Order> orders;
        public IEnumerable<Order> Orders => orders;

        private readonly IOrderService orderService;

        private readonly Lazy<Task> InitializeLazy;

        public OrdersStore(IOrderService orderService)
        {
            this.orderService = orderService;
            orders = new List<Order>();
            InitializeLazy = new Lazy<Task>(Initialize);
        }

        public async Task AddOrder(Order order)
        {
            await orderService.CreateAsync(order);

            orders.Add(order);
        }

        internal void Update(Order order)
        {
            orderService.UpdateAsync(order);
        }

        public async Task RemoveOrder(Order order)
        {
            await orderService.DeleteAsync(order);

            orders.Remove(order);
        }

        public async Task LoadOrders()
        {
            await InitializeLazy.Value;
        }

        private async Task Initialize()
        {
            ICollection<Order> orders = await orderService.GetAllAsync();

            this.orders.Clear();
            this.orders.AddRange(orders);
        }
    }
}
