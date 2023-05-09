using Hatiralar.Businees.Abstract;
using Hatiralar.Entities.Concrete;
using Hatiralar.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddRoleToUser(AppUser user, string roleName)
        {
            var role = _roleManager.Roles.FirstOrDefault(x=>x.Name == roleName);
            if (role is null)
            {
                await _roleManager.CreateAsync(
                    new AppRole { 
                    Name =roleName, 
                    NormalizedName= roleName.ToUpper()
                    });
            }
            return await _userManager.AddToRoleAsync(user,roleName);
        }

        public AppUser GetUser(string userName)
        {

            AppUser user = _userManager.Users.FirstOrDefault(x=>x.UserName == userName);
            return user;
        }

        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            AppUser user = _userManager.Users.FirstOrDefault(x=>x.Email == loginDto.Email);
            if (user is null)
            {
                return new SignInResult();
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, false);
            return result;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> SignIn(LoginDto loginDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user,loginDto.Password,user.LockoutEnabled);
                if (result.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes("keykullaniyorumburada");
                    var claims = new List<Claim> {
                    new Claim("UserId",user.Id.ToString()),
                    new Claim("DisplayName",user.Name),
                    new Claim("UserName",user.UserName),
                    new Claim("Email",user.Email)
                    };

                    var userRole = await _userManager.GetRolesAsync(user);
                    foreach (var item in userRole)
                    {
                        claims.Add(new Claim(ClaimTypes.Role,item));
                    }
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);
                    var tokenDescriptor = new SecurityTokenDescriptor {
                        Audience = "localhost",
                        Issuer = "localhost",
                        Subject = claimsIdentity,
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                    };

                    var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
                    string token = tokenHandler.WriteToken(jwtToken);
                    return token;
                }
            }
            return "";
        }

        public async Task<IdentityResult> UserRegister(RegisterDto registerDto)
        {
            var user = new AppUser {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber, 
                Name = registerDto.FirstName
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await AddRoleToUser(user,"User");
            }
            return result;
        }
        public async Task<string> GetRoleByUserNameAsync(string userName)
        {
            var user = GetUser(userName);
            var roleList = (await _userManager.GetRolesAsync(user));
            if (roleList.Count >0)
            {
                return roleList[0];
            }
            return null;
        }

       
    }
}
