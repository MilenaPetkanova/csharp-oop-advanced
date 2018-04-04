﻿namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    IExecutable command = this.commandInterpreter.InterpretCommand(data, commandName);
                    
                    MethodInfo method = typeof(IExecutable).GetMethods().First();
                    
                    try
                    {
                        var result = method.Invoke(command, null).ToString();
                        Console.WriteLine(result);

                    }
                    catch (TargetInvocationException e)
                    {
                        throw e.InnerException;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}