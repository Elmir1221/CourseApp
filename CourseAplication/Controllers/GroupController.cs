
using Domain.Models;
using Repository.Repositories.Data;
using Service.Helpers.Counstants;
using Service.Helpers.Extention;
using Service.Services;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAplication.Controllers
{
    public class GroupController
    {
        private readonly IGroupService _groupService;
       
        public GroupController()
        {
            _groupService = new GroupService();
        }

        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Add Group Name");
            Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            ConsoleColor.Cyan.WriteConsole("Add Group Room");
            Room: string room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input con't be empty");
                goto Room;
            }
            ConsoleColor.Cyan.WriteConsole("Add Teacher");
            Teacher: string teacher = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacher))
            {
                ConsoleColor.Red.WriteConsole("Input con't be empty");
                goto Teacher;
            }

            else
            {
                try
                {
                    _groupService.Create(new Group { Name = name, Teacher = teacher, Room = room });
                    ConsoleColor.Green.WriteConsole("DATA SUCCESFULLY ADD");

                }
                catch(Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Name;
                }
            }    
        }
        //public void Delete()
        //{
        //    bool isValidId = false;

        //    while (!isValidId)
        //    {
        //        Console.WriteLine("INPUT Group Id");
        //        string idstr = Console.ReadLine();

        //        if (int.TryParse(idstr, out int id))
        //        {
        //            try
        //            {
        //                _groupService.Delete(id);
        //                Console.WriteLine("DATA SUCCESSFULLY REMOVED");
        //                isValidId = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Error: {ex.Message}");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Delete format is wrong, please try again.");
        //        }
        //    }
        //}

        public void Delete(int? id)
        {
            ConsoleColor.Cyan.WriteConsole("INPUT Group Id");
        Id: string idstr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idstr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    _groupService.Delete(id);
                    ConsoleColor.Green.WriteConsole("DATA SUCCESFULLY REMOVED");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Delete format is wrong, please add operation again");
                goto Id;
            }

        }
        public void GetAllGroups()
        {
            var responce = _groupService.GetAllGroups();
            foreach (var item in responce)
            {
                string data = $"id: {item.Id}  Teacher: {item.Teacher} Room: {item.Room} Name: {item.Name}";
                Console.WriteLine(data);
            }
        }
        public void Edit()
        {
            Id: ConsoleColor.Cyan.WriteConsole("Enter Group Id:");
            int id;
            bool isCorrectformat = int.TryParse(Console.ReadLine(), out id);
            if (isCorrectformat)
            {
                ConsoleColor.Red.WriteConsole(string.Format(ResponceMessages.DataNotFound, "id"));
                goto Id;
            }
            try
            {
                Group foundGroup = _groupService.Edit(id);
            }
            catch
            {

            }
        }
        public Group GetById(int? id)
        {
           Id: string idst = Console.ReadLine();
            int groupId;
            bool isCorrectIdFormat = int.TryParse(idst, out groupId);

          var response =  _groupService.GetById(groupId);
            return response;

        }
        public List<Group> GetGroupsByRoom()
        {
            Room: string room = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(room))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Room;
            }
            else
            {
                var response = _groupService.GetGroupsByRoom(room);
                return response;
            }

        }

        public  List<Group> GetGroupsByTeacher()
        {
        Teacher: string teacher = Console.ReadLine();
           // return GetAllWithExpression.where(m => m.teacher == teacher);

                if (string.IsNullOrWhiteSpace(teacher))
                {
                    ConsoleColor.Red.WriteConsole("Input can't be empty");
                    goto Teacher;
                }
                else
                {
                    var response = _groupService.GetGroupsByTeacher(teacher);
                    return response;
                }
            
        }

        public List<Group> GeAllGroupsByName()
        {
            Name: string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty");
                goto Name;
            }
            else
            {
                var response = _groupService.GeAllGroupsByName(name);
                    return response;
            }

        }

       
    }
}
