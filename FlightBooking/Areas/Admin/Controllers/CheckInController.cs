using FlightBooking.Dtos.CheckInDtos;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using FlightBooking.Services.FlightServices;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Areas.Admin.Controllers;

[Area("Admin")]
public class CheckInController : Controller
{

    private readonly IBookingService _bookingService;
    private readonly ICheckInService _checkInService;
    private readonly IFlightService _flightService;
    public CheckInController(IBookingService bookingService, ICheckInService checkInService, IFlightService flightService)
    {
        _bookingService = bookingService;
        _checkInService = checkInService;
        _flightService = flightService;
    }

    public async Task<IActionResult> Index(string id) // id = passengerId
    {
        ViewBag.PassengerId = id;
        // 1. Yolcuya ait Booking verisini çekiyoruz
        var booking = await _bookingService.GetBookingByPassengerIdAsync(id);

        if (booking != null)
        {
            // PNR bilgisini alıyoruz
            ViewBag.PnrNumber = booking.PnrNumber;
            ViewBag.FlightId = booking.FlightId;

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
    public async Task<IActionResult> Index(CompleteCheckInDto dto)
    {
        await _checkInService.CompleteCheckInAsync(dto);
        return RedirectToAction("");
    }
}
