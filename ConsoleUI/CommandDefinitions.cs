using System;
using System.Collections.Generic;
using SchoolManagement.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.ConsoleUI
{
    internal class CommandDefinitions
    {
        public List<Command> Commands { get; }
        private CoreFunctionality Core { get; set; }

        public CommandDefinitions()
        {
            Core = new CoreFunctionality();

            Commands = new List<Command>();
            Commands.Add(ListDepartments());
            Commands.Add(ListLectures());
            Commands.Add(ListLecturesByDepartmentId());
            Commands.Add(ListStudents());
            Commands.Add(AddStudent());
            Commands.Add(AddStudentToLecture());
            Commands.Add(MoveStudent());
            Commands.Add(ListStudentLectures());
            Commands.Add(AddDepartment());
            Commands.Add(AddLecture());
            Commands.Add(Clear());
            Commands.Add(Help());
            Commands.Add(Exit());
        }

        private Command ExampleCommand()
        {
            return new Command(
                "command",
                "description",
                () =>
                {
                    //functionality goes here
                });
        }

        private Command Exit()
        {
            return new Command(
                "exit",
                "Exits the application",
                () =>
                {
                    Console.Write("Exiting....");
                });
        }

        private Command ListLectures()
        {
            return new Command(
                "lectures",
                "Lists all lectures in the database",
                () =>
                {
                    PrintAllLectures();
                });
        }

        private Command ListLecturesByDepartmentId()
        {
            return new Command(
                "lecturesByDept",
                "Lists all lectures in the database by department id.",
                () =>
                {
                    PrintAllDepartments();
                    Console.WriteLine("Enter department ID: ");
                    var deptId = Console.ReadLine();

                    Console.WriteLine("\nLectures assigned to selected department:");
                    foreach (var lecture in Core.GetLecturesByDepartmentId(new Guid(deptId)))
                    {
                        Console.WriteLine(lecture);
                    }
                });
        }

        private Command ListDepartments()
        {
            return new Command(
                "depts",
                "Lists all departments in the database",
                () =>
                {
                    PrintAllDepartments();
                });
        }

        private Command AddDepartment()
        {
            return new Command(
                "addDept",
                "Adds a department to the DB, prompts for needed information.",
                () =>
                {
                    Console.WriteLine("Name for department:");
                    var deptName = Console.ReadLine();
                    Core.AddDepartment(deptName);
                });
        }

        private Command AddLecture()
        {
            return new Command(
                "addLecture",
                "Adds a lecture to the databse, prompts for needed information.",
                () =>
                {
                    Console.WriteLine("Lecture name: ");
                    var lectureName = Console.ReadLine();

                    PrintAllDepartments();

                    Console.WriteLine("\nDepartment IDs to add lecture to (separated with semicolon(;)");
                    var deptIds = Console.ReadLine();

                    var depts = new List<Department>();

                    foreach (var deptId in deptIds.Split(";"))
                    {
                        depts.Add(Core.GetDepartmentById(new Guid(deptId)));
                    }
                    Core.AddLecture(lectureName, depts);
                });
        }

        private Command AddStudentToLecture()
        {
            return new Command(
                "addLectureToStudent",
                "Adds a lecture for a student.",
                () =>
                {
                    PrintAllStudents();
                    Console.WriteLine("Student ID to add a lecture to:");
                    var studentGuid = new Guid(Console.ReadLine());

                    Console.WriteLine();
                    var departmentId = Core.GetStudentDepartment(studentGuid).Id;
                    var departmentLectures = Core.GetLecturesByDepartmentId(departmentId);

                    Console.WriteLine("Available lectures: ");
                    foreach (var lecture in departmentLectures)
                    {
                        Console.WriteLine(lecture);
                    }

                    Console.WriteLine("\nLecture ID to add: ");
                    var chosenLectureGuid = new Guid(Console.ReadLine());
                    Core.AddStudentToLecture(studentGuid, chosenLectureGuid);
                });
        }

        private Command ListStudents()
        {
            return new Command(
                "students",
                "Lists all students",
                () =>
                {
                    PrintAllStudents();
                });
        }

        private Command AddStudent()
        {
            return new Command(
                "addStudent",
                "Adds a student to the databse, prompts for needed information.",
                () =>
                {
                    Console.WriteLine("First name: ");
                    var firstName = Console.ReadLine();

                    Console.WriteLine("Last name: ");
                    var lastName = Console.ReadLine();

                    Console.WriteLine("Available depts:");
                    var availableDepts = Core.GetDepartments();
                    foreach (var dept in availableDepts)
                    {
                        Console.WriteLine(dept);
                    }

                    Console.WriteLine("Department Id to assign to the new student: ");
                    var deptId = Console.ReadLine();

                    Core.AddStudent(firstName, lastName, Core.GetDepartmentById(new Guid(deptId)));
                });
        }

        private Command MoveStudent()
        {
            return new Command(
                "moveStudent",
                "Move student to a different department and reassign lectures.",
                () =>
                {
                    PrintAllStudents();

                    Console.WriteLine("Student id to move:");
                    var studentId = Console.ReadLine();

                    Console.WriteLine("\nAvailable departments:");
                    foreach(var dept in Core.GetDepartments())
                    {
                        Console.WriteLine(dept);
                    }
                    Console.WriteLine("Enter deparment id to move to: ");
                    var deptId = Console.ReadLine();

                    var studentEntity = Core.GetStudentById(new Guid(studentId));
                    var deptEntity = Core.GetDepartmentById(new Guid(deptId));
                    Core.MoveStudentToDepartment(studentEntity, deptEntity);
  
                });
        }

        private Command ListStudentLectures()
        {
            return new Command(
                "studentLectures",
                "Lists all student lectures for specified student id.",
                () =>
                {
                    PrintAllStudents();

                    Console.WriteLine("\nStudent ID to check: ");
                    var studentId = Console.ReadLine();

                    Console.WriteLine($"\nLectures for {studentId}:");
                    foreach (var lecture in Core.GetStudentLectures(new Guid(studentId)))
                    {
                        Console.WriteLine(lecture);
                    }
                    Console.WriteLine("");
                });
        }

        private Command Help()
        {
            return new Command(
                "help",
                "Displays all available commands",
                () =>
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Available commands:");
                    Console.ForegroundColor= ConsoleColor.Gray;
                    foreach (var command in Commands)
                    {
                        Console.WriteLine(command);
                    }
                    Console.WriteLine("");
                });
        }

        private Command Clear()
        {
            return new Command(
                "clear",
                "Clears console",
                () =>
                {
                    Console.Clear();
                });
        }

        private void PrintAllStudents()
        {
            Console.WriteLine("Available students: ");
            foreach (var student in Core.GetStudents())
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
        }

        private void PrintAllDepartments()
        {
            Console.WriteLine("Available departments: ");
            foreach (var dept in Core.GetDepartments())
            {
                Console.WriteLine(dept);
            }
            Console.WriteLine();
        }

        private void PrintAllLectures()
        {
            Console.WriteLine("Available lectures: ");
            foreach (var dept in Core.GetLectures())
            {
                Console.WriteLine(dept);
            }
            Console.WriteLine();
        }
    }
}
