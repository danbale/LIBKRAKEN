using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibMvc.Models;

namespace LibMvc.Controllers
{
    public class PedidosController : Controller
    {
        private Entidades db = new Entidades();

        // GET: Pedidoes
        public ActionResult Index()
        {
            var pedidoes = db.Pedidoes.Include(p => p.Proveedor).Include(p => p.Usuario);
            return View(pedidoes.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Proveedor = new SelectList(db.Proveedors, "NIF", "Empresa");
            ViewBag.Id_Solicitor = new SelectList(db.Usuarios, "Id", "Apellidos");
            return View();
        }

        // POST: Pedidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Autores,ISBN,Id_Solicitor,Id_Proveedor,Fecha_Orden,Fecha_Recibido,Precio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidoes.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Proveedor = new SelectList(db.Proveedors, "NIF", "Empresa", pedido.Id_Proveedor);
            ViewBag.Id_Solicitor = new SelectList(db.Usuarios, "Id", "Apellidos", pedido.Id_Solicitor);
            return View(pedido);
        }

        // GET: Pedidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Proveedor = new SelectList(db.Proveedors, "NIF", "Empresa", pedido.Id_Proveedor);
            ViewBag.Id_Solicitor = new SelectList(db.Usuarios, "Id", "Apellidos", pedido.Id_Solicitor);
            return View(pedido);
        }

        // POST: Pedidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Autores,ISBN,Id_Solicitor,Id_Proveedor,Fecha_Orden,Fecha_Recibido,Precio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Proveedor = new SelectList(db.Proveedors, "NIF", "Empresa", pedido.Id_Proveedor);
            ViewBag.Id_Solicitor = new SelectList(db.Usuarios, "Id", "Apellidos", pedido.Id_Solicitor);
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
