using System;

namespace ParkingLot
{
  class Vehicle
  {
    private string _type;
    private string _registrationNo;
    private string _colour;

    public Vehicle(string type, string registretionNo, string colour)
    {
      _type = type;
      _registrationNo = registretionNo;
      _colour = colour;
    }

    public string Type
    {
      get { return _type; }
      set { _type = value; }
    }

    public string RegistrationNo
    {
      get { return _registrationNo; }
      set { _registrationNo = value; }
    }

    public string Colour
    {
      get { return _colour; }
      set { _colour = value; }
    }
  }

  class ParkingLot
  {
    List<Vehicle> space;
    private int _length;

    public ParkingLot(int length)
    {
      this.space = [];
    }

    public void park()
    {

    }

    public void leave()
    {

    }

    public void status()
    {

    }

    public void countByType(string type)
    {

    }

    public void getRegistrationsByPlate(string command)
    {

    }

    public void getRegistrationsByColour(string colour)
    {

    }

    public void getSlotNumbersByColour(string colour)
    {

    }

    public void getSlotNumbersByRegistration(string reg)
    {

    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      bool app = true;
      ParkingLot? parkingLot = null;

      Console.WriteLine("Parking Lot App");

      while (app)
      {
        string[] command = Console.ReadLine().Split(" ");

        switch (command[0])
        {
          case "create_parking_lot":
            parkingLot = new ParkingLot(int.Parse(command[1]));
            Console.WriteLine($"Created a parking lot with {command[1]} slots");
            break;
          case "park":
            parkingLot?.park();
            break;
          case "leave":
            parkingLot?.leave();
            break;
          case "status":
            parkingLot?.status();
            break;
          case "type_of_vehicles":
            parkingLot?.countByType("Mobil");
            break;
          case "registration_numbers_for_vehicles_with_ood_plate":
            parkingLot?.getRegistrationsByPlate("odd");
            break;
          case "registration_numbers_for_vehicles_with_event_plate":
            parkingLot?.getRegistrationsByPlate("even");
            break;
          case "registration_numbers_for_vehicles_with_colour":
            parkingLot?.getRegistrationsByColour("color");
            break;
          case "slot_numbers_for_vehicles_with_colour":
            parkingLot?.getSlotNumbersByColour("color");
            break;
          case "slot_number_for_registration_number":
            parkingLot?.getSlotNumbersByRegistration("plate");
            break;
          case "exit":
            app = false;
            break;
          default:
            Console.WriteLine("command invalid");
            break;
        }
      }
    }
  }
}