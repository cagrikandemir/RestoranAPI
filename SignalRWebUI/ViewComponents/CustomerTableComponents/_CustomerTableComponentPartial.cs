using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.CustomerTableComponents
{
    public class _CustomerTableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
