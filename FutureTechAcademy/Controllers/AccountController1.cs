using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using FutureTechAcademy.Models;
using FutureTechAcademy.Services;

namespace FutureTechAcademy.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            // This triggers the Google OAuth 2.0 challenge
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("Index", "Students") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/RegisterStaff
        public IActionResult RegisterStaff()
        {
            return View();
        }

        // POST: /Account/RegisterStaff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStaff(string firstName, string lastName, string email)
        {
            // Here you would normally save the staff email to a 'Staff' container in Cosmos DB
            // For now, we will simulate a success and redirect to login
            ViewBag.Message = "Staff account for " + email + " has been provisioned. You can now login.";
            return View();
        }
    }
}