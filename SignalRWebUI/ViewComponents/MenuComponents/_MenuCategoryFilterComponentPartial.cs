using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.ViewComponents.MenuComponents
{
    public class _MenuCategoryFilterComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7111/Category/GetAll");
            if(response.IsSuccessStatusCode)
            {
                var jsData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsData);
                return View(values);
            }
            return View();

        }
    }
}
