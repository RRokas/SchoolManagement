using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ConsoleUI
{
    internal class Command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action Execute { get; set; }

        public Command(string commandName, string commandDescription, Action commandFunction)
        {
            Name = commandName;
            Description = commandDescription;
            Execute = commandFunction;
        }

        public override string ToString()
        {
            return $"{Name} : {Description}";
        }
    }
}
