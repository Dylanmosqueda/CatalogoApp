using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using CatalogoApp.Infrastructure.Repositories;
using CatalogoApp.Domain.Models;

public class AccountController : Controller
{
    private readonly JsonUserRepository _userRepo = new JsonUserRepository();

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(Usuario usuario)
    {
        _userRepo.Registrar(usuario);
        return RedirectToAction("Login");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = _userRepo.ValidarLogin(username, password);
        if (user != null)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username) };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Catalogo");
        }
        ViewBag.Error = "Usuario o contraseña incorrectos";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Catalogo");
    }
}