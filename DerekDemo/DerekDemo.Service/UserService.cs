using DerekDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DerekDemo.Service
{
    public interface IUserService : IGenericService<User>
    {
        //User Get(long id, params Expression<Func<User, object>>[] navigationProperties);
        //void AddOrUpdate(User User);
    }

    public class UserService : GenericService<User>, IUserService
    {
        public UserService(DbContext context) : base(context)
        {

        }
    }
}
