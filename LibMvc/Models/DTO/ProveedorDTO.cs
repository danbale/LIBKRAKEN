using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibMvc.Models.DTO
{
    public class ProveedorDTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProveedorDTO()
        {
            Pedidos = new HashSet<Pedido>();
        }

      
        public int NIF { get; set; }
       
        public string Empresa { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string Fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}
