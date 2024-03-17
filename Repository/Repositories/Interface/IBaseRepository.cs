using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interface
{
    public interface IBaseRepositories<T> where T : BaseEntity
    {
        void Create(T entity);

        void Delete(T entity);

        void Edit(T entity);
        T GetById(int id);
       

        
    }
}
