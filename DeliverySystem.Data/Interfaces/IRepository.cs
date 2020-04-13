using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Guid Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
