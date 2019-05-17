using System.Collections.Generic;
using System.IO;
using Mentoring.Lab8.Task2.App.Entities;

namespace Mentoring.Lab8.Task2.App.Services
{
    public interface IDocumentService
    {
        void WriteDocument(IEnumerable<Order> orders, Stream stream);
    }
}
