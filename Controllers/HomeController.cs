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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)  // Corrigido: minúscula para combinar com a view
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.ValidarLogin(email, senha);

            if (usuario != null)
            {
                // Armazena informações do usuário na sessão
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                HttpContext.Session.SetString("UsuarioDepartamento", usuario.Departamento);
                HttpContext.Session.SetString("UsuarioEmail", usuario.Email);

                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Usuário ou senha inválidos.";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ChamadosAbertos()
        {
            return View();
        }

        public IActionResult AbrirNovoChamado()
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