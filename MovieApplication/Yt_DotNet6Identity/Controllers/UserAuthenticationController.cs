using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models.DTO;
using MovieApp.Repositories.Abstract;

namespace MovieApp.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this._service = service;   
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
              return View(model);
            model.Role = "user"; 
            var result = await _service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
            
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                // Add model errors to display in the view
                ModelState.AddModelError(string.Empty, result.Message);

                // Pass the error message to the viewbag for JavaScript usage
                ViewBag.ErrorMessage = result.Message;

                return View(model);
            }
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
        //One time User Creation method
        
       public async Task<IActionResult> Reg()
        {
            var model = new RegistrationModel
            {
              Username = "admin2",
              Name = "Joel Shaba",
              Email = "joel@gmail.com",
              Password = "Admin@1234#",
            };
            model.Role = "admin";
            var result = await _service.RegistrationAsync(model);
            return Ok(result);
        }
        
    } 

}
