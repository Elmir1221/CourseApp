using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student entity);

        void Delete(Student entity);

        void Edit(Student entity);

        List<Student> GetAllById();

        List<Student> GetByAge(int age);
        List<Student> GetStudentByGroupId(int? id);
        List<Student> GetAllStudents(string data);
    }
}
