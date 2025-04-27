using HomeRentApp.Data;
using HomeRentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HomeRentApp.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly HomeRentContextSQLServer _context;

        public DepartamentoController(HomeRentContextSQLServer context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departamentos = _context.Departamento.ToList();
            return View(departamentos);
        }

        public IActionResult Agregar()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Departamento.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction("Index", "Departamento");
            }
            return View(departamento);
        }

    }
}
