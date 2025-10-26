using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
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
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7111/Category/GetAll");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            var StringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7111/Product/Add", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = " Yeni Ürün Başarıyla Eklendi";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false){
                TempData["ErrorMessage"] = "Ürün Eklenirken Hata Oluştu. Lütfen Tekrar Deneyiniz.";
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7111/Product/Delete/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Ürün Başarıyla Silindi";
                return RedirectToAction("Index");
            }
            if (responseMessage.IsSuccessStatusCode == false) {
                TempData["ErrorMessage"] = "Ürün Silinirken Hata Oluştu. Lütfen Tekrar Deneyiniz.";
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int Id)
        {
            var client = _httpClientFactory.CreateClient();

            // 🔽 1. Kategori verisini API'den çekiyoruz
            var categoryResponse = await client.GetAsync("https://localhost:7111/Category/GetAll");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

                // 🔽 2. ViewBag'e SelectList oluşturuyoruz
                List<SelectListItem> values2 = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();
                ViewBag.v = values2;
            }

            // 🔽 3. Ürün verisini çekiyoruz
            var responseMessage = await client.GetAsync($"https://localhost:7111/Product/GetById/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(value);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateproductdto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateproductdto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7111/Product/Update", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Ürün Başarıyla Güncellendi";
                return RedirectToAction("Index");
            }
            if(responseMessage.IsSuccessStatusCode == false)
            {
                TempData["ErrorMessage"] = "Ürün Güncellenirken Hata Oluştu. Lütfen Tekrar Deneyiniz.";
            }
            return View();
        }

    }
}
