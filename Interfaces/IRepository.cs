using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotFlix.Interfaces
{
    // T is bettwen < > because will pass a Generic Type
    public interface IRepository<T>
    {
        // To make diference between List<T> and Method Relation()
        List<T> Relation();

        T ReturnById(int id);

        void Insert(T entity);

        void Delete(int id);

        void Update(int id, T entity);

        int NextId();
    }
}
