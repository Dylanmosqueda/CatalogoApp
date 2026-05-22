# CatalogoApp
Este proyecto es una aplicación web de catálogo de videojuegos desarrollada con ASP.NET Core MVC. Es una solución integral que combina un sistema de gestión de datos local (basado en archivos JSON) con una interfaz web temática y un sistema de autenticación de usuarios.
El proyecto utiliza una arquitectura en capas para separar las responsabilidades:
Dominio (CatalogoApp.Domain): Contiene los "Modelos" de datos (Item, Usuario, Resena). Es el corazón de la lógica, donde se definen las estructuras que representan el catálogo y las interacciones sociales.
Infraestructura (CatalogoApp.Infrastructure): Aquí vive la persistencia. Se encarga de leer y escribir archivos JSON (items.json, usuarios.json, reviews.json) que actúan como base de datos. Cada repositorio (JsonItemRepository, JsonUserRepository, etc.) implementa métodos para crear, leer y guardar estos archivos.
Presentación (CatalogoApp.Presentation): Es la cara visible. Contiene los Controladores (que procesan las peticiones HTTP, como mostrar un detalle o enviar una reseña) y las Vistas (archivos .cshtml que renderizan el HTML).
Tecnologias usadas: Utilice AI Studio para darle estiolo a la actividad y par corregir los errores que me aparecian, tambien para crear nuevas clases
