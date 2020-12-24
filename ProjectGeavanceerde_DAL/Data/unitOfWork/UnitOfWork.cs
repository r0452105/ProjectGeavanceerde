using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectGeavanceerde_DAL.Data.Repositories;

namespace ProjectGeavanceerde_DAL.Data.unitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Character> _characterRepo;
        private IRepository<Affiliation> _affiliationRepo;
        private IRepository<Arc> _arcRepo;
        private IRepository<Place> _placeRepo;
        private IRepository<Event> _eventRepo;
        private IRepository<Species> _speciesRepo;
        private IRepository<Bloodtype> _bloodtypeRepo;
        private IRepository<Faction> _factionRepo;
        private IRepository<Haki> _hakiRepo;
        private IRepository<Gender> _genderRepo;


        public UnitOfWork(OnePieceEntities onePieceEntities)
        {
            this.OnePieceEntities = onePieceEntities;
        }
        private OnePieceEntities OnePieceEntities { get; }

        public IRepository<Character> CharacterRepo
        {
            get
            {
                if (_characterRepo == null)
                {
                    _characterRepo = new Repository<Character>(this.OnePieceEntities);
                }
                return _characterRepo;
            }
        }
        public IRepository<Affiliation> AffiliationRepo
        {
            get
            {
                if (_affiliationRepo == null)
                {
                    _affiliationRepo = new Repository<Affiliation>(this.OnePieceEntities);
                }
                return _affiliationRepo;
            }
        }

        public IRepository<Arc> ArcRepo
        {
            get
            {
                if (_arcRepo == null)
                {
                    _arcRepo = new Repository<Arc>(this.OnePieceEntities);
                }
                return _arcRepo;
            }
        }
        public IRepository<Place> PlaceRepo
        {
            get
            {
                if (_placeRepo == null)
                {
                    _placeRepo = new Repository<Place>(this.OnePieceEntities);
                }
                return _placeRepo;
            }
        }
        public IRepository<Event> EventRepo
        {
            get
            {
                if (_eventRepo == null)
                {
                    _eventRepo = new Repository<Event>(this.OnePieceEntities);
                }
                return _eventRepo;
            }
        }
        public IRepository<Species> SpeciesRepo
        {
            get
            {
                if (_speciesRepo == null)
                {
                    _speciesRepo = new Repository<Species>(this.OnePieceEntities);
                }
                return _speciesRepo;
            }
        }
        public IRepository<Bloodtype> BloodtypeRepo
        {
            get
            {
                if (_bloodtypeRepo == null)
                {
                    _bloodtypeRepo = new Repository<Bloodtype>(this.OnePieceEntities);
                }
                return _bloodtypeRepo;
            }
        }
        public IRepository<Faction> FactionRepo
        {
            get
            {
                if (_factionRepo == null)
                {
                    _factionRepo = new Repository<Faction>(this.OnePieceEntities);
                }
                return _factionRepo;
            }
        }
        public IRepository<Haki> HakiRepo
        {
            get
            {
                if (_hakiRepo == null)
                {
                    _hakiRepo = new Repository<Haki>(this.OnePieceEntities);
                }
                return _hakiRepo;
            }
        }
        public IRepository<Gender> GenderRepo
        {
            get
            {
                if (_genderRepo == null)
                {
                    _genderRepo = new Repository<Gender>(this.OnePieceEntities);
                }
                return _genderRepo;
            }
        }
        public void Dispose()
        {
            OnePieceEntities.Dispose();
        }

        public int Save()
        {
            return OnePieceEntities.SaveChanges();
        }
    }
}
