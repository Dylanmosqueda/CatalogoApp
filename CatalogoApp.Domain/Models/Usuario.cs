using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoApp.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; } // El ? indica que puede ser nulo
        public string? Password { get; set; }
    }
}
