using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Authentication
{
    /// <summary>
    /// Role model
    /// </summary>
    [Table("role")]
    public class RoleDataModel : IdentityRole<Guid>
    {
        public Roles RoleType { get; set; }
    }
}
