using Domain.DomainEntities;
using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repository
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetCountAll()
        {
            return await _mongoContext.Sales.CountDocumentsAsync(FilterDefinition<Sale>.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Sale>> GetAll(int skip, int limit)
        {
            return await _mongoContext.Sales.Find(x => true).Skip(skip).Limit(limit).ToListAsync();

            /*
            IEnumerable<Sale> sales = null;
            using (IAsyncCursor<Sale> cursor = await this._mongoContext.Sales.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    sales = cursor.Current;
                }
            }
            return sales;*/
        }

        public async Task<Sale> GetById(string id)
        {
            //return await this._mongoContext.Sales.Find(Builders<Sale>.Filter.Eq("_id", ObjectId.Parse(id)))
            //    .FirstOrDefaultAsync();

            var resp = await _mongoContext.Sales.Find(x => x.OrderID.Equals(id)).FirstAsync();
            return resp;

            //FilterDefinition<Sale> filter = Builders<Sale>.Filter.Eq("OrderID", ObjectId.Parse(id));
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

        public Task<IEnumerable<Sale>> GetCountry(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
