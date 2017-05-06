using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.EF;
using WorldAttractions.DAL.Models.Showplace;

namespace WorldAttractions.DAL.Repositories
{
    public class MonumentRepository : IRepository<Monument>
    {

        private BelarusAttractionsContext _applicationDbContext;

        public MonumentRepository(BelarusAttractionsContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<Monument> GetAll()
        {
            List<Monument> Monuments = _applicationDbContext.Monuments.ToList();
            return Monuments.ToList();
        }

        public Monument GetById(int? id)
        {
            return _applicationDbContext.Monuments.Find(id);
        }

        public void Create(Monument item)
        {
            _applicationDbContext.Monuments.Add(item);
        }

        public void Update(Monument item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Monuments.Find(id) != null)
            {
                _applicationDbContext.Monuments.Remove(_applicationDbContext.Monuments.Find(id));
            }
        }
    }
}
