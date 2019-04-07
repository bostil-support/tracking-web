using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Models;
using Tracking.Web.Models.ViewModel.Auth;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.IO;
using System.IdentityModel.Tokens.Jwt;

namespace Tracking.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly SignInManager<TrackingUser> _signInManager;
        //private DataContractJsonSerializer jsF;

        public AccountController(UserManager<TrackingUser> userManager, SignInManager<TrackingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //jsF = new DataContractJsonSerializer(typeof(TokenModel));
        }        


        [HttpGet]
        public async Task<IActionResult> Login(string token)
        {
            string tokenString = token;
            var tokenS = new JwtSecurityToken(jwtEncodedString: tokenString);
            var email = tokenS.Claims.First(c => c.Type == "userName").Value;

            var result = await _signInManager.PasswordSignInAsync(email, "Den_10101994", true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                TrackingUser user = new TrackingUser { Email = email.ToString(), UserName = email.ToString() };
                IdentityResult res = await _userManager.CreateAsync(user, "Den_10101994");
                if (res.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return Ok();            
        }

        //string tokenString = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyTmFtZSI6InVzZXJAY29tcGFueS5jb20iLCJBcHAiOiJDQ0JfQXBwUmVwb3J0aW5nIiwidmFsdWVUZW5hbnQiOiJDQ0IiLCJyZWRpcmVjdFVybCI6Imh0dHBzOi8vcmVkaXJlY3QudXJsIn0.G6SbMz-j3UZw0tbK8gMKIRQnZGrewl78DUGAyL4oPvI"

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{

            //using (FileStream fs = new FileStream("token.json", FileMode.OpenOrCreate))
            //{
            //    jsF.WriteObject(fs, token);
            //}

            //var root = JObject.Parse(System.IO.File.ReadAllText(@"C:\Users\boikochev\Documents\tracking-main\Tracking.Web\token.json"));
            //var tokenValues =
            //        root.DescendantsAndSelf()
            //            .OfType<JProperty>()
            //            .Where(p => p.Name == "userName")
            //            .Select(p => p.Value);

            //foreach(var email in tokenValues)


    //        string tokenString = model.Token;
    //        var token = new JwtSecurityToken(jwtEncodedString: tokenString);
    //        var email = token.Claims.First(c => c.Type == "userName").Value;

    //        var result = await _signInManager.PasswordSignInAsync(email, "Den_10101994", true, false);

    //        if (result.Succeeded)
    //        {             
               
    //            return RedirectToAction("Index", "Home");               

    //        }

    //        else
    //        {
    //            TrackingUser user = new TrackingUser { Email = email.ToString(), UserName = email.ToString()};                             
    //            IdentityResult res = await _userManager.CreateAsync(user, "Den_10101994");
    //            if (res.Succeeded)
    //            {
    //               await _signInManager.SignInAsync(user, false);
    //               return RedirectToAction("Index", "Home");
    //            }
    //        }
            

    //        return View(model);
    //    }

    //    public async Task<IActionResult> Logout()
    //    {
    //        await _signInManager.SignOutAsync();
    //        return RedirectToAction("Login", "Account");
    //    }
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
 
