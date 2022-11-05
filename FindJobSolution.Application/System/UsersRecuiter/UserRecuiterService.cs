using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.UsersRecruiter;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobSolution.Application.System.UsersRecuiter
{
    public class UserRecuiterService : IUserRecuiterService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly FindJobDBContext _context;

        public UserRecuiterService(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config, FindJobDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<string> Authenticate(LoginRecruiterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return null;
            }
            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
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

        public async Task<bool> Register(RegisterRecuiterRequest request)
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

            var recruiter = new Recruiter()
            {
                UserId = user.Id,
            };

            await _context.AddAsync(recruiter);
            await _context.SaveChangesAsync();

            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
    }
}