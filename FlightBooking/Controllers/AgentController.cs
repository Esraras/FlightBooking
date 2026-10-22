using FlightBooking.AgentServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers;

public class AgentController: Controller
{
    private readonly ITravelAgentService _travelAgentService;

    public AgentController(ITravelAgentService travelAgentService)
    {
        _travelAgentService = travelAgentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRestaurantRecommendation(string cityName)
    {
        var result = await _travelAgentService.GetRestaurantRecommendationAsync(cityName);
        return Content(result);
    }
}
