using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;


namespace Tracking.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly SignInManager<TrackingUser> _signInManager;

        public AccountController(UserManager<TrackingUser> userManager, SignInManager<TrackingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {


         var root = JObject.Parse(System.IO.File.ReadAllText(@"C:\Users\boikochev\Documents\tracking-main\Tracking.Web\token.json"));
            var tokenValues =
                    root.DescendantsAndSelf()
                        .OfType<JProperty>()
                        .Where(p => p.Name == "userName")
                        .Select(p => p.Value);


            foreach(var email in tokenValues)
            {
                var result = await _signInManager.PasswordSignInAsync(email.ToString(),"123", model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                {
                    TrackingUser user = new TrackingUser { Email = email.ToString(), UserName = email.ToString()};                             
                    IdentityResult res = await _userManager.CreateAsync(user, "Den_10101994");
                    if (res.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }

                }

            }

            return View(model);



        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}

 
 
    //    [HttpGet]
    //    public IActionResult Register()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> Register(RegisterViewModel model)
    //    {
    //        if(ModelState.IsValid)
    //        {
    //            User user = new User { Email = model.Email, UserName = model.Email, Year=model.Year};
    //            // добавляем пользователя
    //            var result = await _userManager.CreateAsync(user, model.Password);
    //            if (result.Succeeded)
    //            {
    //                // установка куки
    //                await _signInManager.SignInAsync(user, false);
    //                return RedirectToAction("Index", "Home");
    //            }
    //            else
    //            {
    //                foreach (var error in result.Errors)
    //                {
    //                    ModelState.AddModelError(string.Empty, error.Description);
    //                }
    //            }
    //        }
    //        return View(model);
    //    }
    //}
 
