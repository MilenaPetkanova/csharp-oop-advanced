using System;

public abstract class Soldier
{
    public Soldier(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public abstract void OnKingBeingAttacked(object source, EventArgs args);
}

