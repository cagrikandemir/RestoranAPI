using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.NotificationComponents;

public class _NotificationComponentPartial:ViewComponent
{

    public IViewComponentResult Invoke()
    {
        return View();
    }
}
