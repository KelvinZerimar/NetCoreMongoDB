using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Controle.Sales.Domain.DomainEntities ;
using MongoDB.Bson;

namespace Controle.Sales.Domain.Interfaces
{
    public interface ISaleRepository
    {
        Task Save(Sale obj);

        void Update(Sale obj);

        void Delete(ObjectId id);

        Task<IEnumerable<Sale>> GetAll(int skip, int limit);

        //Sale GetById(ObjectId id);
        Task<Sale> GetById(string id);

        bool HasExists(string serial);
    }
}
