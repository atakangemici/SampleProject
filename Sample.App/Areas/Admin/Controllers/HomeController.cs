using Sample.Business.Controllers;
using Sample.Model.DbModel;
using Sample.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sample.App.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppRepository _appRepository;

        public HomeController(SampleDbContext context, IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            var getUser = await _appRepository.GetUser(email, password);

            if (getUser != null)
            {
                var hasAdminRightCheck = await AppController.IsValidAdmin(getUser);

                if (hasAdminRightCheck.Status == true)
                {
                    Session.Add("login", getUser);

                    return View("Index");
                }
                else
                {
                    ViewBag.validMessage = hasAdminRightCheck.Message;
                }
            }
            else
            {
                ViewBag.validMessage = "Kullanıcı bulunamadı.";
            }


            return View();
        }

        public ActionResult Index()
        {
            var result = (Users)Session["login"];

            if (result == null)
                return View("Login");


            return View();
        }
    }
}