using Domain.DomainEntities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISaleRepository
    {
        Task Save(Sale obj);

        void Update(Sale obj);

        void Delete(ObjectId id);

        Task<IEnumerable<Sale>> GetAll(int skip, int limit);

        Task<long> GetCountAll();

        //Sale GetById(ObjectId id);
        Task<Sale> GetById(string id);
        Task<IEnumerable<Sale>> GetCountry(string texto);

        bool HasExists(string serial);
    }
}
