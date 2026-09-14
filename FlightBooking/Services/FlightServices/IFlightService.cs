using FlightBooking.Dtos.FlightDtos;

namespace FlightBooking.Services.FlightServices;

public interface IFlightService
{
    Task<List<ResultFlightDtos>> GetAllFlightsAsync();
        Task<GetFlightByIdDtos> GetFlightByIdAsync(string id);
        Task CreateFlightAsync(CreateFlightDtos createFlightDto);
        Task DeleteFlightAsync(string id);
        Task UpdateFlightAsync(UpdateFlightDtos updateFlightDto);
}
