using Microsoft.EntityFrameworkCore;
using Parcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Data
{
    

   public class AppDbContext : DbContext
    {
        internal object cartas;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<carta> carta { get; set; }
    }
}
//Parcial.Models.carta