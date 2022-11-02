using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Catalog.JobInformations;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobSolution.Application.System
{
    public interface IUserService
    {
        Task<string> Authencate(UserLoginRequest request);

        Task<bool> Register(UserRegisterRequest request);

        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        private readonly FindJobDBContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<Role> roleManager, IConfiguration config, FindJobDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<string> Authencate(UserLoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) throw new FindJobException("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                throw new FindJobException("Đăng nhập không đúng");
            }
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new UserViewModel()
                {
                    Id = p.Id,
                    UserName = p.UserName,
                    Email = p.Email
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };

            return pagedResult;
        }

        public async Task<bool> Register(UserRegisterRequest request)
        {
            var userid = await _userManager.FindByNameAsync(request.UserName);
            if (userid != null)
            {
                throw new FindJobException("Tài khoản đã tồn tại");
            }

            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                throw new FindJobException("Emai đã tồn tại");
            }

            var user = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return true;
            }
            throw new FindJobException("Đăng ký không thành công");
        }
    }
}