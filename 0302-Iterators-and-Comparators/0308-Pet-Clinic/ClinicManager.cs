using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicManager
{
    private List<Pet> pets;
    private List<Clinic> clinics;

    public ClinicManager()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    public void CreatePet(string[] args)
    {
        var pet = new Pet(args[1], int.Parse(args[2]), args[3]);
        this.pets.Add(pet);
    }

    public void CreateClinic(string[] commandArgs)
    {
        var name = commandArgs[1];
        var rooms = int.Parse(commandArgs[2]);
        if (rooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        var clinic = new Clinic(name, rooms);
        this.clinics.Add(clinic);
    }

    public bool Add(string[] commandArgs)
    {
        var pet = this.pets.FirstOrDefault(p => p.Name == commandArgs[0]);
        var clinic = this.clinics.FirstOrDefault(c => c.Name == commandArgs[1]);

        return clinic.AddPet(pet);
    }

    public bool Release(string[] commandArgs)
    {
        var clinic = this.clinics.FirstOrDefault(c => c.Name == commandArgs[0]);

        return clinic.ReleasePet();
    }

    public bool HasEmptyRooms(string[] commandArgs)
    {
        var clinic = this.clinics.FirstOrDefault(c => c.Name == commandArgs[0]);

        foreach (var room in clinic.Rooms)
        {
            if (room.Value == null)
            {
                return true;
            }
        }

        return false;
    }

    public void PrintRoom(string[] commandArgs)
    {
        var clinic = this.clinics.First(c => c.Name == commandArgs[0]);
        var roomNumer = int.Parse(commandArgs[1]) - 1;

        if (clinic.Rooms[roomNumer] == null)
        {
            Console.WriteLine("Room empty");
        }
        else
        {
            Console.WriteLine(clinic.Rooms[roomNumer].ToString());
        }
    }

    public void PrintAllRooms(string[] commandArgs)
    {
        var clinic = this.clinics.First(c => c.Name == commandArgs[0]);

        foreach (var room in clinic.Rooms)
        {
            if (room.Value == null)
            {
                Console.WriteLine("Room empty");
            }
            else
            {
                Console.WriteLine(room.Value);
            }
        }
    }
}
