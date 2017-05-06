using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.EF;
using WorldAttractions.DAL.Models.Users;

namespace WorldAttractions.DAL.Repositories
{
    public class UserRepository:IRepository<User>
    {

        private BelarusAttractionsContext _applicationDbContext;

        public UserRepository(BelarusAttractionsContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> Users = _applicationDbContext.Users.ToList();
            return Users.ToList();
        }

        public User GetById(int? id)
        {
            return _applicationDbContext.Users.Find(id);
        }

        public void Create(User item)
        {
            _applicationDbContext.Users.Add(item);
        }

        public void Update(User item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Users.Find(id) != null)
            {
                _applicationDbContext.Users.Remove(_applicationDbContext.Users.Find(id));
            }
        }
    }
}
