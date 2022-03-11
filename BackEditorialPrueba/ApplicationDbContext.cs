using BackEditorialPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEditorialPrueba
{
    public class ApplicationDbContext : DbContext //Crea una instancia en la BD para querys
    {
        public DbSet<Editoriales> Editorial { get; set; }
        public DbSet<Autores> Autor { get; set; }
        public DbSet<Libros> Libro { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }
    }
}
