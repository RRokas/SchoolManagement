using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; }
        public List<Student> Students { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
