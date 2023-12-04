using Kaosearch.Models;
using Kaosearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Syncfusion.EJ2.Navigations;

namespace Kaosearch.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly KaomojiService _kaomojiService;

        public HomeController(ILogger<HomeController> logger, KaomojiService kaomojiService) {
            _logger = logger;
            _kaomojiService = kaomojiService;
        }

        public IActionResult Index() {
            List<Kaomoji> listKao = _kaomojiService.ListAll();

            return View(listKao);
        }

        [Route("kaomoji/{id}")]
        public IActionResult Kaomoji(int id) {
            return View(_kaomojiService.GetById(id));
        }

        [Route("submit")]
        public IActionResult Submit() {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Submit(Kaomoji kaomoji) {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}