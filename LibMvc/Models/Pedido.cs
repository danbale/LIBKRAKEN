namespace LibMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(250)]
        public string Autores { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }

        public int Id_Solicitor { get; set; }

        public int Id_Proveedor { get; set; }

        public DateTime Fecha_Orden { get; set; }

        public DateTime Fecha_Recibido { get; set; }

        public double Precio { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
