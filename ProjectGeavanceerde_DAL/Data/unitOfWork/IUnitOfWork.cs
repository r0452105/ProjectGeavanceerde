using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectGeavanceerde_DAL.Data.Repositories;

namespace ProjectGeavanceerde_DAL.Data.unitOfWork
{

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Character> CharacterRepo { get; }
        IRepository<Affiliation> AffiliationRepo { get; }
        IRepository<Arc> ArcRepo { get; }
        IRepository<Place> PlaceRepo { get; }
        IRepository<Event> EventRepo { get; }
        IRepository<Species> SpeciesRepo { get; }
        IRepository<Bloodtype> BloodtypeRepo { get; }
        IRepository<Faction> FactionRepo { get; }
        IRepository<Gender> GenderRepo { get; }
        IRepository<Haki> HakiRepo { get; }
        int Save();
    }
}
