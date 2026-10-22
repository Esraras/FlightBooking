namespace FlightBooking.AgentServices;

public interface ITravelAgentService
{
    Task<string> GetRestaurantRecommendationAsync(string cityName);
       // Task<AgentResponseDto> AskAgentAsync(string prompt);
}
