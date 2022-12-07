using FindJobSolution.Data.EF;
using FindJobSolution.Data.Entities;
using FindJobSolution.Utilities.Exceptions;
using FindJobSolution.ViewModels.Common;
using FindJobSolution.ViewModels.System.Role;
using FindJobSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace FindJobSolution.Application.System
{
    public interface IUserService
    {
        Task<string> Authencate(UserLoginRequest request);

        Task<bool> Register(UserRegisterRequest request);

        Task<PagedResult<UserViewModel>> GetUsersPaging(GetUserPagingRequest request);

        Task<UserViewModel> GetById(Guid id);

        Task<bool> Delete(Guid id);

        Task<bool> RoleAssign(Guid id, RoleAssignRequest request);

        Task<bool> ChangePassword(ChangePasswordModel request);

        Task<string> ResetPasswordToken(string userName);

        Task<bool> ResetPassword(ResetPasswordModel request);

        Task<bool> ResetPasswordForgot(ResetPasswordVM request);

        Task<string> ForgotPassword(string email);

        Task<string> ForgotPasswordRecuiter(string email);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly FindJobDBContext _context;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
            RoleManager<AppRole> roleManager, IConfiguration config, FindJobDBContext context)
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
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                //new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
            //var user = await _userManager.FindByNameAsync(request.UserName);
            //if (user == null) throw new FindJobException("Tài khoản không tồn tại");

            //var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            //if (!result.Succeeded)
            //{
            //    throw new FindJobException("Đăng nhập không đúng");
            //}
            //var roles = _userManager.GetRolesAsync(user);
            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Email, user.Email),
            //    new Claim(ClaimTypes.Role, string.Join(";",roles)),
            //    new Claim(ClaimTypes.Name, user.UserName),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //};
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(_config["Tokens:Issuer"],
            //    _config["Tokens:Issuer"],
            //    claims,
            //    expires: DateTime.Now.AddHours(24),
            //    signingCredentials: creds);

            //return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserViewModel> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new FindJobException("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);

            var userVm = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles
            };
            return (userVm);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new FindJobException("User không tồn tại");
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
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
                    Email = p.Email,
                }).ToListAsync();

            // in ra
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return (pagedResult);
        }

        public async Task<bool> Register(UserRegisterRequest request)
        {
            var userid = await _userManager.FindByNameAsync(request.UserName);
            if (userid != null)
            {
                return false;
            }

            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return false;
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
            return false;
        }

        public async Task<bool> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return false;
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return true;
        }

        public Task<bool> ChangePassword(ChangePasswordModel request)
        {
            var user = _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Task.FromResult(false);
            }
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return Task.FromResult(false);
            }
            var result = _userManager.ChangePasswordAsync(user.Result, request.CurrentPassword, request.NewPassword);
            if (!result.Result.Succeeded)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<string> ResetPasswordToken(string userName)
        {
            var user = _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return null;
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user.Result);
            return token;
        }

        public Task<bool> ResetPassword(ResetPasswordModel request)
        {
            var user = _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return Task.FromResult(false);
            }
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrEmpty(request.Token))
            {
                return Task.FromResult(false);
            }

            var result = _userManager.ResetPasswordAsync(user.Result, request.Token, request.NewPassword);
            if (!result.Result.Succeeded)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public async Task<string> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user);

            //var encodedToken = Encoding.UTF8.GetBytes(token.Result);
            //var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"https://localhost:2000/UserJobSeeker/ChangePasswordWithToken";

            await EmailSender.SendEmailAsync(email, "Reset Password",
                $"<table cellspacing=\"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\"\r\n        style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">\r\n        <tr>\r\n            <td>\r\n                <table style=\"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\"\r\n                    align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                          <a href=\"https://rakeshmandal.com\" title=\"logo\" target=\"_blank\">\r\n                            <img width=\"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">\r\n                          </a>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"\r\n                                style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"padding:0 35px;\">\r\n                                        <h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">Đây là yêu cầu thay đổi mật khẩu của bạn</h1>\r\n                                        <span\r\n                                            style=\"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\"></span>\r\n                                        <p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">\r\n                                            Chúng tôi không thể đơn giản gửi cho bạn mật khẩu cũ của bạn. Một liên kết duy nhất để đặt lại mật khẩu của bạn đã được tạo cho bạn. Để đặt lại mật khẩu của bạn, nhấp vào liên kết sau và làm theo hướng dẫn.\r\n                                        </p>\r\n                                        <p style=\"color:#404344; font-size:15px;line-height:24px; margin:0;\">\r\n                                            Copy đoạn token này và dán vào ô token trong liên kết phía dưới:\r\n                                        </p>\r\n                                        <p style=\"color:#1e1e2d; font-size:15px;line-height:24px; margin:0;\">\r\n                                            {token.Result}                                       </p>\r\n                                        <a href='{url}'                                       style=\"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\">Đổi mật khẩu</a>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                            <p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.tickettofuture.com</strong></p>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>");
            return token.Result;
        }

        public async Task<bool> ResetPasswordForgot(ResetPasswordVM request)
        {
            var user = _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return false;
            }
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return false;
            }

            if (string.IsNullOrEmpty(request.Token))
            {
                return false;
            }

            var result = await _userManager.ResetPasswordAsync(user.Result, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<string> ForgotPasswordRecuiter(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var token = _userManager.GeneratePasswordResetTokenAsync(user);

            //var encodedToken = Encoding.UTF8.GetBytes(token.Result);
            //var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"https://localhost:2000/UserRecuiter/ChangePasswordWithToken";

            await EmailSender.SendEmailAsync(email, "Yêu cầu thay đổi mật khẩu của bạn trên web Ticket To Future",
                $"<table cellspacing=\"0\" border=\"0\" cellpadding=\"0\" width=\"100%\" bgcolor=\"#f2f3f8\"\r\n        style=\"@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;\">\r\n        <tr>\r\n            <td>\r\n                <table style=\"background-color: #f2f3f8; max-width:670px;  margin:0 auto;\" width=\"100%\" border=\"0\"\r\n                    align=\"center\" cellpadding=\"0\" cellspacing=\"0\">\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                          <a href=\"https://rakeshmandal.com\" title=\"logo\" target=\"_blank\">\r\n                            <img width=\"60\" src=\"https://i.ibb.co/hL4XZp2/android-chrome-192x192.png\" title=\"logo\" alt=\"logo\">\r\n                          </a>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>\r\n                            <table width=\"95%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"\r\n                                style=\"max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);\">\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"padding:0 35px;\">\r\n                                        <h1 style=\"color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;\">Đây là yêu cầu thay đổi mật khẩu của bạn</h1>\r\n                                        <span\r\n                                            style=\"display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;\"></span>\r\n                                        <p style=\"color:#455056; font-size:15px;line-height:24px; margin:0;\">\r\n                                            Chúng tôi không thể đơn giản gửi cho bạn mật khẩu cũ của bạn. Một liên kết duy nhất để đặt lại mật khẩu của bạn đã được tạo cho bạn. Để đặt lại mật khẩu của bạn, nhấp vào liên kết sau và làm theo hướng dẫn.\r\n                                        </p>\r\n                                        <p style=\"color:#404344; font-size:15px;line-height:24px; margin:0;\">\r\n                                            Copy đoạn token này và dán vào ô token trong liên kết phía dưới:\r\n                                        </p>\r\n                                        <p style=\"color:#1e1e2d; font-size:15px;line-height:24px; margin:0;\">\r\n                                            {token.Result}                                       </p>\r\n                                        <a href='{url}'                                       style=\"background:#20e277;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;\">Đổi mật khẩu</a>\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"height:40px;\">&nbsp;</td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    <tr>\r\n                        <td style=\"height:20px;\">&nbsp;</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"text-align:center;\">\r\n                            <p style=\"font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;\">&copy; <strong>www.tickettofuture.com</strong></p>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"height:80px;\">&nbsp;</td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>");
            return token.Result;
        }

        //private async Task SendEmailAsync(string toEmail, string subject, string content)
        //{
        //    var apiKey = _config["SendGridAPIKey"];
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("lelexuan22@gmail.com", "JWT Auth Demo");
        //    var to = new EmailAddress(toEmail);
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        //    var response = await client.SendEmailAsync(msg);
        //}

        public static class EmailSender
        {
            public static async Task SendEmailAsync(string email, string subject, string htmlMessage)
            {
                string fromMail = "tickettofuture.token@gmail.com";
                string fromPassword = "aqkdequrwjflmmne";

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = subject;
                message.To.Add(new MailAddress(email));
                message.Body = "<html><body>" + htmlMessage + "</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
            }
        }
    }
}