// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World! from Amir Solution");

//var pl = new Plane();


Plane plane = new Plane();
PlaneType planeType = PlaneType.Airbus;

Plane plane2 = new Plane(100,new DateTime(12/12/2023),1,null);


// Initialiseur d'objects qui remplace les constructeur paramétrés 
Plane plane3 = new Plane { Capacity = 150, ManufactureDate = DateTime.Now };


Console.WriteLine("Plane Capacity : "+plane3.Capacity);