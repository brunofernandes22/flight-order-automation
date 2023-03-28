namespace FlightOrders.Automation.Models
{
    public class Flight
    {
        public string To { get; set; }
        public string From { get; set; }
        public int FlightDay { get; set; }
        public int FlightNumber { get; set; }
        public List<Order> Orders { get; set; }

        Flight() {
            Orders = new List<Order>();
        }
    }
}
