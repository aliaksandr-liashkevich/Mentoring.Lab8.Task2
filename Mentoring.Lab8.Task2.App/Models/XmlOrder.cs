using System;
using System.Xml.Serialization;

namespace Mentoring.Lab8.Task2.App.Models
{
    [XmlRoot("Order")]
    public class XmlOrder
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
    }
}