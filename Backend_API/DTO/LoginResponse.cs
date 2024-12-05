namespace Backend_API.DTO
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public required string Token { get; set; }
        
    }
}
