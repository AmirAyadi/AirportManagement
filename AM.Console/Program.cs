// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

//Console.WriteLine("Hello, World! from Amir Solution");

////var pl = new Plane();


//Plane plane = new Plane();
//PlaneType planeType = PlaneType.Airbus;

//Plane plane2 = new Plane(100,new DateTime(12/12/2023),1,PlaneType.Airbus);


//// Initialiseur d'objects qui remplace les constructeur paramétrés 
//Plane plane3 = new Plane { Capacity = 150, ManufactureDate = DateTime.Now };


//Console.WriteLine("Plane Capacity : "+plane3.Capacity);


//TEST Data 
Plane plane = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlanId = 1,
    planeType = PlaneType.Airbus
};

Passenger passenger = new Passenger
{
    BirthDate = DateTime.Now,
    EmailAddress = "amirayadi@hotmail.fr",
    FirstName = "Amir",
    LastName = "AYADI",
    PassportNumber = "456789215000",
    TelNumber = 560448345
};
Staff staff = new Staff
{
    EmailAddress = "amirayadi1@hotmail.fr",
    FirstName = "Amir1",
    LastName = "AYADI1",
    EmployementDate = DateTime.Now,
    Salary = 9000,
    Function = "Staff job"
};
Traveller traveller = new Traveller
{
    EmailAddress = "amirayadi2@hotmail.fr",
    FirstName = "Amir2",
    LastName = "AYADI2",
    HealthInformation = "good",
    Nationality = "Tunisian"
};

//TEST 
Console.WriteLine(passenger.CheckProfile("test","test"));
Console.WriteLine(passenger.CheckProfile("Amir","AYADI","amirayadi@hotmail.fr"));

passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();

