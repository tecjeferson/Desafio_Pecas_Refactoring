using LojaAutoPecas.Data;
using LojaAutoPecas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaAutoPecas.Controllers
{
    public class PecasController : Controller
    {
        // GET: Pecas
        private PecasBO pbo = new PecasBO();

        
        // GET: Pecas
        public ActionResult Index(PecasBO model)
        {

            var ListItem = pbo.GetPecas().ToList();

            return View(ListItem);
        }

        [HttpGet]
        public ActionResult SearchResult()
        {
            var ListItem = pbo.GetPecas().ToList();

           return View(ListItem);
        }

        [HttpPost]
        public ActionResult SearchResult(string name, string description, int? id)
        {

            var ListItens = pbo.Search(name, description, id).ToList();

            
            return View(ListItens);
            

        }

        // GET: Pecas/Details/5

        [HttpGet]
        public ActionResult FindById()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindById(int? id)
        {
            var ListById = pbo.GetById(id);

            if (ListById != null)
            {
                return View(ListById);
            }
            return View();

        }

     

        [HttpPost]
        public ActionResult Create(Pecas pecas)
        {
            try
            {
                pbo.Create(pecas);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                throw err;
            }


        }


        [HttpGet]// GET: Pecas/Create
        public ActionResult Create()
        {

            return View();
        }


        // GET: Pecas/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var ListById = pbo.GetById(id);

            if (ListById != null)
            {
                return View(ListById);
            }
            return View();
        }

        // POST: Pecas/Edit/5
        [HttpPost]
        public ActionResult Edit(Pecas pecas)
        {
            try
            {
                pbo.Edit(pecas);
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        // GET: Pecas/Delete/5
        public ActionResult Delete(int? id)
        {
            var ListById = pbo.GetById(id);

            if (ListById != null)
            {
                return View(ListById);
            }
            return View();
        }

        // POST: Pecas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                pbo.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    
    }
}