using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEditorialPrueba.Models
{
    public class Editoriales
    {
        
        public int Id{ get; set; }        
            
        [Required]
        public string NombreEditorial { get; set; }

        [Required]
        public string DireccionCorrespondencia { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        [Required]
        public int MaximoLibrosRegistrados { get; set; }

    }
}
