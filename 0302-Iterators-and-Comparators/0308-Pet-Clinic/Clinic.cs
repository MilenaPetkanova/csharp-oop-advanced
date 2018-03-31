using System;
using System.Collections.Generic;

public class Clinic
{
    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.RoomsCount = rooms;
        this.Rooms = new Dictionary<int, Pet>();
        SetRooms();
    }

    public string Name { get; private set; }

    public int RoomsCount { get; private set; }

    public int CentralRoom => this.RoomsCount / 2 ;

    public Dictionary<int, Pet> Rooms { get; private set; }

    private void SetRooms()
    {
        for (int i = 0; i < this.RoomsCount; i++)
        {
            this.Rooms.Add(i, null);
        }
    }
    public bool AddPet(Pet pet)
    {
        if (this.Rooms[this.CentralRoom] == null)
        {
            this.Rooms[this.CentralRoom] = pet;
            return true;
        }

        for (int i = 1; i <= this.CentralRoom; i++)
        {
            if (this.Rooms[this.CentralRoom - i] == null)
            {
                this.Rooms[this.CentralRoom - i] = pet;
                return true;
            }
            else if (this.Rooms[this.CentralRoom + i] == null)
            {
                this.Rooms[this.CentralRoom + i] = pet;
                return true;
            }
        }

        return false;
    }

    public bool ReleasePet()
    {
        for (int i = this.CentralRoom; i < this.RoomsCount; i++)
        {
            if (this.Rooms[i] != null)
            {
                this.Rooms[i] = null;
                return true;
            }
        }

        for (int i = 0; i < this.CentralRoom; i++)
        {
            if (this.Rooms[i] != null)
            {
                this.Rooms[i] = null;
                return true;
            }
        }

        return false;
    }
}

