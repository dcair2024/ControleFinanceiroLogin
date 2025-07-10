using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiroLogin.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
