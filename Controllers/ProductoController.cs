using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    [Authorize(Users = "sulemavelez1999@outlook.es")]
    public class ProductoController : Controller
    {
        RemisionContext db = new RemisionContext();
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Productos);
        }
        // GET: Guia/Details/5
        public ActionResult Details(int id)
        {
            Producto producto = db.Productos.Single(g => g.Id == id);
            return View(producto);
        }

        // GET: Guia/Create
        public ActionResult Create()
        {
            
            Producto producto = new Producto()
            {

                Cantidad= "",
                Descripcion = "",
                

            };
            return View(producto);
        }

        // POST: Guia/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            try
            {
                // TODO: Add insert logic here
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            catch
            {
                return View();
            }
        }

        // GET: Guia/Edit/5
        public ActionResult Edit(int id)
        {

            Producto producto = db.Productos.Single(g => g.Id == id);
            return View();
        }

        // POST: Guia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Producto producto = db.Productos.Single(g => g.Id == id);
                if (TryUpdateModel<Producto>(producto))
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
            Producto producto = db.Productos.Single(g => g.Id == id);
            return View();
        }

        // POST: Guia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Producto producto = db.Productos.Single(g => g.Id == id);
                db.Productos.Remove(producto);
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
