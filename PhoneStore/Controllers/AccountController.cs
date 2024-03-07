using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Models;
using PhoneStore.Models.Resority;
using PhoneStore.ViewModel;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace PhoneStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplacationUser> userManager;
        private readonly SignInManager<ApplacationUser> signInMAnager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICountryRes egy;
        private readonly ICityRes cairo;
        private readonly IUserOrderRes _order;

        public AccountController(UserManager<ApplacationUser> _userManager ,
            SignInManager<ApplacationUser> _SignInMAnager,
            IHttpContextAccessor httpContextAccessor,
            ICountryRes _egy,
            ICityRes _cairo, IUserOrderRes order
            )
        {
            userManager = _userManager;
            signInMAnager = _SignInMAnager;
            _httpContextAccessor = httpContextAccessor;
            egy = _egy;
            cairo = _cairo;
            _order = order;
        }
        public IActionResult ajax1(int Id)
        {
            var cityforuser = cairo.GetId(Id);
            return Ok(cityforuser);
        }
        public IActionResult Register()
        {
            
            RegisterUserViewmodel newUservm = new RegisterUserViewmodel
            {
                CityUsers = cairo.GetAll(),
                CountryUsers = egy.GetAll()
                
            };
            return View(newUservm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewmodel newUserVM)
        {
           
            if (ModelState.IsValid)
            {
                //create account
                ApplacationUser userModel = new ApplacationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                //newUserVM.Countries = context.Countries.ToList();
                userModel.Country = newUserVM.Country;
                userModel.City = newUserVM.City;

                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(loginViewModel UserVm)
        {
            if (ModelState.IsValid)
            {
                //check
                ApplacationUser userModel = await userManager.FindByEmailAsync(UserVm.Email);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, UserVm.Password);
                    if (found)
                    {
                        await signInMAnager.SignInAsync(userModel, UserVm.RememberMe);
                       
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Email and password invalid");
            }
            return View(UserVm);
        }
        public async Task<IActionResult> Logout()
        {
            await signInMAnager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterUserViewmodel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplacationUser userModel = new ApplacationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                //userModel.City = newUserVM.City;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //creat cookie
                    await userManager.AddToRoleAsync(userModel, "Admin");
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
        public IActionResult AddSuper()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSuper(RegisterUserViewmodel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                ApplacationUser userModel = new ApplacationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                userModel.Address = newUserVM.Address;
                //userModel.City = newUserVM.City;
                IdentityResult result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded == true)
                {
                    //creat cookie
                    await userManager.AddToRoleAsync(userModel, "Super");
                    await signInMAnager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newUserVM);
        }
        public string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = userManager.GetUserId(principal);
            return userId;
        }
        public async Task<IActionResult> Details(RegisterUserViewmodel newUserVM)
        {
            //ApplacationUser userModel = new ApplacationUser();
             string UserId = GetUserId();
            
            ApplacationUser usertest = await userManager.FindByIdAsync(UserId);
            newUserVM.UserName = usertest.UserName;
            newUserVM.Email=usertest.Email;
            newUserVM.NumbersofOrders = _order.GetNumdersOrder(UserId);
             ViewBag.ord = _order.GetAllOrder(UserId);

            return View (newUserVM);
        }
        [HttpGet]
        public IActionResult changepassword() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> changepassword(changepasswordviewmodel model) 
        {
            if (ModelState.IsValid) 
            { 
            var user = await userManager.GetUserAsync(User);
                var resuilt = await userManager.ChangePasswordAsync(user, model.CurrentPassword,model.NewPassword);
                if (!resuilt.Succeeded)
                {
                    foreach (var error in resuilt.Errors) 
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await signInMAnager.RefreshSignInAsync(user);

                return View("Comfirmpassword");
             }
            return View(model);
        }


    }
}
