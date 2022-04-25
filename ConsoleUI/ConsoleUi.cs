using System;
using SchoolManagement.ConsoleUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ConsoleUI
{
    internal class ConsoleUi
    {
        public void Start()
        {
            var commandDefinitions = new CommandDefinitions();
            var input = "";

            var helpCommand = commandDefinitions.Commands.Where(c => c.Name == "help").First();
            helpCommand.Execute();

            while (input != "exit")
            {
                Console.WriteLine("Waiting for command...");
                input = Console.ReadLine();

                var matchingCommand = commandDefinitions.Commands.Where(x => x.Name == input);
                if (matchingCommand.Any())
                {
                    matchingCommand.First().Execute();
                }
                else
                {
                    Console.WriteLine("Command not found, type \"help\" for a list of commands");
                }
            }

        }

       
    }
}
