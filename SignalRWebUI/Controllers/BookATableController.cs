using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            HttpClient client = new();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7111/Contact/GetAll");
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            JArray jsonArray = JArray.Parse(responseBody);
            string value = jsonArray[0]["location"].ToString();
            ViewBag.Location = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage)
            //        .ToList();

            //    TempData["ValidationErrors"] = string.Join("||", errors);

            //    return View(createBookingDto);
            //}
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7111/Booking/Add", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"]= "Rezervasyonunuz başarıyla oluşturuldu!";
                return RedirectToAction("Index","Default");
            }
            else
            {
                TempData["ErrorMessage"] = "Rezervasyon oluşturulurken bir hata oluştu. Lütfen tekrar deneyiniz.";
                HttpClient newclient = new();
                HttpResponseMessage newresponseMessage = await newclient.GetAsync("https://localhost:7111/Contact/GetAll");
                newresponseMessage.EnsureSuccessStatusCode();
                string newresponseBody = await newresponseMessage.Content.ReadAsStringAsync();
                JArray jsonArray = JArray.Parse(newresponseBody);
                string value1 = jsonArray[0]["location"].ToString();
                ViewBag.Location = value1;
            }
            return View();

        }
    }
}
