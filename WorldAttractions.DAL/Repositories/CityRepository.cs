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
    public class CityRepository 
    {
        
        private BelarusAttractionsContext _applicationDbContext;

        public CityRepository(BelarusAttractionsContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<City> GetAll()
        {
            List<City> Cities = _applicationDbContext.Cities.ToList();
            return Cities.ToList();
        }

        public City GetById(int? id)
        {
            return _applicationDbContext.Cities.Find(id);
        }

        public void Create(City item)
        {
            _applicationDbContext.Cities.Add(item);
        }

        public void Update(City item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Cities.Find(id) != null)
            {
                _applicationDbContext.Cities.Remove(_applicationDbContext.Cities.Find(id));
            }
        }
    }
}
