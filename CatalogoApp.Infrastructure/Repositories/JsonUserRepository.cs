using System.Text.Json;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonUserRepository
    {
        private readonly string _filePath = "usuarios.json";

        public JsonUserRepository()
        {
            var carpeta = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(carpeta)) Directory.CreateDirectory(carpeta);
        }

        public List<Usuario> ObtenerTodos()
        {
            if (!File.Exists(_filePath)) return new List<Usuario>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }

        public void Registrar(Usuario usuario)
        {
            var usuarios = ObtenerTodos();
            usuario.Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;
            usuarios.Add(usuario);
            Guardar(usuarios);
        }

        public Usuario? ValidarLogin(string username, string password)
        {
            return ObtenerTodos().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        private void Guardar(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}