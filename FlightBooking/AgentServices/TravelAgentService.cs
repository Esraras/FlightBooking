namespace FlightBooking.AgentServices;

public class TravelAgentService : ITravelAgentService
{
    public async Task<string> GetRestaurantRecommendationAsync(string cityName)
    {
        return $"Here are some restaurant recommendations for {cityName}: 1. The Gourmet Spot, 2. City Bites, 3. Flavor Haven.";
    }
}
