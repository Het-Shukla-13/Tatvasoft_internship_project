using MyProject.Entities.ViewModels.Login;
using MyProject.Entities.ViewModels;

namespace MyProject.Services.IService
{
    public interface IUserService
    {
        Task<ResponseResult<UserLoginResponseModel>> LoginUser(UserLoginRequestModel model);
    }
}
