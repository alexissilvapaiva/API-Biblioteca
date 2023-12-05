﻿using APIBiblioteca.Models;

namespace APIBiblioteca.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public bool ParaPrestar { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        public string NombreAutor {  get; set; }
        public string NombreGenero {  get; set; }

        public HashSet<ListaComentariosDTO> Comentarios { get; set; } = new HashSet<ListaComentariosDTO>();
    }
}
