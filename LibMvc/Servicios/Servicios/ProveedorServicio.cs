using LibMvc.Servicios.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibMvc.Models.DTO;

using System.Web.Mvc;
using LibMvc.Models;

namespace LibMvc.Servicios
{
    public class ProveedorServicio
    {
        private Entidades db = new Entidades();


        internal void Create(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.NIF = proveedorDTO.NIF;
            db.Proveedors.Add(proveedor);
            db.SaveChanges();
        }

    }

}