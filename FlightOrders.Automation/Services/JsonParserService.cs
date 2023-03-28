using FlightOrders.Automation.Models;
using Newtonsoft.Json;

namespace FlightOrders.Automation.Services
{
    public static class JsonParserService
    {
        public static List<Order> ParseOrders(string json)
        {
            var orders = new List<Order>();
            var parsedObject = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);

            if (parsedObject == null)
            {
                throw new Exception("Could not parse JSON file to object");
            }

            foreach (var entry in parsedObject)
            {
                entry.Value.Name = entry.Key;
                orders.Add(entry.Value);
            }
            return orders;
        }

        public static List<Flight> ParseFlights(string json)
        {
            var flights = new List<Flight>();
            var parsedFlights = JsonConvert.DeserializeObject<Dictionary<int, List<Flight>>>(json);

            if (parsedFlights == null)
            {
                throw new Exception("Could not parse JSON file to object");
            }

            foreach (var entry in parsedFlights)
            {
                foreach(var flight in entry.Value)
                {
                    flight.FlightDay = entry.Key;
                    flights.Add(flight);
                }
            }

            return flights;
        }
    }
}