using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LibMvc.Servicios.Repositorios
{
    interface ProveedorRepositorio<ProveedorDTO>
    {
         void Create(ProveedorDTO proveedor);
    }
}
