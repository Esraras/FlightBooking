namespace FlightBooking.AgentServices.OpenAIServices;

public interface IOpenAIServices
{
    Task<string> GetResponseAsync(string prompt);
}
