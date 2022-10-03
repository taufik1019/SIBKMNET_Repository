using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_WebApps.Repositories.Data;
using SIBKMNET_WebApps.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApps.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            // statement mengambil data dari database sesuai dengan email dan password
            var data = accountRepository.Login(login);
            if(data != null)
            {
                HttpContext.Session.SetString("Role", data.Role);
                return RedirectToAction("Index", "Province");
            }
            return View();
            // return -> Id Employee, FullName, Email, Role -> Viewmodels
            // inisialisasi nilai padaa session

        }
    }
}
