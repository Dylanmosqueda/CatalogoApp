namespace CatalogoApp.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Consola { get; set; }
        public int Ano { get; set; }
        public string Descripcion { get; set; }

        // Propiedad de navegación para las reseñas
        public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
    }
}