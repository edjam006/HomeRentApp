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
                var usuarioId = HttpContext.Session.GetString("UsuarioId");

                if (string.IsNullOrEmpty(usuarioId))
                {
                    return RedirectToAction("Login", "Usuario"); // redirige si no está logueado
                }

                departamento.UsuarioId = usuarioId; // asigna el usuario correcto

                _context.Departamento.Add(departamento);
                _context.SaveChanges(); // guarda el departamento en la base

                return RedirectToAction("Index", "Departamento"); // redirige a lista
            }

            return View(departamento); // si hay errores, vuelve a la vista
        }






    }
}
