using System;
using System.ComponentModel.DataAnnotations;

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
    Dictionary<int, Vehicle?> space;
    private int _length;

    public ParkingLot(int length)
    {
      _length = length;
      this.space = [];

      for (int i = 0; i < length; i++)
      {
        space.Add(i + 1, null);
      }
    }

    public void park(Vehicle vehicle)
    {
      for (int i = 1; i <= _length; i++)
      {
        if (space[i] == null)
        {
          space[i] = vehicle;
          Console.WriteLine("Allocated slot number: " + i);
          return;
        }
      }

      Console.WriteLine("Sorry, parking lot is full");
    }

    public void leave(int slot)
    {
      if (space.First(v => v.Key == slot).Value != null)
      {
        space[slot] = null;
        Console.WriteLine("Slot number " + slot + " is free");
        return;
      }

      Console.WriteLine("Sorry, vehicle is not parked here");
    }

    public void status()
    {
      Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\t\tColour");
      int no = 1;
      foreach (var slot in space.OrderBy(s => s.Key))
      {
        if (slot.Value == null) continue;
        Console.WriteLine($"{slot.Key}\t{no++}\t\t{slot.Value.Type}\t{slot.Value.RegistrationNo}\t\t{slot.Value.Colour}");
      }
    }

    public void countByType(string type)
    {
      var count = space.Count(v => v.Value.Type.Equals(type));
      Console.WriteLine(count);
    }

    public void getRegistrationsByPlate(string command)
    {
      var num = command.Equals("even") ? 0 : 1;
      var vehicles = space.Where(v => int.Parse(v.Value.RegistrationNo.Split("-")[1]) % 2 == num);
      if (vehicles.Count() < 1)
      {
        Console.WriteLine("Empty");
        return;
      }
      foreach (var v in vehicles)
      {
        Console.Write(v.Value.RegistrationNo + ", ");
      }
      Console.WriteLine();
    }

    public void getRegistrationsByColour(string colour)
    {
      for (var i = 1; i <= _length; i++)
      {
        if (space[i] != null && space[i].Colour.Equals(colour))
        {
          Console.Write(space[i].RegistrationNo + ", ");
        }
      }
      Console.WriteLine();
    }

    public void getSlotNumbersByColour(string colour)
    {
      var vehicles = space.Where(v => v.Value.Colour.Equals(colour));

      if (vehicles.Count() < 1)
      {
        Console.WriteLine("Not found");
        return;
      }
      foreach (var v in vehicles)
      {
        Console.Write(v.Key + ", ");
      }
      Console.WriteLine();
    }

    public void getSlotNumbersByRegistration(string reg)
    {
      for (int i = 1; i <= _length; i++)
      {
        if (space[i] == null)
        {
          Console.WriteLine("Not found");
          return;
        }
        else
        {
          Console.WriteLine(i);
        }
      }
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
            var vehicle = new Vehicle(command[3], command[1], command[2]);
            parkingLot?.park(vehicle);
            break;
          case "leave":
            var registration = int.Parse(command[1]);
            parkingLot?.leave(registration);
            break;
          case "status":
            parkingLot?.status();
            break;
          case "type_of_vehicles":
            parkingLot?.countByType(command[1]);
            break;
          case "registration_numbers_for_vehicles_with_ood_plate":
            parkingLot?.getRegistrationsByPlate("odd");
            break;
          case "registration_numbers_for_vehicles_with_event_plate":
            parkingLot?.getRegistrationsByPlate("even");
            break;
          case "registration_numbers_for_vehicles_with_colour":
            parkingLot?.getRegistrationsByColour(command[1]);
            break;
          case "slot_numbers_for_vehicles_with_colour":
            parkingLot?.getSlotNumbersByColour(command[1]);
            break;
          case "slot_number_for_registration_number":
            parkingLot?.getSlotNumbersByRegistration(command[1]);
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