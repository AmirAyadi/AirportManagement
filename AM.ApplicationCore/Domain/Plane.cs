namespace AM.ApplicationCore.Domain
{
    public class Plane
    {
        //public Plane()
        //{
        //}
        //public Plane(PlaneType planeType, int capacity, DateTime manufactureDate, int planId)
        //{
        //    Capacity = capacity;
        //    ManufactureDate = manufactureDate;
        //    PlanId = planId;
        //    this.planeType = planeType;
        //}
        #region CLass
        // Props ( not attributes ) 
        //prop + 2TAB
        // we will work with light version . 

        //string Nom;

        //public string getNom() { return Nom; }
        //public void setNom(string Nom) { this.Nom = Nom; }

        //prop + 2TAB : version light 
        // public string Nom { get; set; };

        //prop Full + 2 TAB : full version qui permet de personaliser les getter + setter . 

        //private int test
        //{
        //    get { return test; }
        //    set { test = value; }
        //}
        #endregion

        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        public int PlanId { get; set; }
        public PlaneType planeType { get; set; }

        // IList<Flight> Flights { get; set; }
        ICollection<Flight> Flights { get; set; }





    }
}