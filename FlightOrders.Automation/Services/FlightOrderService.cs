using FlightOrders.Automation.Models;

namespace FlightOrders.Automation.Services
{
    public class FlightOrderService
    {
        public readonly int planeCapacity = 20;

        public void ScheduleFlights(ref List<Flight> flights)
        {
            Console.WriteLine($"### Flight Schedule ###\r\n");
            for (int i = 0; i < flights.Count; i++)
            {
                var flight = flights[i];
                flight.FlightNumber = i + 1;
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.From}, arrival: {flight.To}, day: {flight.FlightDay}");
            }
        }

        public void AssignFlightOrders(ref List<Flight> flights, ref List<Order> orders) 
        {
            Console.WriteLine($"\r\n### Order Flight Assignments ###\r\n");
            foreach (var order in orders)
            {
                var flight = flights.FirstOrDefault(f => f.To == order.Destination && f.Orders.Count < planeCapacity);
                if (flight != null)
                {
                    flight.Orders.Add(order);
                    Console.WriteLine($"order: {order.Name}, flightNumber: {flight.FlightNumber}, departure: {flight.From}, arrival: {flight.To}, day: {flight.FlightDay}");
                }
                else
                    Console.WriteLine($"order: {order.Name}, flightNumber: not scheduled");
            }
        }
    }
}
