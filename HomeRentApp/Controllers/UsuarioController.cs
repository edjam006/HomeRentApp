using HomeRentApp.Data;
using HomeRentApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeRentApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly HomeRentContextSQLServer _context;

        public UsuarioController(HomeRentContextSQLServer context)
        {
            _context = context;
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");  // Guarda el usuario si los datos son válidos y mientras tanto redirige al inicio mientras se hace el otro flujo
            }
            return View(usuario);
        }

    }
}
