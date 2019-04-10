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
using System.Security.Cryptography;
using System.Text;
using Tracking.Web.Repositories;
using Newtonsoft.Json;

namespace Tracking.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly SignInManager<TrackingUser> _signInManager;
        private ITokenRepository _repository;      
        

        public AccountController(UserManager<TrackingUser> userManager, SignInManager<TrackingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = new TokenRepository();           
            
        }

        
        [HttpGet]
        public async Task<IActionResult> Login(string token)
        {
            token = token.Replace(" ", "+");
            string tokenString = _repository.Decrypt(token.ToString());
            var json = JsonConvert.DeserializeObject<TokenModel>(tokenString);
            var email = json.userName.ToString();

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
    }
}

 
 
   
 
