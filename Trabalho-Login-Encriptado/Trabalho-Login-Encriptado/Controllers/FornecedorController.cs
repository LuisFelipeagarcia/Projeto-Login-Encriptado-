using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho_Login_Encriptado.Context;
using Trabalho_Login_Encriptado.Models;

namespace Trabalho_Login_Encriptado.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly Contexto db = new Contexto();

        #region Index
        public ActionResult Index()
        {
            return View(db.Fornecedores.ToList());
        }
        #endregion

        #region Create

        //GET: Create
        public ActionResult Create()
        {

            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorModel forn)
        {
            if (ModelState.IsValid)
            {
                db.Fornecedores.Add(forn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forn);
        }
        #endregion

        #region Details
        // GET: Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            FornecedorModel forn = db.Fornecedores.Find(id);
            if (forn == null)
            {
                return HttpNotFound();
            }
            return View(forn);
        }
        #endregion

        #region Edit - GET
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            FornecedorModel forn = db.Fornecedores.Find(id);
            if (forn == null)
            {
                return HttpNotFound();
            }
            return View(forn);
        }

        #endregion

        #region Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorModel forn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(forn);
        }
        #endregion

        #region Delete - GET
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel forn = db.Fornecedores.Find(id);
            if (forn == null)
            {
                return HttpNotFound();
            }
            return View(forn);
        }

        #endregion

        #region Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FornecedorModel forn = db.Fornecedores.Find(id);
            db.Fornecedores.Remove(forn);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}