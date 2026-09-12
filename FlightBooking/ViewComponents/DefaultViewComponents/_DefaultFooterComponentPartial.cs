using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace FlightBooking.ViewComponents.DefaultViewComponents;

public class _DefaultFooterComponentPartial :ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
