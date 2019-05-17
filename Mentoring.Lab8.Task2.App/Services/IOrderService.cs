using System;
using System.Collections.Generic;
using Mentoring.Lab8.Task2.App.Entities;
using Mentoring.Lab8.Task2.App.Models;

namespace Mentoring.Lab8.Task2.App.Services
{
    public interface IOrderService : IDisposable
    {
        IEnumerable<Order> GetOrders(OrderRequest request);
    }
}
