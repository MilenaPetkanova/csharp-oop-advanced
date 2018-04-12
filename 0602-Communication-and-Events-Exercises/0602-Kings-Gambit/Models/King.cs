using System;

public class King
{
    public King(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public event EventHandler BeingAttacked;

    public void TakeAttack()
    {
        this.OnBeingAttacked();
    }

    protected virtual void OnBeingAttacked()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        if (this.BeingAttacked != null)
        {
            this.BeingAttacked(this, EventArgs.Empty);
        }
    }
}

