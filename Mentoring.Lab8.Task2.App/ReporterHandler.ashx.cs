using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Mentoring.Lab8.Task2.App.Data;
using Mentoring.Lab8.Task2.App.Data.Repositories;
using Mentoring.Lab8.Task2.App.Entities;
using Mentoring.Lab8.Task2.App.Models;
using Mentoring.Lab8.Task2.App.Services;
using Newtonsoft.Json;

namespace Mentoring.Lab8.Task2.App
{
    public class ReporterHandler : IHttpHandler
    {
        public const string ExcelType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static readonly IEnumerable<string> XmlTypes = new List<string>
        {
            "text/xml",
            "application/xml"
        };

        public void ProcessRequest(HttpContext context)
        {
            var orderRequest = GetOrderRequest(context.Request);
            var documentType = GetDocumentType(context.Request);

            var orders = GetOrders(orderRequest);

            using (var memoryStream = new MemoryStream())
            {
                BuildDocument(orders, documentType, memoryStream);
                var buffer = memoryStream.ToArray();
                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            }

            context.Response.ContentType = GetContentType(documentType);
        }

        private string GetContentType(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.Excel:
                    return ExcelType;
                case DocumentType.Xml:
                    return XmlTypes.First();
                default:
                    throw new ArgumentException($"Document type: {documentType}. Type not found.", nameof(documentType));
            }
        }

        private void BuildDocument(IEnumerable<Order> orders, DocumentType documentType, Stream stream)
        {
            switch (documentType)
            {
                case DocumentType.Excel:
                {
                    var documentService = new ExcelDocumentService();
                    documentService.WriteDocument(orders, stream);
                    break;
                }
                case DocumentType.Xml:
                {
                    var documentService = new XmlDocumentService();
                    documentService.WriteDocument(orders, stream);
                    break;
                }
                default:
                    throw new ArgumentException($"Document type: {documentType}. Type not found.", nameof(documentType));
            }
        }

        private IEnumerable<Order> GetOrders(OrderRequest orderRequest)
        {
            using (var db = new NorthwindDbContext())
            {
                using (var orderRepository = new Repository<Order>(db))
                {
                    using (var service = new OrderService(orderRepository))
                    {
                        return service.GetOrders(orderRequest);
                    }
                }
            }
        }

        private DocumentType GetDocumentType(HttpRequest contextRequest)
        {
            var acceptTypes = contextRequest.AcceptTypes;

            if (acceptTypes != null)
            {
                foreach (var acceptType in acceptTypes)
                {
                    if (acceptType == ExcelType)
                    {
                        return DocumentType.Excel;
                    }

                    if (XmlTypes.Contains(acceptType))
                    {
                        return DocumentType.Xml;
                    }
                }
            }

            return DocumentType.Excel;
        }

        public OrderRequest GetOrderRequest(HttpRequest request)
        {
            string model;
            using (var requestStream = request.GetBufferedInputStream())
            {
                using (var reader = new StreamReader(requestStream))
                {
                    model = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<OrderRequest>(model);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}