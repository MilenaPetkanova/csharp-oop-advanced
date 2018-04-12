using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var soldiers = new List<Soldier>();
        var king = new King(Console.ReadLine());
        var royalGuardNames = Console.ReadLine().Split().ToList();
        
        foreach (var name in royalGuardNames)
        {
            var royalGuard = new RoyalGuard(name);
            soldiers.Add(royalGuard);
            king.BeingAttacked += royalGuard.OnKingBeingAttacked;
        }

        var footmenNames = Console.ReadLine().Split().ToList();

        foreach (var name in footmenNames)
        {
            var footman = new Footman(name);
            soldiers.Add(footman);
            king.BeingAttacked += footman.OnKingBeingAttacked;
        }

        var command = Console.ReadLine().Split();

        while (!command[0].Equals("End"))
        {
            switch (command[0])
            {
                case "Kill":
                    Soldier deadSoldier = soldiers.FirstOrDefault(s => s.Name == command[1]);
                    king.BeingAttacked -= deadSoldier.OnKingBeingAttacked;
                    soldiers.Remove(deadSoldier);
                    break;
                case "Attack":
                    king.TakeAttack();
                    break;
            }

            command = Console.ReadLine().Split();
        }
    }
}
