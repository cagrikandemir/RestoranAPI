using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7111/Notification/GetAllNotification");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(createNotificationDto);
            var stringContent = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7111/Notification/Add", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildirim Başarıyla Oluşturuldu.";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Bildirim Oluşturulamadı. Lütfen Tekrar Deneyiniz.";
                return View();
            }
            return View();
        }
        public async Task<IActionResult> DeleteNotification(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7111/Notification/Delete/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildirim Başarıyla Silindi.";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Bildirim Silinemedi. Lütfen Tekrar Deneyiniz.";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7111/Notification/GetById/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7111/Notification/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildirim Başarıyla Güncellendi.";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Bildirim Güncellenemedi. Lütfen Tekrar Deneyiniz.";
                return View();
            }
            return View();
        }

        public async Task<IActionResult> NotificationStatusChangeToTrue(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7111/Notification/GetNotificationStatusChangeToTrue/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildirim Durumu Başarıyla Aktif Olarak Değiştirildi.";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Bildirim Durumu Değiştirilemedi. Lütfen Tekrar Deneyiniz.";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> NotificationStatusChangeToFalse(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7111/Notification/GetNotificationStatusChangeToFalse/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Bildirim Durumu Başarıyla Pasif Olarak Değiştirildi.";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Bildirim Durumu Değiştirilemedi. Lütfen Tekrar Deneyiniz.";
            }
            return RedirectToAction("Index");
        }
    }
}
