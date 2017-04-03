namespace LibMvc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Entidades : DbContext
    {
        public Entidades()
            : base("name=Entidades")
        {
        }

        public virtual DbSet<Pedido> Pedidoes { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.Pedidos)
                .WithRequired(e => e.Proveedor)
                .HasForeignKey(e => e.Id_Proveedor);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedidoes)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Id_Solicitor);
        }
    }
}
