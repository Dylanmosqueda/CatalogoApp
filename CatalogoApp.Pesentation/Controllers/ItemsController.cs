using Microsoft.AspNetCore.Mvc;
using CatalogoApp.Domain.Models;
using CatalogoApp.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace CatalogoApp.Presentation.Controllers
{
    public class ItemsController : Controller
    {
        // Instanciamos los repositorios directamente para evitar errores de inyección
        private readonly JsonItemRepository _itemRepository = new JsonItemRepository("data/items.json");
        private readonly JsonReviewRepository _reviewRepository = new JsonReviewRepository();

        // Constructor vacío para que .NET no intente buscar servicios en Program.cs
        public ItemsController()
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarResena(int itemId, string usuario, int calificacion, string comentario)
        {
            if (ModelState.IsValid)
            {
                // Creamos el objeto de la nueva reseña
                var nuevaResena = new Resena
                {
                    ItemId = itemId,
                    Usuario = usuario,
                    Calificacion = calificacion,
                    Comentario = comentario,
                    Fecha = DateTime.Now
                };

                // Guardamos la reseña en el repositorio JSON
                _reviewRepository.Agregar(nuevaResena);

                // Redireccionamos a la acción Detalle del CatalogoController
                return RedirectToAction("Detalle", "Catalogo", new { id = itemId });
            }

            // En caso de que el modelo sea inválido, de igual forma regresamos al detalle
            return RedirectToAction("Detalle", "Catalogo", new { id = itemId });
        }
    }
}