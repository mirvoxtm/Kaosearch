using Kaosearch.Models;
using Kaosearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Syncfusion.EJ2.Navigations;
using System.Collections.Generic;

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

        [Route("success")]
        public IActionResult Success() {
            return View();
        }

        [HttpPost]
        [Route("submit")]
        [AutoValidateAntiforgeryToken]
        public IActionResult Submit(Kaomoji kaomoji) {

            if (ModelState.IsValid) {
                _kaomojiService.SubmitKaomoji(kaomoji);
                return View("success");
            }
           
            return View();
        }

        public IActionResult Search(string query) {
            List<Kaomoji> queryList = _kaomojiService.ListAll();
            List<Kaomoji> filteredItems = new List<Kaomoji>();

            foreach(var kaomoji in queryList) {
                if (kaomoji.Tags.Contains(query)) {
                filteredItems.Add(kaomoji);
            }
        }

        return View(filteredItems);
        }


        [Route("404")]
        public IActionResult PageNotFound() {
            string originalPath = "unknown";
            if (HttpContext.Items.ContainsKey("originalPath")) {
                originalPath = HttpContext.Items["originalPath"] as string;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}