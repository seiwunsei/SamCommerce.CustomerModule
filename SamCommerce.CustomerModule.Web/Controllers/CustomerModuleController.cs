using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamCommerce.CustomerModule.Core.Model.Search;
using SamCommerce.CustomerModule.Core.Model;
using SamCommerce.CustomerModule.Core.Services;
using SamCommerce.Platform.Core.Security;
using SamCommerce.CustomerModule.Core;
using SamCommerce.CustomerModule.Data.Authorization;

namespace SamCommerce.CustomerModule.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomerModuleController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMemberService _memberService;
        private readonly IMemberSearchService _memberSearchService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private UserManager<ApplicationUser> UserManager => _signInManager.UserManager;

        public CustomerModuleController(IAuthorizationService authorizationService,
            IMemberService memberService,
            IMemberSearchService memberSearchService,
            SignInManager<ApplicationUser> signInManager)
        {
            _authorizationService = authorizationService;
            _memberService = memberService;
            _memberSearchService = memberSearchService;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Get organizations
        /// </summary>
        /// <remarks>Get array of all organizations.</remarks>
        [HttpGet]
        [Route("members/organizations")]
        public async Task<ActionResult<Organization[]>> ListOrganizations()
        {
            var searchCriteria = new MembersSearchCriteria
            {
                MemberType = typeof(Organization).Name,
                DeepSearch = true,
                Take = int.MaxValue
            };
            if (!(await AuthorizeAsync(searchCriteria, ModuleConstants.Security.Permissions.Access)).Succeeded)
            {
                return Forbid();
            }
            var result = await _memberSearchService.SearchMembersAsync(searchCriteria);

            return Ok(result.Results.OfType<Organization>());
        }

        private Task<AuthorizationResult> AuthorizeAsync(object resource, string permission)
        {
            return _authorizationService.AuthorizeAsync(User, resource, new CustomerAuthorizationRequirement(permission));
        }
    }
}
