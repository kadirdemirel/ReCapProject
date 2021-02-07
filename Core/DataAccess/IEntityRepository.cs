using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic kısıtlama yaptık
    //referans tip almasını,IEntity veya IEntity'den türüyen nesneler alabildiğini
    //Vede new'lenebilir olan bir nesne alabildiğini yazdık
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);


    }
}
