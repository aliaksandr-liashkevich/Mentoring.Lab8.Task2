using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mentoring.Lab8.Task2.App.Models
{
    [XmlRoot("OrdersReport")]
    public class XmlReport
    {
        public List<XmlOrder> XmlOrders { get; set; }
    }
}