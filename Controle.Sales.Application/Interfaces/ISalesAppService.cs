using Controle.Sales.Application.Commands;
using Controle.Sales.Application.Models;
using Controle.Sales.Domain.DomainEntities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Sales.Application.Interfaces
{
    public interface ISalesAppService
    {
        void Create(SalesCreateCommand obj);

        void Update(SalesUpdateCommand obj);

        void Delete(ObjectId id);

        IEnumerable<Sale> GetAll(int skip = 0, int limit = 50);

        Sale GetById(ObjectId id);
    }
}
