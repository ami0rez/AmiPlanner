using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Authentication.Account.Models
{
    /// <summary>
    /// Query used to change connected user's password
    /// </summary>
    public class ChangerMotDePasseQuery
    {
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
