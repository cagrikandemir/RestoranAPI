using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientBuilder _httopClientBuilder;

        public ProductController(IHttpClientBuilder httopClientBuilder)
        {
            _httopClientBuilder = httopClientBuilder;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
