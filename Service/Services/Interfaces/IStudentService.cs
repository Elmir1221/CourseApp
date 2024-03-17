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

        void Delete(int? id);

        void Edit(Student entity);

        Student GetById(int? id);
        List<Student> GetAllStudents();

        List<Student> GetByAge(int age);
        List<Student> GetStudentByGroupId(int? id);
       
    }
}
