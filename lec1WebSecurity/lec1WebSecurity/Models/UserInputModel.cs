using System.ComponentModel.DataAnnotations;

namespace lec1WebSecurity.Models
{
    public class UserInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        //[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Only alphanumeric characters are allowed.")]
        [NotAllowedWords(new string[] { "badword", "spam" })]

        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(18, 99)]
        public int Age { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [SecurePassword(8)]
        public string Password { get; set; }

    }

}
