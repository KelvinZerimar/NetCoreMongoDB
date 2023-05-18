using Domain.DomainEntities;
using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await this._mongoContext.Sales.Find(x => x.OrderID.Equals(id))
                .FirstOrDefaultAsync();
            //return _mongoContext.Sales.Find(x => x.ObjectId.Equals(id)).FirstAsync();
        }

        public async Task<IEnumerable<Sale>> GetCountry(string texto)
        {
            var result = await _mongoContext.Sales
                .Find(x => x.Country.ToUpper().Contains(texto.ToUpper()))
                .ToListAsync();
            var aresult = result.GroupBy(x => x.Country)
                .Select(group => new Sale { Country = group.Key });

            // LINQ Group By and select collection:
            // https://stackoverflow.com/questions/10637760/linq-group-by-and-select-collection

            var oresult = result.GroupBy(x => x.Country)
                .Select(x => new List<Sale>(x));

            var oresult2 = result.GroupBy(x => x.Country)
                .ToDictionary(t => t.Key, t => t.ToList())
            .AsEnumerable();

            var results = result.GroupBy(p => p.Country,
                         (key, g) => new { Contry = key, Count = g.ToList() });



            return aresult;

            //return await this._mongoContext.Sales.Find(Builders<Sale>.Filter.Eq("country", texto))
            //    .ToListAsync();
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
