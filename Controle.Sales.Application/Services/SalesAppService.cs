using Controle.Sales.Application.Commands;
using Controle.Sales.Application.Interfaces;
using Controle.Sales.Application.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Controle.Sales.Domain.Interfaces;
using System.Linq;
using Controle.Sales.Domain.DomainEntities;
using Controle.Sales.Infra.Crosscuting.AssertionConcern;

namespace Controle.Sales.Application.Services
{
    public class SalesAppService: ISalesAppService
    {
        private readonly ISaleRepository _repository;

        public SalesAppService(ISaleRepository repository)
        {
            _repository = repository;
        }

        void ISalesAppService.Create(SalesCreateCommand obj)
        {
            throw new NotImplementedException();
        }

        void ISalesAppService.Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Sale> ISalesAppService.GetAll(int skip, int limit)
        {
            return _repository.GetAll(skip, limit);
        }

        Sale ISalesAppService.GetById(ObjectId id)
        {
            //Validation
            AssertionConcern.AssertArgumentNotNull(id, "La identificación no puede estar vacía");

            return _repository.GetById(id);
        }

        void ISalesAppService.Update(SalesUpdateCommand obj)
        {
            throw new NotImplementedException();
        }
    }
}
