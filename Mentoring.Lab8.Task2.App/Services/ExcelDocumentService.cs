using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mentoring.Lab8.Task2.App.Entities;
using NPOI.XSSF.UserModel;

namespace Mentoring.Lab8.Task2.App.Services
{
    public class ExcelDocumentService : IDocumentService
    {
        public void WriteDocument(IEnumerable<Order> orders, Stream stream)
        {
            var workbook = new XSSFWorkbook();
            var ordersSheet = workbook.CreateSheet("Orders");

            if (orders.Any())
            {
                var orderPropertyRow = ordersSheet.CreateRow(0);
                orderPropertyRow.CreateCell(0).SetCellValue(nameof(Order.OrderId));
                orderPropertyRow.CreateCell(1).SetCellValue(nameof(Order.OrderDate));
                orderPropertyRow.CreateCell(2).SetCellValue(nameof(Customer.CustomerId));
                orderPropertyRow.CreateCell(3).SetCellValue(nameof(Customer.ContactName));

                var i = 1;
                foreach (var order in orders)
                {
                    var row = ordersSheet.CreateRow(i);
                    row.CreateCell(0).SetCellValue(order.OrderId);
                    row.CreateCell(1).SetCellValue(order.OrderDate?.ToLongDateString());
                    row.CreateCell(2).SetCellValue(order.CustomerId);
                    row.CreateCell(3).SetCellValue(order?.Customer?.ContactName);

                    i++;
                }
            }

            workbook.Write(stream);
        }
    }
}