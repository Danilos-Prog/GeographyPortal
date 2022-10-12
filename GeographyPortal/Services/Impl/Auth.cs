using GeographyPortal.Areas.Identity.Data;
using GeographyPortal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Policy;
using System.Text;

namespace GeographyPortal.Services.Impl
{
    public class Auth : IAuth
    {

        private readonly SignInManager<GeographyPortalUser> _signInManager;
        private readonly UserManager<GeographyPortalUser> _userManager;
        private readonly IUserStore<GeographyPortalUser> _userStore;
        private readonly IUserEmailStore<GeographyPortalUser> _emailStore;
        private readonly ILogger<Auth> _logger;
        private readonly IEmailSender _emailSender;

        public Auth(
            UserManager<GeographyPortalUser> userManager,
            IUserStore<GeographyPortalUser> userStore,
            SignInManager<GeographyPortalUser> signInManager,
            ILogger<Auth> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }


        public async Task CreateAsync(InputModel input)
        {
            var user = CreateUser();

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;

            await _userStore.SetUserNameAsync(user, input.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, input.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created");
                await _userManager.AddToRoleAsync(user, "User");

            }

        }

        private GeographyPortalUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<GeographyPortalUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(GeographyPortalUser)}'. " +
                    $"Ensure that '{nameof(GeographyPortalUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<GeographyPortalUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<GeographyPortalUser>)_userStore;
        }


    }
}

