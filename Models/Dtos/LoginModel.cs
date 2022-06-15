using System.ComponentModel.DataAnnotations;

namespace ResurantApiCore6.Models.Dtos
{
    public class LoginModel
    {
        [Required(ErrorMessage = "نام کاربری اجباری است")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "کلمه عبور اجباری است")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}