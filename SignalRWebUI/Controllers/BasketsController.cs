using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.BasketDtos;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int Id)
        {
            TempData["Id"] = Id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7111/Basket/BasketListByMenuTableWithProductName?Id="+Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id,int menuTableId)
        {
            menuTableId=int.Parse(TempData["Id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7111/Basket/DeleteBasket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { Id = menuTableId });
            }
            return NoContent();
        }
    }
}
