namespace FlightBooking.Dtos.FlightSearchDtos
{
    public class FlightCardDto
    {
        public string Airline { get; set; } = "";
        public string AirlineLogo { get; set; } = "";
        public string DepartureTime { get; set; } = "";
        public string ArrivalTime { get; set; } = "";
        public string DepartureAirport { get; set; } = "";
        public string ArrivalAirport { get; set; } = "";
        public string DurationText { get; set; } = "";
        public int Stops { get; set; }
        public List<string> LayoverCities { get; set; } = new();
        public string Price { get; set; } = "";

        // ---- Detay (modal) — BURAYA ait ----
        public List<FlightSegmentDto> Segments { get; set; } = new();
        public List<LayoverDto> Layovers { get; set; } = new();
        public BagsDto? Bags { get; set; }
        public CarbonDto? Carbon { get; set; }
    }

    public class FlightSegmentDto
    {
        public string Airline { get; set; } = "";
        public string AirlineLogo { get; set; } = "";
        public string FlightNumber { get; set; } = "";
        public string Aircraft { get; set; } = "";
        public string Legroom { get; set; } = "";
        public string DurationText { get; set; } = "";
        public string DepartureTime { get; set; } = "";
        public string DepartureCode { get; set; } = "";
        public string DepartureName { get; set; } = "";
        public string ArrivalTime { get; set; } = "";
        public string ArrivalCode { get; set; } = "";
        public string ArrivalName { get; set; } = "";
    }

    public class LayoverDto
    {
        public string AirportCode { get; set; } = "";
        public string AirportName { get; set; } = "";
        public string City { get; set; } = "";
        public string DurationLabel { get; set; } = "";
    }

    public class BagsDto
    {
        public int? CarryOn { get; set; }
        public int? Checked { get; set; }
    }

    public class CarbonDto
    {
        public int Co2eKg { get; set; }
        public int DifferencePercent { get; set; }
    }

    // Sonuç zarfı — detay alanları YOK
    public class FlightSearchResultDto
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string FromIata { get; set; } = "";
        public string FromAirport { get; set; } = "";
        public string ToIata { get; set; } = "";
        public string ToAirport { get; set; } = "";
        public string Currency { get; set; } = "TRY";
        public List<FlightCardDto> Flights { get; set; } = new();
    }
}