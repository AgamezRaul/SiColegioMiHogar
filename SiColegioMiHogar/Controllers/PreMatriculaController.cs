using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiColegioMiHogar.Controllers
{
    public class PreMatriculaController : Controller
    {
        // GET: PreMatriculaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PreMatriculaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PreMatriculaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PreMatriculaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PreMatriculaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PreMatriculaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PreMatriculaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PreMatriculaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
