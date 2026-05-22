using System.Text.Json;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonReviewRepository
    {
        private readonly string _filePath = "resenas.json";

        public JsonReviewRepository()
        {
            var carpeta = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(carpeta)) Directory.CreateDirectory(carpeta);
        }

        public List<Resena> ObtenerTodos()
        {
            if (!File.Exists(_filePath)) return new List<Resena>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Resena>>(json) ?? new List<Resena>();
        }

        public void Agregar(Resena resena)
        {
            var resenas = ObtenerTodos();
            resena.Id = resenas.Count > 0 ? resenas.Max(r => r.Id) + 1 : 1;
            resenas.Add(resena);
            Guardar(resenas);
        }

        public List<Resena> ObtenerPorItem(int itemId)
        {
            return ObtenerTodos().Where(r => r.ItemId == itemId).ToList();
        }

        private void Guardar(List<Resena> resenas)
        {
            var json = JsonSerializer.Serialize(resenas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}