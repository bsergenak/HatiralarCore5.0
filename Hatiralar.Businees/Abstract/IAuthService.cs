using Hatiralar.Entities.Concrete;
using Hatiralar.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.Businees.Abstract
{
    public interface IAuthService
    {
        Task<SignInResult> Login(LoginDto loginDto);
        Task<IdentityResult> UserRegister(RegisterDto registerDto);
        AppUser GetUser(string userName);
        Task<IdentityResult> AddRoleToUser(AppUser user, string roleName);
        Task LogOut();
        Task<string> SignIn(LoginDto loginDto);

    }
}
