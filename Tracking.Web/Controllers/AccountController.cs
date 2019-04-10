using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Models;
using Microsoft.AspNetCore.Identity;
using Tracking.Web.Repositories;
using Newtonsoft.Json;

namespace Tracking.Web.Controllers
{
    /// <summary>
    /// Controller for Authorize and Registration functional
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly SignInManager<TrackingUser> _signInManager;
        private readonly TokenManager _manager;      
        
        /// <summary>
        /// User Constructor for Init managers
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<TrackingUser> userManager, SignInManager<TrackingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _manager = new TokenManager();         
            
        }
        
        /// <summary>
        /// Method for Authorize and Register logic
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Authorize(string token)
        {
            token = token.Replace(" ", "+");
            string tokenString = _manager.Decrypt(token.ToString());
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

 
 
   
 
