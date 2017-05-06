using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.Models.Information;

namespace WorldAttractions.DAL.Models.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Skype { get; set; }
        public Enums.Genders Gender { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
