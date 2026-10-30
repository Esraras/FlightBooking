using FlightBooking.Dtos.FlightSearchDtos;

namespace FlightBooking.Services.AirportServices.FlighSearchServices;

public class FlightSearchService : IFlightSearchService
{
    public Task<List<FlightCardDto>> SearchAsync(string fromIata, string toIata, string outboundDate, int adults, string cabin, string currency)
    {
        throw new NotImplementedException();
    }
}
