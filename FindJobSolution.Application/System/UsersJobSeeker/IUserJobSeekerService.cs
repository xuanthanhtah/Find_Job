using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using FindJobSolution.ViewModels.System.UsersJobSeeker;

namespace FindJobSolution.Application.System.UsersJobSeeker
{
    public interface IUserJobSeekerService
    {
        Task<string> Authenticate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);
    }
}