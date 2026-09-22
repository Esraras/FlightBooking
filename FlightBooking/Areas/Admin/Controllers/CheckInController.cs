using FlightBooking.Services.BookingServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers;

[Area("Admin")]
public class CheckInController : Controller
{

    private readonly IFlightService _flightService;
    private readonly IBookingService _bookingService;
    public CheckInController(IFlightService flightService, IBookingService bookingService)
    {
        _flightService = flightService;
        _bookingService = bookingService;
    }

    public async Task<IActionResult> Index(string id) // id = passengerId
    {
        // 1. Yolcuya ait Booking verisini çekiyoruz
        var booking = await _bookingService.GetBookingByPassengerIdAsync(id);

        if (booking != null)
        {
            // PNR bilgisini alıyoruz
            ViewBag.Pnr = booking.PnrNumber;

            // Yolcu detaylarını alıyoruz
            var passenger = booking.Passengers.FirstOrDefault(p => p.PassengerId == id);
            if (passenger != null)
            {
                ViewBag.Name = passenger.Name;
                ViewBag.Surname = passenger.Surname;
                ViewBag.PassengerName = $"{passenger.Name} {passenger.Surname}";
                ViewBag.Gate = passenger.Gate;
            }

            // 2. Booking içindeki FlightId ile Uçuş bilgilerini çekiyoruz
            var flight = await _flightService.GetFlightByIdAsync(booking.FlightId);
            if (flight != null)
            {
                ViewBag.FlightNumber = flight.FlightNumber;
                ViewBag.AirlineCode = flight.AirlineCode;
                ViewBag.DepartureAirportCode = flight.DepartureAirportCode;
                ViewBag.DepartureAirportName = flight.DepartureAirportName;
                ViewBag.ArrivalAirportCode = flight.ArrivalAirportCode;
                ViewBag.ArrivalAirportName = flight.ArrivalAirportName;
                ViewBag.DepartureTime = flight.DepartureTime;
                ViewBag.ArrivalTime = flight.ArrivalTime;
                ViewBag.BasePrice = flight.BasePrice;
                ViewBag.Currency = flight.Currency;
            }
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        return RedirectToAction("Index", "Home");
    }
}
