using System;
using System.Collections.Generic;

public delegate void KingBeingAttackHandler();

public class King
{
    public event KingBeingAttackHandler BeingAttacked;

    private readonly List<Soldier> soldiers;

    public King(string name)
    {
        this.Name = name;
        this.soldiers = new List<Soldier>();
    }

    public string Name { get; }

    public IReadOnlyCollection<Soldier> Soldiers => this.soldiers;

    public void AddSoldier(Soldier soldier)
    {
        this.soldiers.Add(soldier);
        this.BeingAttacked += soldier.OnKingBeingAttacked;
        soldier.SoldierDead += this.OnSoldierDead;
    }

    public void TakeAttack()
    {
        this.OnBeingAttacked();
    }

    protected void OnBeingAttacked()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        this.BeingAttacked?.Invoke();
    }

    protected void OnSoldierDead(Soldier soldier)
    {
        this.BeingAttacked -= soldier.OnKingBeingAttacked;
        this.soldiers.Remove(soldier);
    }
}

