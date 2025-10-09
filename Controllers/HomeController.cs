using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebSuportePim.Models;

namespace WebSuportePim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private List<(string Usuario, string Senha)> usuarios = new List<(string, string)>
        {
            ("admin", "123"),
            ("giovanna", "456"),
            ("teste", "abc")
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            bool loginValido = false;

            // Laço para validar usuário
            foreach (var u in usuarios)
            {
                if (u.Usuario == username && u.Senha == password)
                {
                    loginValido = true;
                    break;
                }
            }

            if (loginValido)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos.";
                return View();
            }
        } 

        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}