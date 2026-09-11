using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.DefaultViewComponent;

public class _DefaultSliderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
