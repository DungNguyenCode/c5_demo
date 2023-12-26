using AppData.Model;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7251/api/Product/GetAll");
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Product pro)
        {
            var item = await _httpClient.PostAsJsonAsync<Product>("https://localhost:7251/api/Product/Post", pro);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("[action]/{ma}")]
        public async Task<IActionResult> Edit(string ma)
        {
            var item = await _httpClient.GetFromJsonAsync<Product>($"https://localhost:7251/api/Product/GetByMa/{ma}");
            return View(item);
        }
        [HttpPost]
        [Route("[action]/{ma}")]
        public async Task<IActionResult> Edit(Product pro)
        {
            var item = await _httpClient.PutAsJsonAsync<Product>($"https://localhost:7251/api/Product/Put/{pro.Ma}", pro);
            return RedirectToAction("Index");
        }
       
        [Route("[action]/{ma}")]
        public async Task<IActionResult> Delete(Product pro)
        {
            var item = await _httpClient.DeleteAsync($"https://localhost:7251/api/Product/Delete/{pro.Ma}");
            return RedirectToAction(nameof(Index));
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