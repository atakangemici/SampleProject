using Sample.Business.Interfaces;
using Sample.Model.Entities;
using Sample.Model.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.App.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppRepository _appRepository;
        private readonly IAppBusiness _appBusiness;

        public HomeController(IAppRepository appRepository, IAppBusiness appBusiness)
        {
            _appRepository = appRepository;
            _appBusiness = appBusiness;
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
                var hasAdminRight = await _appBusiness.IsValidAdmin(getUser);

                if (hasAdminRight.Status)
                {
                    Session.Add("user", getUser);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.validMessage = hasAdminRight.Message;
                }
            }
            else
            {
                ViewBag.validMessage = "Kullanıcı bulunamadı.";
            }

            return View();
        }

        public async Task<ActionResult> Index()
        {

            if (Session["user"] == null)
                return RedirectToAction("Login");

            var userInfo = (Users)Session["user"];

            ViewBag.adminName = userInfo.Name + " " + userInfo.SureName;

            var products = await _appRepository.GetProducts();

            return View(products);
        }
    }
}