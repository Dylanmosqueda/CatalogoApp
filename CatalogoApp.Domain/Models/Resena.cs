using CatalogoApp.Domain.Models;

public class Resena
{
    public int Id { get; set; }

    // Agrega esta propiedad para almacenar el ID del usuario
    public int UsuarioId { get; set; }

    public string Usuario { get; set; } // Nombre visible
    public string Comentario { get; set; }
    public int Calificacion { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int ItemId { get; set; }
    public Item Item { get; set; }
}