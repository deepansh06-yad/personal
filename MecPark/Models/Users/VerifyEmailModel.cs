using System.ComponentModel.DataAnnotations;

namespace Models.Users
{
    public class VerifyEmailModel
    {
        [Required]
        public string Token { get; set; }
    }
}
