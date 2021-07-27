using Examen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Socio> Socio { get; set; }
        public virtual DbSet<Cuenta> Cuentas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Socio>(a =>
            {
                a.HasKey(c => c.Cedula);
                a.Property(c => c.Nombre).IsRequired().HasMaxLength(100).IsUnicode(false);
                a.Property(c => c.Apellido).IsRequired().HasMaxLength(100).IsUnicode(false);
                a.Property(c => c.Direccion).IsRequired().HasMaxLength(250).IsUnicode(false);
                a.Property(c => c.Estado).IsRequired();
            }
            );
            base.OnModelCreating(builder);
            builder.Entity<Cuenta>(a =>
            {
                a.HasKey(c => c.Numero);
                a.Property(c => c.SaldoTotal).IsRequired().HasMaxLength(100).IsUnicode(false);
                a.Property(c => c.CodigoSocio).IsRequired().HasMaxLength(100).IsUnicode(false);
                a.Property(c => c.Estado).IsRequired();
            }
            );
        }
    }
}
