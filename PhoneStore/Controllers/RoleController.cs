using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.ViewModel;

namespace PhoneStore.Controllers
{
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> New(ViewModelRole NewRole)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = NewRole.NameRole;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View(new ViewModelRole());
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(NewRole);
        }
    }
}
