using Controle.Sales.Application.Commands;
using Controle.Sales.Domain.DomainEntities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controle.Sales.Application.Interfaces
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
