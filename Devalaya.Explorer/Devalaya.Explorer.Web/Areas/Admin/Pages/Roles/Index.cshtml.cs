using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devalaya.Explorer.Web.Areas.Identity.Pages.Account.Manage.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public string RoleName { get; set; }

        public List<IdentityRole> Roles { get; set; } = new();

        public void OnGet()
        {
            Roles = _roleManager.Roles.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(RoleName))
            {
                var roleExist = await _roleManager.RoleExistsAsync(RoleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleName));
                }
            }
            return RedirectToPage();
        }
    }
}
