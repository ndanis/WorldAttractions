using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractions.DAL.EF;
using WorldAttractions.DAL.Repositories;

namespace WorldAttractions.DAL.Models.Information
{
    public class UnitOfWork : IDisposable //Это класс в котором мы будем получать наши репозитории, а в репозиториях непосредственно будут происходить все операции с БД
    {
        private BelarusAttractionsContext db = new BelarusAttractionsContext();
        private UserRepository userRepository;
        private DistrictRepository DistrictRepository;
        private MonumentRepository monumentRepository;
        private CityRepository CityRepository;
        private PictureRepository pictureRepository;
        private RoleRepository roleRepository;


        public RoleRepository Roles {
            get 
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
            
        }
        public PictureRepository Pictures
        {
            get
            {
                if (pictureRepository == null)
                    pictureRepository = new PictureRepository(db);
                return pictureRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public DistrictRepository Districts
        {
            get
            {
                if (DistrictRepository == null)
                DistrictRepository = new DistrictRepository(db);
                return DistrictRepository;
            }
        }
        public CityRepository Cities
        {
            get
            {
                if (CityRepository == null)
                    CityRepository = new CityRepository(db);
         return CityRepository;
            }
        }
        public MonumentRepository Monuments
        {
            get
            {
                if (monumentRepository == null)
                    monumentRepository = new MonumentRepository(db);
                return monumentRepository;
            }
        }



        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
