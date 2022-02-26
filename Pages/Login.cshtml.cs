using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace test.Pages
{
    public class LoginModel : PageModel
    {
        public String resultat { get; set; }    
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string login,string psw)
        {
            if (login.Equals("Admin") && psw.Equals("123"))
            {
                var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, login)
                    };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToPage("/Admin/Index");
            }
            resultat = "login incorecte";
            return Page();
        }
    }
}
