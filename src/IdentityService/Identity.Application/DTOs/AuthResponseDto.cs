namespace Identity.Application.DTOs
{
    public class AuthResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Expiry { get; set; }
    }
}
