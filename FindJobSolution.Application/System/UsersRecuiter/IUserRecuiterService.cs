using FindJobSolution.ViewModels.Catalog.Recruiters;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.UsersRecruiter;

namespace FindJobSolution.Application.System.UsersRecuiter
{
    public interface IUserRecuiterService
    {
        Task<string> Authenticate(LoginRecruiterRequest request);

        Task<bool> Register(RegisterRecuiterRequest request);
    }
}