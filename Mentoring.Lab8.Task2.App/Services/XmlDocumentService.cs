using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Mentoring.Lab8.Task2.App.Entities;
using Mentoring.Lab8.Task2.App.Models;

namespace Mentoring.Lab8.Task2.App.Services
{
    public class XmlDocumentService : IDocumentService
    {
        public void WriteDocument(IEnumerable<Order> orders, Stream stream)
        {
            var xmlReport = new XmlReport
            {
                XmlOrders = orders.Select(o => new XmlOrder
                    {
                        OrderId = o.OrderId,
                        CustomerId = o.CustomerId,
                        OrderDate = o.OrderDate,
                        ContactName = o?.Customer.ContactName
                    })
                    .ToList()
            };

            var serializer = new XmlSerializer(typeof(XmlReport));
            serializer.Serialize(stream, xmlReport);
        }
    }
}