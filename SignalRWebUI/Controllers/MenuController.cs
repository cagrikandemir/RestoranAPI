using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.TableId = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7111/Product/GetAllProductsWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int Id,int MenuTableId)
        {
            if(MenuTableId == 0)
            {
                TempData["CustomerSelectedTableWarning"] = "Lütfen Bir Masa Seçiniz";
                return RedirectToAction("Index");
            }
            CreateBasketDto createBasketDto = new()
            {
                ProductId = Id,
                MenuTableId = MenuTableId
            };
            //createBasketDto.MenuTableId = int.Parse(TempData["CustomerSelectedTable"].ToString());
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createBasketDto);
            var stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7111/Basket/AddBasket", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
