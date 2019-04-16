using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracking.Web.Models;
using Microsoft.AspNetCore.Identity;
using Tracking.Web.Managers;
using Newtonsoft.Json;
using System;
using Tracking.Web.Managers;

namespace Tracking.Web.Controllers
{
    /// <summary>
    /// Controller for Authorize and Registration functional
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<TrackingUser> _userManager;
        private readonly RoleManager<TrackingRole> _roleManager;
        private readonly SignInManager<TrackingUser> _signInManager;
        private readonly TokenManager _manager;
        private readonly EmailServices _services;
        
        /// <summary>
        /// User Constructor for Init managers
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<TrackingUser> userManager, SignInManager<TrackingUser> signInManager,RoleManager<TrackingRole> roleManager,EmailServices services)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _manager = new TokenManager();
            _services = services;            
        }
        
        /// <summary>
        /// Start Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "Per favore inserisci il tuo token nell'URL";
            return View();
        }


        /// <summary>
        /// Method for Authorize and Register logic
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Authorize(string token)
        {
            try
            {
                token = token.Replace(" ", "+");
                string tokenString = _manager.Decrypt(token.ToString());
                var json = JsonConvert.DeserializeObject<TokenModel>(tokenString);
                var email = json.userName.ToString();

                var result = await _signInManager.PasswordSignInAsync(email, "Qwerty123!", true, false);                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }              

                else
                {
                    var userAudience = _services.FindUserInAudience(email);
                    var userCompliance = _services.FindUserInComplaince(email);
                    if(userAudience != null)
                    {
                        TrackingUser user = new TrackingUser { Email = email.ToString(), UserName = email.ToString() };
                        IdentityResult res = await _userManager.CreateAsync(user, "Qwerty123!");
                        IdentityRole role = await _roleManager.FindByNameAsync("Auditor");
                        //IdentityRole role = await _roleManager.FindByIdAsync("10");

                        if (res.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, role.Name);
                            await _signInManager.SignInAsync(user, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Error", "Account", json.redirectUrl.ToString());
                        }
                    }
                    else if(userCompliance!=null)
                    {
                        TrackingUser user = new TrackingUser { Email = email.ToString(), UserName = email.ToString() };
                        IdentityResult res = await _userManager.CreateAsync(user, "Qwerty123!");
                        IdentityRole role = await _roleManager.FindByNameAsync("Compliance");
                        //IdentityRole role = await _roleManager.FindByIdAsync("10");

                        if (res.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, role.Name);
                            await _signInManager.SignInAsync(user, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Error", "Account", json.redirectUrl.ToString());
                        }
                    }
                    return RedirectToAction("Error", "Account", json.redirectUrl.ToString());


                }
            }
            catch(Exception e)
            {
                return RedirectToAction("Error", "Account");
            }                      
        }
        
        public IActionResult Error(string json)
        {
            TokenModel model = new TokenModel();
            model.redirectUrl = json;

            ViewData["Message"] = "Your Token is WRONG please check it";
            return View(model);
        }
    }
}

 
 
   
 
