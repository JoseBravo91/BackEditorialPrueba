using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEditorialPrueba.Models.ModelStructure
{
    public class AutoresDto
    {

        public int Id { get; set; }


        [Required]
        public int IdEditorial { get; set; }

        [Required]
        public string NombreAutor { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }

        public string CorreoElectronico { get; set; }

        public string NombreEditorial { get; set; }
    }
}
