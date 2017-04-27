using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelASP.DAL;
using HotelASP.Models;

namespace HotelASP.Controllers
{
    public class HospedesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Hospedes
        public ActionResult Index()
        {
            return View(db.Hospedes.ToList());
        }

        // GET: Hospedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospede hospede = db.Hospedes.Find(id);
            if (hospede == null)
            {
                return HttpNotFound();
            }
            return View(hospede);
        }

        // GET: Hospedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospedes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome, Sobrenome, Email, CPF, Endereco")]Hospede hospede)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Hospedes.Add(hospede);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Nao foi possicel criar um novo hospede, se o problema persistir, contacte o Administrador do sistema.");
            }

            return View(hospede);
        }

        // GET: Hospedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospede hospede = db.Hospedes.Find(id);
            if (hospede == null)
            {
                return HttpNotFound();
            }
            return View(hospede);
        }

        // POST: Hospedes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hospedeAlterado = db.Hospedes.Find(id);
            if (TryUpdateModel(hospedeAlterado, "",
               new string[] { "Nome, Sobrenome, Email, CPF, Endereco" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    ModelState.AddModelError("", "Nao foi possicel alterar o hospede, se o problema persistir, contacte o Administrador do sistema.");
                }
            }
            return View(hospedeAlterado);
        }

        // GET: Hospedes/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Nao foi possicel alterar o hospede, se o problema persistir, contacte o Administrador do sistema.";
            }
            Hospede hospede = db.Hospedes.Find(id);
            if (hospede == null)
            {
                return HttpNotFound();
            }
            return View(hospede);
        }

        // POST: Hospedes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Hospede hospede = db.Hospedes.Find(id);
                db.Hospedes.Remove(hospede);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
