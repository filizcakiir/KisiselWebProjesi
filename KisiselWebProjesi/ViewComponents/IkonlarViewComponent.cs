using KisiselWebProjesi.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace KisiselWebProjesi.ViewComponents
{
    public class IkonlarViewComponent : ViewComponent
    {
        private readonly Context _context;
        private readonly ILogger<IkonlarViewComponent> _logger;

        public IkonlarViewComponent(Context context, ILogger<IkonlarViewComponent> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ikonlar = await Task.Run(() => _context.ikonlars.ToList());
            if (ikonlar == null || !ikonlar.Any())
            {
                _logger.LogWarning("Ikonlar bulunamadı veya boş.");
            }
            return View(ikonlar);
        }
    }
}
