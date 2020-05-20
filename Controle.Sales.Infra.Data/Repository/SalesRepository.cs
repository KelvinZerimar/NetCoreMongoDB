using Controle.Sales.Domain.DomainEntities;
using Controle.Sales.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle.Sales.Infra.Data.Repository
{
    public class SalesRepository : ISaleRepository
    {
        private readonly MongoContext _mongoContext;

        public SalesRepository()
        {
            _mongoContext = new MongoContext("SalesCompany");
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sale>> GetAll(int skip, int limit)
        {
            return await _mongoContext.Sales.Find(x => true).Skip(skip).Limit(limit).ToListAsync();

            //IEnumerable<Sale> sales = null;
            //using (IAsyncCursor<Sale> cursor = await this._mongoContext.Sales.FindAsync(new BsonDocument()))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        sales = cursor.Current;
            //    }
            //}
            //return sales;
        }

        public async Task<Sale> GetById(string id)
        {
            return await this._mongoContext.Sales.Find(Builders<Sale>.Filter.Eq("_id", ObjectId.Parse(id)))
                .FirstOrDefaultAsync();

            //return _mongoContext.Sales.Find(x => x.ObjectId.Equals(id)).FirstAsync();

            //FilterDefinition<Sale> filter = Builders<Sale>.Filter.Eq("_id", ObjectId.Parse(id));
            //IEnumerable<Sale> entity = null;
            //using (IAsyncCursor<Sale> cursor = await this._mongoContext.Sales.FindAsync(filter))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        entity = cursor.Current;
            //    }
            //}
            //return entity.FirstOrDefault();
        }

        public bool HasExists(string serial)
        {
            throw new NotImplementedException();
        }

        public async Task Save(Sale entity)
        {
            await _mongoContext.Sales.InsertOneAsync(entity);
        }

        public void Update(Sale entity)
        {
           // _mongoContext.Sales.ReplaceOne(x => x.Id.Equals(entity.Id), entity);
        }
    }
}
