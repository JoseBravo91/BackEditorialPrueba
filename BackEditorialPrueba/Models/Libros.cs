using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEditorialPrueba.Models
{
    public class Libros
    {
        
        public int Id { get; set; }

        [Required]
        public int IdAutor { get; set; }
      
        [Required]
        public int IdEditorial { get; set; }
        

        [Required]
        public string Titulo { get; set; }

        public string AnoPublicacion { get; set; }
        public string Genero { get; set; }

        public string Paginas { get; set; }

    }
}
