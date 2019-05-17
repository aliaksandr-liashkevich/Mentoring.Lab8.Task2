using System;

namespace Mentoring.Lab8.Task2.App.Models
{
    public class OrderRequest
    {
        public string CustomerId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}