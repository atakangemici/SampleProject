using Sample.Model.Entities;
using Sample.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            var products = await _appRepository.GetProducts();

            return View(products);
        }
    }
}