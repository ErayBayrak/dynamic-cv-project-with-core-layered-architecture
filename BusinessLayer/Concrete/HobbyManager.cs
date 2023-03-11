using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HobbyManager : IHobbyService
    {
        IHobbyDal _hobbyDal;

        public HobbyManager(IHobbyDal hobbyDal)
        {
            _hobbyDal = hobbyDal;
        }

        public Hobby GetById(int id)
        {
            return _hobbyDal.GetById(id);
        }

        public List<Hobby> GetList()
        {
            return _hobbyDal.GetList();
        }

        public void TDelete(Hobby t)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Hobby t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Hobby t)
        {
            _hobbyDal.Update(t);
        }
    }
}
