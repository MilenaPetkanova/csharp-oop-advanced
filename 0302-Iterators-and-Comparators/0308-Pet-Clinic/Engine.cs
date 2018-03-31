using System;
using System.Linq;

public class Engine
{
    private ClinicManager clinicManager;

    public Engine()
    {
        this.clinicManager = new ClinicManager();
    }

    public void Run()
    {
        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            var tokens = Console.ReadLine().Split();
            var commandName = tokens[0];
            var commandArgs = tokens.Skip(1).ToArray();

            switch (commandName)
            {
                case "Create":
                    if (commandArgs[0].Equals("Pet"))
                    { 
                        clinicManager.CreatePet(commandArgs);
                    }
                    else if (commandArgs[0].Equals("Clinic"))
                    {
                        try
                        {
                            clinicManager.CreateClinic(commandArgs);
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                    }
                    break;
                case "Add":
                    Console.WriteLine(clinicManager.Add(commandArgs));
                    break;
                case "Release":
                    Console.WriteLine(clinicManager.Release(commandArgs));
                    break;
                case "HasEmptyRooms":
                    Console.WriteLine(clinicManager.HasEmptyRooms(commandArgs));
                    break;
                case "Print":
                    if (commandArgs.Length == 1)
                    {
                        clinicManager.PrintAllRooms(commandArgs);
                    }
                    else if (commandArgs.Length == 2)
                    {
                        clinicManager.PrintRoom(commandArgs);
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
}

