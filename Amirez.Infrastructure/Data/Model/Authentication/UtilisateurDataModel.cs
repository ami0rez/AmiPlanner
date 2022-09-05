using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Authentication
{
    /// <summary>
    /// Utilisateur model
    /// </summary>
    [Table("utilisateur")]
    public class UtilisateurDataModel : IdentityUser<Guid>
    {
        [StringLength(250)]
        public string Nom { get; set; }
        [StringLength(250)]
        public string Prenom { get; set; }
        public bool Bloque { get; set; }
        public Guid RoleId { get; set; }
        public RoleDataModel Role { get; set; }
    }
}
