using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        //GLOBAL Variable 
        public IList<Flight> Flights { get; set; } = new List<Flight>();


        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            //Empty List of Dates to fill with the ones having the right destination 
             IList<DateTime> FlightsDatee = new List<DateTime>();

            //for (int i = 0; i < Flights.Count; i++)
            // {
            //     if (Flights[i].Destination.Equals(destination))
            //     {
            //         FlightsDatee.Add(Flights[i].FlightDate);
            //     }
            // }
            // return FlightsDatee;

            //foreach (Flight flight in Flights)
            //{
            //    if (flight.Destination.Equals(destination))
            //    {
            //        FlightsDatee.Add(flight.FlightDate);
            //    }
            //return FlightsDatee;



            //}

            //Hint query.ToList();

            var Query = from flight in Flights
                        where flight.Destination == destination
                        select flight.FlightDate;
            return Query;




        }

        public IEnumerable<Flight> GetFlights(string filterType, string filterValue)
        {
            throw new NotImplementedException();
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        { // 7 days between startDate and real date .( ) 

            var query = from flight in Flights
                        where (((flight.FlightDate -startDate).TotalDays < 7 ) && (flight.FlightDate - startDate).TotalDays >0) // need to be positive
                        select flight;

            return query.Count();
        }

        public void ShowFlightDetails(Plane plane)
        {

            var query = from f in Flights
                        where f.plane == plane
                        select (f.FlightDate, f.Destination);

            foreach (var pl in query)
            { // Affichage
                Console.WriteLine(pl.FlightDate+""+pl.Destination);
            }
        }
    }
}
