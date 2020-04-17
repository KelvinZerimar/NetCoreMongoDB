using Controle.Sales.Domain.DomainEntities;
using Controle.Sales.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Sales.Infra.Data.Repository
{
    public class SalesRepository : ISaleRepository
    {
        private readonly MongoContext _mongoContext;

        public SalesRepository()
        {
            _mongoContext = new MongoContext();
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll(int skip = 0, int limit = 50)
        {
            return _mongoContext.Sales.Find(x => true).Skip(skip).Limit(limit).ToList();
        }

        public Sale GetById(ObjectId id)
        {
            return _mongoContext.Sales.Find(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public bool HasExists(string serial)
        {
            throw new NotImplementedException();
        }

        public void Save(Sale obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Sale obj)
        {
            throw new NotImplementedException();
        }
    }
}
