using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Common.Configuration
{
    public class AppSettings : Involys.Common.Configuration.AppSettings
    {
        public JwtSettings JwtSettings { get; set; }
    }
}
