using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    [Authorize(Users = "sulemavelez1999@outlook.es")]
    public class DestinatarioController : Controller
    {
        
        RemisionContext db = new RemisionContext();
        // GET: Destinatario
        public ActionResult Index()
        {
            return View(db.Destinatarios);
        }


        // GET: Destinatario/Details/5
        public ActionResult Details(int id)
        {
            Destinatario destinatario = db.Destinatarios.Single(g => g.Id == id);
            return View(destinatario);
            
        }

        // GET: Destinatario/Create
        public ActionResult Create()
        {
            Destinatario destinatario = new Destinatario()
            {
                CI = "",
                RazonSocial = ""
              
            };
            return View(destinatario);
        }

        // POST: Destinatario/Create
        [HttpPost]
        public ActionResult Create(Destinatario destinatario)
        {
            try
            {
                // TODO: Add insert logic here
                db.Destinatarios.Add(destinatario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Destinatario/Edit/5
        public ActionResult Edit(int id)
        {
            Destinatario destinatario = db.Destinatarios.Single(g => g.Id == id);
            return View(destinatario);
        }

        // POST: Destinatario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Destinatario destinatario = db.Destinatarios.Single(g => g.Id == id);
                if (TryUpdateModel<Destinatario>(destinatario))
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

        // GET: Destinatario/Delete/5
        public ActionResult Delete(int id)
        {
            Destinatario destinatario = db.Destinatarios.Single(g => g.Id == id);
            return View(destinatario);
        }

        // POST: Destinatario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Destinatario destinatario = db.Destinatarios.Single(g => g.Id == id);
                db.Destinatarios.Remove(destinatario);
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
