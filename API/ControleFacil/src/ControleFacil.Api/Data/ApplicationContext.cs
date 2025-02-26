using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Data.Mappings;
using ControleFacil.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<NaturezaDeLancamento> NaturezaDeLancamento { get; set; }

        public DbSet<Apagar> Apagar { get; set; }

        public DbSet<Areceber> Areceber { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new NaturezaDeLancamentoMap());
            modelBuilder.ApplyConfiguration(new ApagarMap());
            modelBuilder.ApplyConfiguration(new AreceberMap());
        }
    }
}