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

        public Department GetStudentDepartment(Guid studentGuid)
        {
            return Db.Students.Where(x => x.Id == studentGuid).FirstOrDefault().AssignedDepartment;
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
            return Db.Students.Include(x => x.Lectures).Where(x => x.Id == idToGet).First();
        }

        public List<Lecture> GetLecturesByDepartmentId(Guid deptId)
        {
            var deptToFind = Db.Departments.Where(x => x.Id == deptId).First();
            return Db.Lectures.Where(x => x.Departments.Contains(deptToFind)).ToList();
        }

        public List<Lecture> GetStudentLectures(Guid studentGuid)
        {
            var student = Db.Students.Where(x => x.Id == studentGuid).SingleOrDefault();
            return Db.Lectures.Where(x => x.Students.Contains(student)).ToList();
        }

        public void MoveStudentToDepartment(Student studentToMove, Department moveToDepartment)
        {
            var lecturesToRemove = Db.Lectures.Where(x => x.Students.Contains(studentToMove));
            Db.Lectures.RemoveRange(lecturesToRemove);
            Db.Students.Where(x => x == studentToMove).First().AssignedDepartment = moveToDepartment;
            Db.SaveChanges();
        }

        public List<Lecture> GetLectures()
        {
            return Db.Lectures.ToList();
        }

        public void AddStudentToLecture(Guid studentId, Guid lectureId)
        {
            var student = Db.Students.Include(x => x.Lectures).FirstOrDefault(x => x.Id == studentId);
            var lecture = Db.Lectures.Include(x => x.Students).Where(x => x.Id == lectureId).FirstOrDefault();
            lecture.Students.Add(student);
            Db.SaveChanges();
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
