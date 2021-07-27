using Examen.Data;
using Examen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Socios1Controller
        public ActionResult Index()
        {
            List<Socio> socios = new List<Socio>();
            socios = _context.Socio.ToList();
            return View(socios);
        }

        // GET: Socios1Controller/Details/5
        public ActionResult Details(string id)
        {

            Socio socio = _context.Socio.FirstOrDefault(x => x.Cedula == id);
            return View();
        }

        // GET: Socios1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Socios1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Socio socio)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(socio);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(socio);
            }
        }

        // GET: Socios1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            Socio socio = _context.Socio.FirstOrDefault(x => x.Cedula == Convert.ToString(id));
            return View();
        }

        // POST: Socios1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Socio socio)
        {
            if(id!=Convert.ToInt32(socio.Cedula))
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(socio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }

        // GET: Socios1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Socios1Controller/Delete/5
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
