using FlightBooking.Dtos.PassengerDtos;

namespace FlightBooking.Dtos.BookingDtos;

public class CreateBookingDto
{
    public string FlightId { get; set; }
    public string PnrNumber { get; set; }
    public List<CreatePassengerDto> Passengers { get; set; }

    // 🔥 İletişim burada olmalı
    public string ContactName { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime BookingDate { get; set; }
    public string Status { get; set; }
}
