using System.ComponentModel.DataAnnotations;

namespace medic_api.Models.DTOs
{
    public class UsersDetailsDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Username { get; set; } = null!;

        public int? Orders { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string? ImageUrl { get; set; }

        public string? Status { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
