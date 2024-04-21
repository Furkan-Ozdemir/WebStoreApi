using System.ComponentModel.DataAnnotations;

namespace WebStoreApi.Models
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage="Please Provide your lastname")]
        public string LastName { get; set; } = string.Empty;

        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MinLength(5,ErrorMessage ="The address should be at least 5 chars")]
        [MaxLength(1000, ErrorMessage = "The address should be at less than 1000 chars")]
        public string Address { get; set; } = string.Empty;
    }
}
