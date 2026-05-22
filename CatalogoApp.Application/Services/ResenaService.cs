using CatalogoApp.Infrastructure.Repositories; // Agrega esta línea
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Application.Services
{
    public class ResenaService
    {
        private readonly JsonReviewRepository _resenaRepo;

        public ResenaService(JsonReviewRepository resenaRepo)
        {
            _resenaRepo = resenaRepo;
        }

        // Método para agregar una reseña con validaciones
        public void AgregarResena(int itemId, int usuarioId, string comentario, int calificacion)
        {
            // 1. Validaciones básicas antes de guardar
            if (calificacion < 1 || calificacion > 5)
            {
                throw new Exception("La calificación debe estar entre 1 y 5.");
            }

            if (string.IsNullOrWhiteSpace(comentario))
            {
                throw new Exception("El comentario no puede estar vacío.");
            }

            // 2. Crear el objeto
            var nuevaResena = new Resena
            {
                ItemId = itemId,
                UsuarioId = usuarioId,
                Comentario = comentario,
                Calificacion = calificacion
            };

            // 3. Guardar a través del repositorio
            _resenaRepo.Agregar(nuevaResena);
        }

        // Método para obtener las reseñas de un item específico
        public List<Resena> ObtenerResenasDelItem(int itemId)
        {
            return _resenaRepo.ObtenerPorItem(itemId);
        }
    }
}