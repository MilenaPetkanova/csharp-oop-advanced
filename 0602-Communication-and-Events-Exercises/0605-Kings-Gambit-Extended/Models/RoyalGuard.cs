using System;

public class RoyalGuard : Soldier
{
    private const int DefaulthHealth = 3;

    public RoyalGuard(string name)
        : base(name, DefaulthHealth)
    {
    }

    public override void OnKingBeingAttacked()
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
