namespace MyProject.Entities.ViewModels.Login
{
    public class UserLoginResponseModel
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
