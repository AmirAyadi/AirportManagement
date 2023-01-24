using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
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

        public IGrouping<string, IEnumerable<Flight>> DestinationGroupedFlightss()
        {
            //To Delete ( out of range ) 
            //Lambda Expression
            var destinationGrouped = from fligh in Flights
                                     group fligh by fligh.Destination;

            return (IGrouping<string, IEnumerable<Flight>>)destinationGrouped;
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query =  from f in Flights
                         group f by f.Destination;

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);

                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.FlightDate);

                }
            }
            return query;
        }

        public double DurationAverage(string destination)
        {
            var Total = 0;
            return Flights.Where(flight => flight.Destination == destination).Select(flight=>flight.EstimatedDuration).Average();
            
            
            
            //foreach (var f in lambda)
            //{
            //    Total += (double) f;
            //}
        }

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

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //Lambda :
            return Flights.OrderByDescending(f => f.EstimatedDuration);
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

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //Lambda Expression
            //OrderBy Ascending by default .
            return flight.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3);

            //LINQ
            return (from f in flight.Passengers.OfType<Traveller>()
                    orderby f.BirthDate ascending
                    select f
                    ).Take(3);
                   


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


           // IEnumerable<Flight> flights = new IEnumerable<Flight>();

        }

        IEnumerable<IGrouping<string, Flight>> IServiceFlight.DestinationGroupedFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlightsWithLambda()
        {
            var lambda = Flights.GroupBy(f => f.Destination);

            foreach (var item in lambda)
            {
                Console.WriteLine(item.Key);

                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.FlightDate);

                }
            }
            return lambda;
        }
    }
}
