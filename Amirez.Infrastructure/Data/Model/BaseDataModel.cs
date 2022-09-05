using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Data.Model
{
    /// <summary>
    /// Containes shared properties between all models
    /// </summary>
    public class BaseDataModel
    {
        /// <summary>
        /// Model Key
        /// </summary>
        public Guid Id { get; set; }
    }
}
