using System.ComponentModel.DataAnnotations;

namespace medic_api.Models.DTOs
{
    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public int Orders { get; set; } 
        public string ImageURL { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
    }
}
