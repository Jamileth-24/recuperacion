using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    [Authorize(Users = "sulemavelez1999@outlook.es")]
    public class TransportistaController : Controller
    {
        RemisionContext db = new RemisionContext();
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Transportistas);
        }
        // GET: Guia/Details/5
        public ActionResult Details(int id)
        {
            Transportista transportista = db.Transportistas.Single(g => g.Id == id);
            return View(transportista);
        }

        // GET: Guia/Create
        public ActionResult Create()
        {

            Transportista transportista = new Transportista()
            {
                
                    CI= "",
                    RazonSocial = "",

              
            };
            return View(transportista);
        }

        // POST: Guia/Create
        [HttpPost]
        public ActionResult Create(Transportista transportista)
        {
            try
            {
                // TODO: Add insert logic here
                db.Transportistas.Add(transportista);
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

            Transportista transportista = db.Transportistas.Single(g => g.Id == id);
            return View(transportista);
        }

        // POST: Guia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Transportista transportista = db.Transportistas.Single(g => g.Id == id);
                if (TryUpdateModel<Transportista>(transportista))
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
            Transportista transportista = db.Transportistas.Single(g => g.Id == id);
            return View(transportista);
        }

        // POST: Guia/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Transportista transportista = db.Transportistas.Single(g => g.Id == id);
                db.Transportistas.Remove(transportista);
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
