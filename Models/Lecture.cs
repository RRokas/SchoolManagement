using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class Lecture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
