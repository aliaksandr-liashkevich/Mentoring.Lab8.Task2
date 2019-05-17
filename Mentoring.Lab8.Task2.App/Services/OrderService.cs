using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Mentoring.Lab8.Task2.App.Data.Repositories;
using Mentoring.Lab8.Task2.App.Entities;
using Mentoring.Lab8.Task2.App.Models;

namespace Mentoring.Lab8.Task2.App.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders(OrderRequest request)
        {
            var orders = _orderRepository.GetMany()
                .Include(o => o.Customer);

            if (!string.IsNullOrEmpty(request.CustomerId))
            {
                orders = orders.Where(o => o.CustomerId == request.CustomerId);
            }

            if (request.DateFrom.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.HasValue && o.OrderDate >= request.DateFrom.Value);
            }

            if (request.DateTo.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.HasValue && o.OrderDate <= request.DateTo.Value);
            }

            orders = orders.OrderBy(o => o.OrderId);

            if (request.Skip.HasValue)
            {
                orders = orders.Skip(request.Skip.Value);
            }

            if (request.Take.HasValue)
            {
                orders = orders.Take(request.Take.Value);
            }

            return orders.ToList();
        }

        public void Dispose()
        {
            _orderRepository?.Dispose();
        }
    }
}