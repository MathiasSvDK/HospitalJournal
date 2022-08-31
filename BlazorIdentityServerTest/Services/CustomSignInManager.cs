using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorIdentityServerTest.Models;

namespace BlazorIdentityServerTest.Services
{
    //TODO: Remove this?
    public class CustomSignInManager : SignInManager<ApplicationUser>
    {
        public CustomSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<ApplicationUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        ///<summary>
        /// When signing in on the identity server, some extra claims are needed, these are added here
        ///<param name="user">The user signin in</param>
        /// <returns>The user signin in with extra claims from the identity server</returns>
        /// </summary>
        public override async Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user)
        {
            var principal = await base.CreateUserPrincipalAsync(user);

            var user2 = await UserManager.FindByIdAsync(user.Id);
            // use this.UserManager if needed
            var identity = (ClaimsIdentity)principal.Identity;

            return principal;
        }
    }
}