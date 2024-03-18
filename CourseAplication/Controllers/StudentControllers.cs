using Domain.Models;
using Service.Helpers.Extention;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace CourseAplication.Controllers
{
    public class StudentControllers
    {
        public readonly IStudentService _studentService;

        public StudentControllers()
        {
            _studentService = new StudentService();
        }

        public void create()
        {
            ConsoleColor.Cyan.WriteConsole("Add Student Name");
            Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;

            }

            ConsoleColor.Cyan.WriteConsole("Add student Surname");
            Surname: string surname = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(surname))
            {
                ConsoleColor.Red.WriteConsole("input Can't be empty");
                goto Surname;
            }

            ConsoleColor.Cyan.WriteConsole("Add Student Age");
            Age: string agestr = Console.ReadLine();
            int age;
            bool isCorrectAgeFormat = int.TryParse(agestr,out age);
            if(age<15 || age > 50)
            {
                ConsoleColor.Red.WriteConsole("WRONG AGE");
                goto Age;
            }
            ConsoleColor.Cyan.WriteConsole("Add Id");



            ConsoleColor.Cyan.WriteConsole("Add Group");
            Group: string group = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(group))
            {
                ConsoleColor.Red.WriteConsole("input Can't be empty");
            }
            else
            {

                try
                {
                    _studentService.Create(new Student { Name = name, Surname = surname , Age = age });
                }
                catch(Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }
            }

        }
    }
}
