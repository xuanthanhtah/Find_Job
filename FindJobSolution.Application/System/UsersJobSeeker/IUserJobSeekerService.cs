using FindJobSolution.ViewModels.System.UsersJobSeeker;

namespace FindJobSolution.Application.System.UsersJobSeeker
{
    public interface IUserJobSeekerService
    {
        Task<string> Authenticate(LoginRequest request);

        Task<bool> Register(RegisterRequest request);
    }
}

