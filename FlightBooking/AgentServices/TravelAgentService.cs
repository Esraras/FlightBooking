using FlightBooking.AgentServices.OpenAIServices;
using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices;

public class TravelAgentService : ITravelAgentService
{
    private readonly IOpenAIServices _openAIServices;

    public TravelAgentService(IOpenAIServices openAIServices)
    {
        _openAIServices = openAIServices;
    }

    public async Task<AgentResponseDto> AskAgentAsync(string prompt)
    {
        return await _openAIServices.GetResponseAsync(prompt);
    }
}
