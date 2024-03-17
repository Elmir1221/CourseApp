using Domain.Models;
using Repository.Repositories.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> GeAllGroupsByName(string searchtext)
        {
            return AppDbContext<Group>.datas.Where(m => m.Name == searchtext).ToList();
        }

        public List<Group> GetAllGroups()
        {
            return AppDbContext<Group>.datas.ToList();
        }

        public List<Group> GetGroupsByTeacher(string teacher)
        {
            return AppDbContext<Group>.datas.Where(m => m.Teacher == teacher).ToList();
        }

        public List<Group> GetGroupsByRoom(string room)
        {
            return AppDbContext<Group>.datas.Where(m => m.Room == room).ToList();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
