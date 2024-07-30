namespace medic_api.Models.DTOs
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
