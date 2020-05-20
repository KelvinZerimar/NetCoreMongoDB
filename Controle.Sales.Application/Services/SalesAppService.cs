using Controle.Sales.Application.Commands;
using Controle.Sales.Application.Interfaces;
using Controle.Sales.Domain.Interfaces;
using Controle.Sales.Domain.DomainEntities;
using Controle.Sales.Infra.Crosscuting.AssertionConcern;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;


namespace Controle.Sales.Application.Services
{
    public class SalesAppService: ISalesAppService
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public SalesAppService(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Create(SalesCommand obj)
        {
            var entity = _mapper.Map<Sale>(obj);
            await _repository.Save(entity);
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sale>> GetAll(int skip, int limit)
        {
            return await _repository.GetAll(skip, limit);
        }

        public async Task<Sale> GetById(string id)
        {
            //Validation
            AssertionConcern.AssertArgumentNotNull(id, "La identificación no puede estar vacía");

            return await _repository.GetById(id);
        }

        public void Update(SalesCommand obj)
        {
            throw new NotImplementedException();
        }
    }
}
