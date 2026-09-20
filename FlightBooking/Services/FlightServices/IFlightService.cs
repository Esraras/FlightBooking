using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Dtos.PassengerDtos;

namespace FlightBooking.Services.FlightServices;

public interface IFlightService
{
    Task<List<ResultFlightDtos>> GetAllFlightsAsync();
    Task<GetFlightByIdDtos> GetFlightByIdAsync(string id);
    Task CreateFlightAsync(CreateFlightDtos createFlightDto);
    Task DeleteFlightAsync(string id);
    Task UpdateFlightAsync(UpdateFlightDtos updateFlightDto);
    Task<List<PassengerListItemDto>> GetFlightDetailsWithPassengers(string id);
}
