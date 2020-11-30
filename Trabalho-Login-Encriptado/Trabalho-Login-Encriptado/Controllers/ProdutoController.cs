using Trabalho_Login_Encriptado.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Trabalho_Login_Encriptado.Context;

namespace Trabalho_Login_Encriptado.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Contexto db = new Contexto();

        // GET: Dobrador
        public ActionResult Index()
        {
            var Produto = db.Produtos.Include(a => a.Fornecedor).ToList();
            return View(Produto);
        }

        #region Create
        //GET: Create
        public ActionResult Create()
        {

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome");
            return View();
        }
        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel prod)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(prod);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", prod.FornecedorId);
            return View(prod);
        }
        #endregion

        #region Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProdutoModel prod = db.Produtos.Include(e => e.Fornecedor).First(d => d.Id == id);

            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }
        #endregion

        #region Edit
        //GET: Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProdutoModel dobradorModel = db.Produtos.Find(id);
            if (dobradorModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", dobradorModel.FornecedorId);
            return View(dobradorModel);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoModel prod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.FornecedorId = new SelectList(db.Fornecedores, "Id", "Nome", prod.FornecedorId);
            return View(prod);
        }
        #endregion

        #region Delete
        //GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ProdutoModel prod = db.Produtos.Include(e => e.Fornecedor).First(d => d.Id == id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoModel prod = db.Produtos.Find(id);
            db.Produtos.Remove(prod);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}