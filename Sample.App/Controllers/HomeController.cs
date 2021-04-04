using Sample.Model.Entities;
using Sample.Model.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sample.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppRepository _appRepository;

        public HomeController(SampleDbContext context, IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<ActionResult> Index()
        {
            var getProducts = await _appRepository.GetProducts();

            if (!getProducts.Status)
            {
                ViewBag.dangerAlert = true;
                ViewBag.dangerMessage = getProducts.Message;
            }

            return View(getProducts.Products);
        }
    }
}