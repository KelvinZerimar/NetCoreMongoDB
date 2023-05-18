using Application.App.Commands;
using Application.App.Interfaces;
using AutoMapper;
using Domain.DomainEntities;
using Domain.Interfaces;
using Infra.Cross.AssertionConcern;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Services
{
    public class SalesAppService : ISalesAppService
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

        public async Task<long> GetCountAll()
        {
            return await _repository.GetCountAll();
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

        public async Task<IEnumerable<Sale>> GetCountry(string texto)
        {
            //Validation
            AssertionConcern.AssertArgumentNotNull(texto, "El texto no puede estar vacía");

            return await _repository.GetCountry(texto);
        }

        public void Update(SalesCommand obj)
        {
            throw new NotImplementedException();
        }
    }
}
