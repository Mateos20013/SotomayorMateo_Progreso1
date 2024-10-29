using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SotomayorMateo_Progreso1.Models;

namespace SotomayorMateo_Progreso1.Data
{
    public class SotomayorMateo_Progreso1Context : DbContext
    {
        public SotomayorMateo_Progreso1Context (DbContextOptions<SotomayorMateo_Progreso1Context> options)
            : base(options)
        {
        }

        public DbSet<SotomayorMateo_Progreso1.Models.Sotomayor> Sotomayor { get; set; } = default!;
        public DbSet<SotomayorMateo_Progreso1.Models.Celular> Celular { get; set; } = default!;
    }
}
