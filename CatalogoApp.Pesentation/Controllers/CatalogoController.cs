using Microsoft.AspNetCore.Mvc;
using CatalogoApp.Domain.Models;
using CatalogoApp.Infrastructure.Repositories;
using System.Linq;

namespace CatalogoApp.Presentation.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly JsonItemRepository _itemRepository = new JsonItemRepository("data/items.json");
        private readonly JsonReviewRepository _reviewRepository = new JsonReviewRepository();

        // 1. ÚNICA ACCIÓN INDEX: Maneja tanto la carga completa como el filtrado opcional
        [HttpGet]
        public IActionResult Index(string genero)
        {
            var items = _itemRepository.ObtenerTodos();

            // Poblamos los géneros únicos para la vista
            ViewBag.Generos = items
                .Where(i => !string.IsNullOrEmpty(i.Genero))
                .Select(i => i.Genero)
                .Distinct()
                .ToList();

            // Si se seleccionó un género para filtrar, aplicamos el filtro
            if (!string.IsNullOrEmpty(genero))
            {
                items = items.Where(i => i.Genero.Equals(genero, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(items);
        }

        // 2. ACCIÓN DETALLE
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var item = _itemRepository.ObtenerTodos().FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            // Cargamos las reseñas asociadas al ítem
            item.Resenas = _reviewRepository.ObtenerPorItem(id);

            return View(item);
        }

        // 3. ACCIONES AGREGAR ÍTEM
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Item item)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.Agregar(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }
}