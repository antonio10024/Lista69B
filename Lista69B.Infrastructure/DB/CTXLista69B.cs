using Lista69B.Domain;
using Lista69B.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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

        private readonly IUsuario _usuario;
        public CTXLista69B(DbContextOptions options,IUsuario usuario) : base(options)
        {
            _usuario = usuario;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
        {
            foreach ( var entity in ChangeTracker.Entries<Auditable>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.UsuarioCreo = _usuario.Usuario();
                        entity.Entity.FechaCreacion = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entity.Entity.UsuarioCreo = _usuario.Usuario();
                        entity.Entity.FechaModificacion = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync( cancellationToken);
        }

        public DbSet<Lista69BEntity> lista69B { get; set; }
        public DbSet<Lista69BRegistroEntity> listaRegistro { get; set; }

        public DbSet<ListaSeguimiento> listaSeguimientos { get; set; }
        public DbSet<WatchListSweep> watchListSweeps { get; set; }
        public DbSet<FoundWatchList> foundWatchLists { get; set; }

    }
}
