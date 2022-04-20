using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Models;

namespace SchoolManagement
{
    internal class CoreFunctionality
    {
        private SchoolDb Db { get; set; }

        public CoreFunctionality()
        {
            Db = new SchoolDb();
        }

        public List<Student> GetStudents()
        {
            return Db.Students.Include(x => x.AssignedDepartment).ToList();
        }

        public List<Student> GetStudentsByDepartmentId(Guid deptId)
        {
            return Db.Students.Where(x => x.AssignedDepartment.Id == deptId).ToList();
        }

        public void AddStudent(string firstName, string lastName, Department dept)
        {
            Db.Students.Add(
                new Student() 
                { 
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    AssignedDepartment = dept
                });
            Db.SaveChanges();
        }

        public Student GetStudentById(Guid idToGet)
        {
            return Db.Students.Where(x => x.Id == idToGet).First();
        }

        public List<Lecture> GetLecturesByDepartmentId(Guid deptId)
        {
            var deptToFind = Db.Departments.Where(x => x.Id == deptId).First();
            return Db.Lectures.Where(x => x.Departments.Contains(deptToFind)).ToList();
        }

        public List<Lecture> GetStudentLectures(Guid studentGuid)
        {
            var studentDept = Db.Students.Where(x => studentGuid.Equals(studentGuid)).First().AssignedDepartment;
            //var lectureIds = Db.Departments.Where(x => x. == studentDept.Id);
            return Db.Lectures.Where(x => x.Departments.Contains(studentDept)).ToList();
        }

        public void MoveStudentToDepartment(Student studentToMove, Department moveToDepartment)
        {
            Db.Students.Where(x => x == studentToMove).First().AssignedDepartment = moveToDepartment;
            Db.SaveChanges();
        }

        public List<Lecture> GetLectures()
        {
            return Db.Lectures.ToList();
        }

        public void AddLecture(string lectureName, List<Department> lectureDepartments)
        {
            Db.Lectures.Add(
                new Lecture
                {
                    Id= Guid.NewGuid(),
                    Name = lectureName,
                    Departments = lectureDepartments
                });
            Db.SaveChanges();
        }

        public void RemoveLectureById(Guid idToRemove)
        {
            var lectureToRemove = Db.Lectures.Where(x => x.Id == idToRemove);
            Db.Lectures.RemoveRange(lectureToRemove);
            Db.SaveChanges();
        }

        public List<Department> GetDepartments()
        {
            return Db.Departments.ToList();
        }

        public void AddDepartment(string departmentName)
        {
            Db.Add(new Department() { Id = Guid.NewGuid(), Name = departmentName});
            Db.SaveChanges();
        }

        public Department GetDepartmentById(Guid idtoGet)
        {
            return Db.Departments.Where(x => x.Id == idtoGet).First();
        }
    }
}
