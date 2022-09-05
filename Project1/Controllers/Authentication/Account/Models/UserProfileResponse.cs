using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Authentication.Account.Models
{
    public class UserProfileResponse
    {
        public Guid Id { get; set; }
        public string Nom { set; get; }
        public string Prenom { set; get; }
        public bool Admin { set; get; }
        public string Email { set; get; }
        public string Login { set; get; }
    }
}
