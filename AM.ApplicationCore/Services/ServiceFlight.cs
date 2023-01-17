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

            //LINQ

            var query = from flight in Flights
                        where (((flight.FlightDate - startDate).TotalDays < 7) && (flight.FlightDate - startDate).TotalDays > 0) // need to be positive
                        select flight;
            return query.Count();




        }

        public int ProgrammedFlightNumberWithLambda(DateTime startDate)
        {
            //Lambda expression
            // var lambda2 = Flights.Where(flight =>((flight.FlightDate-startDate).TotalDays<7) && (flight.FlightDate - startDate).TotalDays >0).Select(flight=>flight.FlightDate);
            
            var lambda2 = Flights.Where(flight => ((flight.FlightDate - startDate).TotalDays < 7) && (flight.FlightDate - startDate).TotalDays > 0);
            return lambda2.Count();

            //OR 
            //return Flights.Where(flight => ((flight.FlightDate - startDate).TotalDays < 7) && (flight.FlightDate - startDate).TotalDays > 0).Count();

        }

        public void ShowFlightDetails(Plane plane)
        {

            var query = from f in Flights
                        where f.plane == plane
                        select (f.FlightDate, f.Destination);
            //Lambda expression
            //var lambda = flights.where(f=>f.Destination.equals(destination)).select(f=>f.flightDate) : Class Example 

            //Lambda Expression 
            var lambda2 = Flights.Where(flight => flight.plane == plane).Select(flight => (flight.FlightDate, flight.Destination));

            foreach (var pl in query)
            { // Affichage avec LinQ
                Console.WriteLine(pl.FlightDate+" "+pl.Destination);
            }
            foreach (var pl in lambda2)
            { // Affichage avec Lambda Expression
                Console.WriteLine(pl.FlightDate + " " + pl.Destination);
            }


            IEnumerable<Flight> flights = new IEnumerable<Flight>();

        }
    }
}
