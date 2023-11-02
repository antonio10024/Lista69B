using Lista69B.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB
{
    public class CTXLista69B:DbContext
    {
        public CTXLista69B(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
        }
       
        public DbSet<Lista69BEntity> lista69B { get; set; }
        public DbSet<Lista69BRegistroEntity> listaRegistro { get; set; }

    }
}
