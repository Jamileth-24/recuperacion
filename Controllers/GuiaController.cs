using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    [Authorize(Users = "sulemavelez1999@outlook.es, e1316450319@live.uleam.edu.ec")]
    public class GuiaController : Controller
    {
        RemisionContext db = new RemisionContext();
        // GET: Guia
        public ActionResult Index()
        {
            return View(db.Guias);
        }
        [Authorize(Users = "e1316450319@live.uleam.edu.ec")]
        public ActionResult IndexFechaTransportista(string Filtro)
        {
            var x = from r in db.Guias orderby r.FechaInicio select r;
            if (Filtro != null)
            {
                ViewBag.Filtro = Filtro;
                string num = Filtro;
                x = from s in db.Guias where s.FechaInicio.StartsWith(num) orderby s.FechaInicio select s;

            }
            return View(x);
        }
        public ActionResult IndexProductoTransportista(string Filtro)
        {
            var x = from r in db.Productos orderby r.Descripcion select r;
            if (Filtro != null)
            {
                ViewBag.Filtro = Filtro;
                string num = Filtro;
                x = from s in db.Productos where s.Descripcion.StartsWith(num) orderby s.Descripcion select s;

            }
            return View(x);
        }


        // GET: Guia/Details/5
        public ActionResult Details(int id)
        {
            Guia guia = db.Guias.Single(g => g.Id == id);
            return View(guia);
        }

        // GET: Guia/Create
        public ActionResult Create()
        {
            
            ViewBag.IdTransportista = new SelectList(db.Transportistas, "Id", "RazonSocial");
            ViewBag.IdDestinatario = new SelectList(db.Destinatarios, "Id", "RazonSocial");
            Guia guia= new Guia()
            {
                
                  FechaInicio = "",
                 FechaFin = "",
                  Tipo = "",
                  NoAutorizacion = "",
                    NoComprobante = "",
                ListaProducto = new List<Producto>
                {
                    new Producto
                    {
                        Descripcion ="",
                        Cantidad =""
                    }
                }

            };
            return View(guia);
        }

        // POST: Guia/Create
        [HttpPost]
        public ActionResult Create(Guia guia, string submit)
        {
            try
            {
                switch (submit)
                {
                    case "Crear":
                        db.Guias.Add(guia);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    case "Agregar":

                        guia.ListaProducto.Add(new Producto { Descripcion = "Nuevo" , Cantidad = "Nuevo"});
                        ViewBag.IdTransportista = new SelectList(db.Transportistas, "Id", "RazonSocial");
                        ViewBag.IdDestinatario = new SelectList(db.Destinatarios, "Id", "RazonSocial");
                        return View(guia);
                    default:
                        return Content("Opcion no valida");
                }
            }
               
            
            catch
            {
                return View();
            }
        }

        // GET: Guia/Edit/5
        public ActionResult Edit(int id)
        {
           
            ViewBag.IdTransportista = new SelectList(db.Transportistas, "Id", "RazonSocial");
            ViewBag.IdDestinatario = new SelectList(db.Destinatarios, "Id", "RazonSocial");
            Guia guia = db.Guias.Single(g => g.Id == id);
            return View();
        }

        // POST: Guia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Guia guia = db.Guias.Single(g => g.Id == id);
                if (TryUpdateModel<Guia>(guia))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Guia/Delete/5
        public ActionResult Delete(int id)
        {
            Guia guia = db.Guias.Single(g => g.Id == id);
            return View();
        }

        // POST: Guia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Guia guia = db.Guias.Single(g => g.Id == id);
                db.Guias.Remove(guia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
