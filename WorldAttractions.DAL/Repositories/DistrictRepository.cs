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
    public class DistrictRepository 
    {
        
        private BelarusAttractionsContext _applicationDbContext;

        public DistrictRepository(BelarusAttractionsContext context)
        {
            this._applicationDbContext = context;
        }

        public IEnumerable<District> GetAll()
        {
            List<District> Districts = _applicationDbContext.Districts.ToList();
            return Districts.ToList();
        }

        public District GetById(int? id)
        {
            return _applicationDbContext.Districts.Find(id);
        }

        public void Create(District item)
        {
            _applicationDbContext.Districts.Add(item);
        }

        public void Update(District item)
        {
            _applicationDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            if (_applicationDbContext.Districts.Find(id) != null)
            {
                _applicationDbContext.Districts.Remove(_applicationDbContext.Districts.Find(id));
            }
        }
    }
}
