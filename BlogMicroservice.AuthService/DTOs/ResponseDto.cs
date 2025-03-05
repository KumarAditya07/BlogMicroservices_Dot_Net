namespace BlogMicroservice.AuthService.DTOs
{
    public class ResponseDto
    {
        public string Errors { get; set; }
        public string Message { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
