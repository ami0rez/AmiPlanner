using System;

namespace Amirez.AmipBackend.Controllers.Common.Models
{
    public class HistoryItemResponse<T>
    {
        public Guid Id { get; set; }
        public T Version { get; set; }
        public DateTime Date { get; set; }
    }
}
