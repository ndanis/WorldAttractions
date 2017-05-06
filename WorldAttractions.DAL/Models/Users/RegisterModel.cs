using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.Models.Information;

namespace WorldAttractions.DAL.Models.Users
{
    public class RegisterModel // Класс который мы используем при регистрации
    {

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
      ErrorMessage = "Некорректный Email")]
        [Required(ErrorMessage = "Заполните поле")]
        [System.Web.Mvc.Remote("CheckEmail", "Validation", ErrorMessage = "Пользователь с таким Email зарегистрирован")]
        public string Email { get; set; }
        [Required(ErrorMessage="Заполните поле")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Телефон должен быть")]
        [MaxLength(13, ErrorMessage = "Телефон должен быть не более 13 цифр")]
        [MinLength(6, ErrorMessage = "Телефон должен быть не менее 6 цифр")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Скайп должен быть")]
        public string Skype { get; set; }
        [Required]
        public Enums.Genders Gender { get; set; }
    }
}
