using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department AssignedDepartment { get; set; }
        public List<Lecture> Lectures { get; set;}

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName} - {AssignedDepartment}";
        }
    }
}
