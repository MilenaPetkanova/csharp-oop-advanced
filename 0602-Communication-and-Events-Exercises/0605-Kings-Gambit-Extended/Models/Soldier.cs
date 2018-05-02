using System;

public delegate void SoldierDiedHandler(Soldier soldier);

public abstract class Soldier
{
    public event SoldierDiedHandler SoldierDead;

    public Soldier(string name, int health)
    {
        this.Name = name;
        this.Health = 0;
    }

    public string Name { get; }

    public int Health { get; protected set; }

    public abstract void OnKingBeingAttacked();

    public void TakeAttack()
    {
        this.Health--;
        if (this.Health <= 0)
        {
            SoldierDead?.Invoke(this);
        }
    }
}

