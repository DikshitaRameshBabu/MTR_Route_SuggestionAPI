namespace MTR_RouteSuggestionAPI.Models
{
    public class RouteSuggestion
    {
        public Guid Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int TotalNoOfStations { get; set; }
        public int NoOfStationsInbetween { get; set; }
        public double Fare { get; set; }
        public double Distance { get; set; }

    }
}
