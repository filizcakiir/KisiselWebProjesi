using Microsoft.AspNetCore.Mvc;
using KisiselWebProjesi.Models.Siniflar;
using System.Linq;

namespace KisiselWebProjesi.Controllers
{
    public class AnaSayfaController : Controller
    {
        private readonly Context _context;

        public AnaSayfaController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deger = _context.AnaSayfas.ToList();
            return View(deger);
        }
    }
}
