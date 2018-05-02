using System;

public class Footman : Soldier
{
    private const int DefaulthHealth = 2;

    public Footman(string name)
        : base(name, DefaulthHealth)
    {
    }

    public override void OnKingBeingAttacked()
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}

