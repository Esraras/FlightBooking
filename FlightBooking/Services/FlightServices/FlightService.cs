using AutoMapper;
using FlightBooking.Dtos.FlightDtos;
using FlightBooking.Dtos.PassengerDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FlightServices;

public class FlightService : IFlightService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Flight> _flightCollection;
    private readonly IMongoCollection<Booking> _bookingCollection;
    public FlightService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _flightCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName);
        _bookingCollection = database.GetCollection<Booking>(_databaseSettings.BookingCollectionName);
        _mapper = mapper;
    }
    public async Task CreateFlightAsync(CreateFlightDtos createFlightDto)
    {
        var values = _mapper.Map<Flight>(createFlightDto);
        await _flightCollection.InsertOneAsync(values);
    }

    public async Task DeleteFlightAsync(string id)
    {
        await _flightCollection.DeleteOneAsync(x => x.FlightId == id);
    }

    public async Task<List<ResultFlightDtos>> GetAllFlightsAsync()
    {
        var values = await _flightCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFlightDtos>>(values);
    }

    public async Task<GetFlightByIdDtos> GetFlightByIdAsync(string id)
    {
        var value = await _flightCollection.Find(x => x.FlightId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetFlightByIdDtos>(value);
    }

    public async Task<List<PassengerListItemDto>> GetFlightDetailsWithPassengers(string id)
    {
         // 1. O uçuşa ait tüm booking'leri çek
            var bookings = await _bookingCollection.Find(x => x.FlightId == id).ToListAsync();

            // 2. Her booking içindeki yolcuları düzleştir ve DTO'ya map et
            var passengers = bookings
                .SelectMany(b => b.Passengers.Select(p => new PassengerListItemDto
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = b.ContactEmail,  
                    Gender = p.Gender,
                    PassengerType = p.PassengerType,
                    PnrNumber = b.PnrNumber,     
                    Phone = b.ContactPhone,
                    // Aşağıdaki alanlar Passenger entity'nde varsa doğrudan al
                    SeatNumber = p.SeatNumber,
                    CheckInStatus = p.CheckInStatus,
                    //PaymentStatus = b.PaymentStatus,
                    TicketStatus = p.TicketStatus,
                    PassengerId = p.PassengerId
                })) 
                .ToList();

            return passengers;
    }

    public async Task UpdateFlightAsync(UpdateFlightDtos updateFlightDto)
    {
        var values = _mapper.Map<Flight>(updateFlightDto);
        await _flightCollection.FindOneAndReplaceAsync(x => x.FlightId == updateFlightDto.FlightId, values);
    }
}
