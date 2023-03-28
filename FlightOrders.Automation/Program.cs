using FlightOrders.Automation.Services;

class Program
{
    static public void Main()
    {
        FlightOrderService flightOrderService = new FlightOrderService();

        var jsonFlights = File.ReadAllText("coding-assigment-flights.json");
        var flights = JsonParserService.ParseFlights(jsonFlights);
        flightOrderService.ScheduleFlights(ref flights);


        var jsonOrders = File.ReadAllText("coding-assigment-orders.json");
        var orders = JsonParserService.ParseOrders(jsonOrders);
        flightOrderService.AssignFlightOrders(ref flights, ref orders);

        Console.WriteLine("Press any key to Close Program");
        Console.Read();
    }
}