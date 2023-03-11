using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepo<T> : IGenericDal<T> where T : class
    {
        Context context = new Context();
        public void Delete(T t)
        {
            context.Remove(t);
            
            context.SaveChanges();
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);

        }

        public void Insert(T t)
        {
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Update(t);
            context.SaveChanges();
        }
    }
}
