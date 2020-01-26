using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using System.Threading;
using System.Data.SqlClient;
using Teacher.Website.Infrastructure;
using Dapper;
using System.Security.Claims;
using System;

namespace Teacher.Website.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IMediator _mediator;

        public LoginModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<LoginModel> logger, IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _mediator = mediator;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Login, Input.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var userId = await _mediator.Send(new Query { Username = Input.Login });
                    var user = await _userManager.FindByNameAsync(Input.Login);
                    await AddClaimAsync(user, "UserId", userId.ToString());
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No luck this time.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task AddClaimAsync(IdentityUser user, string key, string value)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            if (claims.Any(x => x.Type == key))
                await _userManager.RemoveClaimsAsync(user, claims.Where(x => x.Type == key));
            await _userManager.AddClaimAsync(user, new Claim(key, value));
        }

        public class Query : IRequest<int>
        {
            public string Username{ get; set; }
        }

        internal class QueryHandler : IRequestHandler<Query, int>
        {
            private readonly IConnectionStringFactory _connectionStringFactory;

            public QueryHandler(IConnectionStringFactory connectionStringFactory)
            {
                _connectionStringFactory = connectionStringFactory;
            }

            public async Task<int> Handle(Query query, CancellationToken cancellationToken)
            {
                using (var db = new SqlConnection(_connectionStringFactory.ToDatabase()))
                {
                    var sql = $"SELECT UserId FROM [vw_UserDetails]";
                    return await db.QueryFirstAsync<int>(sql);
                }
            }
        }
    }
}