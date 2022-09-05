using Amirez.Infrastructure.Data.Model;
using Amirez.Infrastructure.Data.Model.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data
{
    [Table("History")]
    public class HistoryDataModel<T>: BaseDataModel
    {
        public Guid VersionId { get; set; }
        public T Version { get; set; }
        public DateTime Date { get; set; }
        public OperationsEnum Operation { get; set; }
        public T Parent { get; set; }
    }
}
