using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer;
using PresentationLayer;
using PresentationLayer.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public HomeController(DataManager datamanager)
        {
            _datamanager = datamanager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            //HelloModel _model = new HelloModel() { HelloMessage = "Hey Aleksander!" };
            //List<Directory> _dirs = _context.Directory.Include(x => x.Materials).ToList();
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();
            return View(_dirs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Описание вашего первого ASP.NET приложения.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Контакты компании.";

            return View();
        }

        public IActionResult Faq()
        {
            ViewData["Message"] = "Вопросы и ответы.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
