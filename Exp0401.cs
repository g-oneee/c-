using System;


public class Flight
{
    public int Id;
    public int Cost;
    public int Capacity;
    public int TotalBooked;
    public string Src;
    public string Dest;
    public DateTime Arrival;
    public DateTime Departure;
    public string JourneyTime;
    public static Dictionary<int, Flight> ListOfFlights = new Dictionary<int, Flight>();
    //y     m   d   h   m   s
    // DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);
    public static void AddFlight(int id, int cost, int Capacity, string src, string dest, DateTime arrival, DateTime Departure, string JourneyTime, int TotalBooked = 0)
    {

        Flight flight = new Flight();
        flight.Id = id;
        flight.Cost = cost;
        flight.Src = src;
        flight.Capacity = Capacity;
        flight.Dest = dest;
        flight.Arrival = arrival;
        flight.Departure = Departure;
        flight.JourneyTime = JourneyTime;
        flight.TotalBooked = TotalBooked;
        ListOfFlights.Add(id, flight);

    }
    public static void RemoveFlight(int id)
    {
        ListOfFlights.Remove(id);
    }
    public static void BookTicketsByFlightId(int id, int NoOfTickets)
    {
        ListOfFlights[id].TotalBooked += NoOfTickets;
    }
    public static void UpdateFlightCapacity(int id, int Capacity)
    {
        ListOfFlights[id].Capacity = Capacity;
    }
    public static void UpdateFlightArrival(int id, DateTime arrival)
    {
        ListOfFlights[id].Arrival = arrival;
    }
    public static void UpdateFlightDept(int id, DateTime Dept)
    {
        ListOfFlights[id].Departure = Dept;
    }
    public static List<Flight> GetAllFlightsWithGivenSource(string src)
    {
        List<Flight> AllFlightsFromSRC = new List<Flight>();
        foreach (var flight in ListOfFlights)
        {
            if (flight.Value.Src == src)
            {
                AllFlightsFromSRC.Add(flight.Value);
            }
        }
        return AllFlightsFromSRC;
    }
    public static List<Flight> GetAllFlightsWithGivenDest(string dest)
    {
        List<Flight> AllFlightsFromDEST = new List<Flight>();
        foreach (var flight in ListOfFlights)
        {
            if (flight.Value.Dest == dest)
            {
                AllFlightsFromDEST.Add(flight.Value);
            }
        }
        return AllFlightsFromDEST;
    }
    public static List<Flight> GetAllFlightsWithInDateRange(DateTime from, DateTime to)
    {
        List<Flight> AllFlightsInRange = new List<Flight>();
        foreach (var flight in ListOfFlights)
        {
            if (flight.Value.Arrival > from && flight.Value.Departure < to)
            {
                AllFlightsInRange.Add(flight.Value);
            }
        }
        return AllFlightsInRange;
    }
    public static int GetRemainingCapacity(int id)
    {
        return ListOfFlights[id].Capacity - ListOfFlights[id].TotalBooked;
    }

}
class Program
{
    public static void Main(string[] args)
    {
        Flight.AddFlight(1, 400, 100, "BOM", "POQ", new DateTime(24, 12, 4, 22, 44, 09), new DateTime(24, 12, 5, 22, 44, 09), "1h30m");
        Flight.AddFlight(2, 400, 100, "QWE", "DEL", new DateTime(24, 12, 5, 22, 44, 09), new DateTime(24, 12, 6, 22, 44, 09), "1h30m");
        Flight.AddFlight(3, 400, 100, "ABC", "DEL", new DateTime(24, 12, 6, 22, 44, 09), new DateTime(24, 12, 7, 22, 44, 09), "1h30m");
        Flight.AddFlight(4, 400, 100, "DEF", "DEL", DateTime.Now, DateTime.Now, "1h30m", 30);
        Flight.AddFlight(5, 400, 100, "XYZ", "DEL", DateTime.Now, DateTime.Now, "1h30m");

        foreach (var keyValPair in Flight.ListOfFlights)
            Console.WriteLine($"the id of the flight is{keyValPair.Value.Id} and the dest is{keyValPair.Value.Dest} and total booked tickets is{keyValPair.Value.TotalBooked}");

        // Flight.RemoveFlight(2);
        // Flight.BookTicketsByFlightId(2, 4);
        // Flight.UpdateFlightArrival(1, new DateTime(24, 12, 4, 22, 44, 09));
        foreach (var keyValPair in Flight.ListOfFlights)
            Console.WriteLine($"the id of the flight is{keyValPair.Value.Id} and the dest is{keyValPair.Value.Dest} and total booked tickets is{keyValPair.Value.Arrival}");
            
        // System.Console.WriteLine();
        // System.Console.WriteLine();
        // System.Console.WriteLine("ranged flights");
        // System.Console.WriteLine();
        // System.Console.WriteLine();
        // List<Flight> RangedFlights = Flight.GetAllFlightsWithInDateRange(new DateTime(24, 12, 3), new DateTime(24, 12, 8));
        // foreach (var flights in RangedFlights)
        //     Console.WriteLine($"the id of the flight is{flights.Id} and the dest is{flights.Src} and total booked tickets is{flights.Arrival}");



        System.Console.WriteLine(Flight.GetRemainingCapacity(4));
        Console.ReadLine();
    }
}