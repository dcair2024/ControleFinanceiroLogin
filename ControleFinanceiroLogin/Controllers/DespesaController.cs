using ControleFinanceiroLogin.Data;
using ControleFinanceiroLogin.Filters;
using ControleFinanceiroLogin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiroLogin.Controllers
{
    [Autenticado] // protege todas as rotas
    public class DespesaController : Controller
    {
        private readonly AppDbContext _context;

        public DespesaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            var despesas = await _context.Despesas
                .Where(d => d.UsuarioId == usuarioId)
                .ToListAsync();

            return View(despesas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                despesa.UsuarioId = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                _context.Despesas.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(despesa);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            return View(despesa);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                _context.Despesas.Update(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(despesa);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            return View(despesa);
        }

        [HttpPost, ActionName("Excluir")]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            var despesa = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}




