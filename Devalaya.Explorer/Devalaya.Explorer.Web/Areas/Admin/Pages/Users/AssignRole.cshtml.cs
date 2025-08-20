using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Devalaya.Explorer.Web.Areas.Admin.Pages.Users
{
    public class AssignRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AssignRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [BindProperty]
        public string Id { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
        public List<string> AllRoles { get; set; } = new();
        public List<string> UserRoles { get; set; } = new();

        [BindProperty]
        public List<string> SelectedRoles { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            Id = user.Id;
            UserName = user.UserName ?? "";

            AllRoles = _roleManager.Roles.Select(r => r.Name!).ToList();
            UserRoles = (await _userManager.GetRolesAsync(user)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            // Remove unchecked roles
            var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(SelectedRoles));
            if (!removeResult.Succeeded)
                ModelState.AddModelError("", "Failed to remove old roles.");

            // Add newly selected roles
            var addResult = await _userManager.AddToRolesAsync(user, SelectedRoles.Except(userRoles));
            if (!addResult.Succeeded)
                ModelState.AddModelError("", "Failed to add new roles.");

            return RedirectToPage("index");
        }
    }
}
