using System;
using System.Collections.Generic;
using Controle.Sales.Domain.DomainEntities ;
using MongoDB.Bson;

namespace Controle.Sales.Domain.Interfaces
{
    public interface ISaleRepository
    {
        void Save(Sale obj);

        void Update(Sale obj);

        void Delete(ObjectId id);

        IEnumerable<Sale> GetAll(int skip = 0, int limit = 50);

        Sale GetById(ObjectId id);

        bool HasExists(string serial);
    }
}
