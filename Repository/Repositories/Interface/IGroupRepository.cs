using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{
    public interface IGroupRepository : IBaseRepositories<Group>
    {

        List<Group> GetGroupsByTeacher(string teacher);
        List<Group> GetGroupsByRoom(string room);
        List<Group> GetAllGroups();

        List<Group> GeAllGroupsByName(string Searchtext);
        List<Group> GetAllWithExpression(Func<Group, bool> predicate);
    }
}
