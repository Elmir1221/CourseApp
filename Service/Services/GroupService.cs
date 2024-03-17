using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interface;
using Service.Helpers.Counstants;
using Service.Helpers.Exceptions;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private int count = 1;
        

        public GroupService()
        {
            _groupRepo = new GroupRepository();
        }
        public void Create(Group entity)
        {
            if (entity == null) throw new ArgumentNullException();
            entity.Id = count;
            _groupRepo.Create(entity);
            count++;
        }

        public void Delete(int? id)
        {
            if (id is null) throw new NotImplementedException();
            Group group = _groupRepo.GetById((int)id);

            if (group is null) throw new NotFoundException(ResponceMessages.DataNotFound);
            _groupRepo.Delete(group);
            
        }


        public void Edit(Group entity)
        {
            throw new NotImplementedException();
        }

        public List<Group> GeAllGroupsByName(string searchtext)
        {
            var response = _groupRepo.GetGroupsByRoom(searchtext);

            return response;
        }

        public List<Group> GetAllGroups()
        {
            return _groupRepo.GetAllGroups();
        }

        public List<Group> GetAllWithExpression(Func<Group, bool> predicate)
        {
            return _groupRepo.GetAllWithExpression(predicate);
        }


        public Group GetById(int? id)
        {
            
            Group group = _groupRepo.GetById((int)id);
          
            if (group is null) throw new NotFoundException(ResponceMessages.DataNotFound);
            return group;

        }

        public List<Group> GetGroupsByRoom(string room)
        {
            var response = _groupRepo.GetGroupsByRoom(room);

            return response;
        }

        public List<Group> GetGroupsByTeacher(string teacher)
        {
            var responce = _groupRepo.GetGroupsByTeacher(teacher);
            return responce;
        }
    }
}
