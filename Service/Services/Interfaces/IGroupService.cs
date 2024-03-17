using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interface
{
    public interface IGroupService
    {
        void Create(Group entity );

        void Delete(int? id);

        void Edit(Group data);
        Group GetById(int? id);
     
        
        List<Group> GetAllWithExpression(Func<Group, bool> predicate);
        List<Group> GetGroupsByTeacher(string teacher);
        List<Group> GetGroupsByRoom(string room);
        List<Group> GetAllGroups();
        List<Group> GeAllGroupsByName(string searchtext);

    }
}
