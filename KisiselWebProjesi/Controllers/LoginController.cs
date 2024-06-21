using KisiselWebProjesi.Models.Siniflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KisiselWebProjesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin model)
        {
            if (ModelState.IsValid)
            {
                var bilgiler = _context.Admins.FirstOrDefault(x => x.kullaniciAdi == model.kullaniciAdi && x.sifre == model.sifre);
                if (bilgiler != null)
                {
                    // Kullanıcı doğrulandıysa, oturum aç
                    // FormsAuthentication.SetAuthCookie(bilgiler.kullaniciAdi, false);
                    // Session["kullaniciAdi"] = bilgiler.kullaniciAdi.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Kullanıcı doğrulanamadıysa, hata mesajı göster
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                }
            }

            // Model geçersizse veya kullanıcı doğrulanamadıysa, tekrar login sayfasını göster
            return View();
        }

    }
}
