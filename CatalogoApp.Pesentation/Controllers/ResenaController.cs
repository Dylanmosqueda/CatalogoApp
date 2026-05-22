using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CatalogoApp.Infrastructure.Repositories;
using CatalogoApp.Domain.Models;

[Authorize] // Impide el acceso a cualquier método si no hay sesión
public class ResenaController : Controller
{
    private readonly JsonReviewRepository _repo = new JsonReviewRepository();

    [HttpPost]
    public IActionResult Agregar(Resena resena)
    {
        _repo.Agregar(resena);
        return RedirectToAction("Details", "Catalogo", new { id = resena.ItemId });
    }
}