using AM.ApplicationCore.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public IEnumerable<DateTime> GetFlightDates(string destination);
        public IEnumerable<Flight> GetFlights(string filterType, string filterValue);

        //QST 10
        public void ShowFlightDetails(Plane plane);
        //QST 11
        public int ProgrammedFlightNumber(DateTime startDate);

        public double DurationAverage(string destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);

        public IGrouping<string, IEnumerable<Flight>> DestinationGroupedFlightss();
        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights();
        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlightsWithLambda();

    }
}
