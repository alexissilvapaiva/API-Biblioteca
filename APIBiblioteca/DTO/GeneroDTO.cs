using APIBiblioteca.Models;

namespace APIBiblioteca.DTO
{
    public class GeneroDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        //causa redundancia cíclica, ingresa a "libro" >> dsp "genero" y asi
        // sucesivamente
        public HashSet<Libro> Libros { get; set; } = new HashSet<Libro>();
    }
}
