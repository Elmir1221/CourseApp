using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{

    public interface IStudentReposity : IBaseRepositories<Student>
    {

        List<Student> GetByAge(int age);
        List<Student> GetStudentByGroupId(int? id);
        List<Student> GetAllStudents(string data);
        Student GetById(int id);
    }

}
