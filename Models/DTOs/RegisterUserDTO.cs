namespace medic_api.Models.DTOs
{
    public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public int Orders { get; set; } 
        public string ImageURL { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
