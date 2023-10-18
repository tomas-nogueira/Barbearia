using Barbearia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace Barbearia.Controllers
{
    public class HomeController : Controller
    {
        private readonly Contexto _context;
              
        public HomeController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string pesquisa)
        {
            if(string.IsNullOrWhiteSpace(pesquisa))
            {
                var contexto = _context.Salao.Include(s => s.User);
                return View(await contexto.ToListAsync());
            }
            else
            {
                var salao =
                _context.Salao 
                .Where(x => x.NameSalao.Contains(pesquisa)) 
                .OrderBy(x => x.NameSalao); 
                return View(salao);
            }           
        }

        public IActionResult Privacy()
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