using System.ComponentModel.DataAnnotations;

namespace ResurantApiCore6.Models.Dtos
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "نام کاربری اجباری است")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "ایمیل اجباری است")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "کلمه عبور اجباری است")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}