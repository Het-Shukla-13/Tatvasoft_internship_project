using MyProject.Entities.ViewModels.Login;
using MyProject.Entities.ViewModels;
using MyProject.Repositories.IRepository;
using MyProject.Services.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyProject.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ResponseResult<UserLoginResponseModel>> LoginUser(UserLoginRequestModel model)
        {
            var user = _userRepository.GetUserByEmailAndPassword(model.Email, model.Password);
            if (user == null)
            {
                return new ResponseResult<UserLoginResponseModel>
                {
                    Result = ResponseStatus.Error,
                    Message = "Invalid email or password"
                };
            }

            var token = GenerateJwtToken(user);

            return new ResponseResult<UserLoginResponseModel>
            {
                Result = ResponseStatus.Success,
                Data = new UserLoginResponseModel
                {
                    Email = user.Email,
                    Role = user.Role,
                    Token = token
                }
            };
        }

        private string GenerateJwtToken(MyProject.Entities.Models.User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["DurationInMinutes"] ?? "60")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
