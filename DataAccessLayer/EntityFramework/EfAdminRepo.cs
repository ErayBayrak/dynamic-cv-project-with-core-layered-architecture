using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAdminRepo : GenericRepo<Admin>, IAdminDal
    {
        public Admin GetAdmin(Admin admin)
        {
            using(var context = new Context())
            {
                return context.Admins.FirstOrDefault(x=>x.UserName==admin.UserName && x.Password==admin.Password);
            }
        } 
    }
}
