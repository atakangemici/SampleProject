using Sample.Business.Interfaces;
using Sample.Model.Entities;
using Sample.Model.Interfaces;
using System.Threading.Tasks;
using System.Web;
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
                var hasAdminRight = await _appBusiness.IsValidAdmin(getUser.User);

                if (hasAdminRight.Status)
                {
                    Session.Add("user", getUser.User);

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

            var getProducts = await _appRepository.GetProducts(true);

            if (!getProducts.Status)
            {
                ViewBag.dangerAlert = true;
                ViewBag.alertMessage = getProducts.Message;
            }

            ViewBag.dangerAlert = TempData["dangerAlert"];
            ViewBag.successAlert = TempData["successAlert"];
            ViewBag.alertMessage = TempData["alertMessage"];

            return View(getProducts.Products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Products product, HttpPostedFileBase file)
        {
            var userInfo = (Users)Session["user"];
            var imageName = "";

            if (Request.Files.Count > 0)
            {
                var image = await _appBusiness.UploadImages(Request.Files[0]);

                if (image.Status)
                {
                    imageName = image.ImageName;
                }
            }

            var productData = await _appBusiness.CreateProductDataGenerate(product, userInfo.Id, imageName);

            if (!productData.Status)
            {
                TempData["dangerAlert"] = productData.Status;
                TempData["alertMessage"] = productData.Message;

                return RedirectToAction("Index", productData.Products);
            }

            var addProduct = await _appRepository.AddProduct(productData.Product);

            if (!addProduct.Status)
            {
                TempData["dangerAlert"] = addProduct.Status;
                TempData["alertMessage"] = addProduct.Message;

                return RedirectToAction("Index", addProduct.Products);

            }

            var getProducts = await _appRepository.GetProducts();

            if (!getProducts.Status)
            {
                TempData["dangerAlert"] = getProducts.Status;
                TempData["alertMessage"] = getProducts.Message;
            }

            TempData["successAlert"] = true;
            TempData["alertMessage"] = "Ürün ekleme işlemi başarılı.";


            return RedirectToAction("Index", getProducts.Products);
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            var deleteProduct = await _appRepository.DeleteProduct(id);
            var products = await _appRepository.GetProducts();

            return RedirectToAction("Index", products);
        }

        public async Task<ActionResult> UpdateProduct(int id)
        {
            var userInfo = (Users)Session["user"];
            ViewBag.adminName = userInfo.Name + " " + userInfo.SureName;

            var product = await _appRepository.GetProduct(id);

            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Products product, int id)
        {
            var getProduct = await _appRepository.GetProduct(id);
            var productGenarate = await _appBusiness.UpdateProductDataGenerate(getProduct.Product, product);
            var updateProduct = await _appRepository.UpdateProduct(productGenarate.Product);

            return RedirectToAction("Index");
        }
    }
}