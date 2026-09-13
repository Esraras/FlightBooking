using AutoMapper;

namespace FlightBooking.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Entities.Flight, Dtos.FlightDtos.CreateFlightDtos>().ReverseMap();
        CreateMap<Entities.Flight, Dtos.FlightDtos.ResultFlightDtos>().ReverseMap();
        CreateMap<Entities.Flight, Dtos.FlightDtos.GetFlightDtos>().ReverseMap();
        CreateMap<Entities.Flight, Dtos.FlightDtos.UpdateFlightDtos>().ReverseMap();
    }
}
