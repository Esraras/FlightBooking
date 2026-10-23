using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices.OpenAIServices;

public interface IOpenAIServices
{
    Task<AgentResponseDto> GetResponseAsync(string prompt);
}
