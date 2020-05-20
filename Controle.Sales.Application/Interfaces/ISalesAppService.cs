using System.Collections.Generic;
using System.Threading.Tasks;
using Application.App.Commands;
using Domain.DomainEntities;
using MongoDB.Bson;

namespace Application.App.Interfaces
{
    public interface ISalesAppService
    {
        Task<IEnumerable<Sale>> GetAll(int skip, int limit);
        Task Create(SalesCommand obj);

        void Update(SalesCommand obj);

        void Delete(ObjectId id);

        //Sale GetById(ObjectId id);
        Task<Sale> GetById(string id);
    }
}
