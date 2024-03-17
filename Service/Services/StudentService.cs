using DocumentFormat.OpenXml.Office2010.Excel;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interface;
using Service.Helpers.Counstants;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentReposity _studentRepo;
        private int count = 1;

        public StudentService()
        {
            _studentRepo = new StudentRepository();
        }

        public void Create(Student entity)
        {
            if (entity == null) throw new ArgumentNullException();
            entity.Id = count;
            _studentRepo.Create(entity);
            count++;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new NotImplementedException();
            Student student = _studentRepo.GetById((int)id);

            if (student is null) throw new NotFoundException(ResponceMessages.DataNotFound);
            _studentRepo.Delete(student);
        }

        public void Edit(Student entity)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepo.GetAllStudents();
        }


        public List<Student> GetByAge(int age)
        {
            return _studentRepo.GetByAge(age);
        }

        public Student GetById(int? id)
        {
            Student student = _studentRepo.GetById((int)id);
            if (student is null) throw new NotFoundException(ResponceMessages.DataNotFound);
            return student;
        }

        public List<Student> GetStudentByGroupId(int? id)
        {
            return _studentRepo.GetStudentByGroupId(id);
        }
    }
}
