using Microsoft.AspNetCore.Mvc;
using KisiselWebProjesi.Models.Siniflar;

namespace KisiselWebProjesi.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var deger = _context.AnaSayfas.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int id)
        {
            var ag = _context.AnaSayfas.Find(id);
            if (ag == null)
            {
                return NotFound();
            }
            return View("AnaSayfaGetir", ag);
        }

        [HttpPost]
        public ActionResult AnaSayfaGuncelle(AnaSayfa x)
        {
            var ag = _context.AnaSayfas.Find(x.id);
            if (ag == null)
            {
                return NotFound();
            }
            ag.isim = x.isim;
            ag.profil = x.profil;
            ag.unvan = x.unvan;
            ag.aciklama = x.aciklama;
            ag.iletisim = x.iletisim;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IkonListesi()
        {
            var deger = _context.ikonlars.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniIkon(ikonlar p)
        {
            if (ModelState.IsValid)
            {
                _context.ikonlars.Add(p);
                _context.SaveChanges();
                return RedirectToAction("IkonListesi");
            }
            return View(p);
        }

        public ActionResult ikonGetir(int id)
        {
            var ig = _context.ikonlars.Find(id);
            if (ig == null)
            {
                return NotFound();
            }
            return View("ikonGetir", ig);
        }

        [HttpPost]
        public ActionResult ikonGuncelle(ikonlar x)
        {
            var ig = _context.ikonlars.Find(x.id);
            if (ig == null)
            {
                return NotFound();
            }
            ig.ikon = x.ikon;
            ig.link = x.link;
            _context.SaveChanges();
            return RedirectToAction("IkonListesi");
        }

        public ActionResult ikonSil(int id)
        {
            var sl = _context.ikonlars.Find(id);
            _context.ikonlars.Remove(sl);
            _context.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
    }
}

