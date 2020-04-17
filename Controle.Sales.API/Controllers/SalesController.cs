using AutoMapper;
using System.Collections.Generic;
using Controle.Sales.Application.Interfaces;
using Controle.Sales.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using MongoDB.Bson;
using Microsoft.AspNetCore.Cors;

namespace Controle.Sales.API.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesAppService _appService;
        private readonly IMapper _mapper;

        public SalesController(ISalesAppService appService, IMapper mapper)
        {
            _appService = appService ??
                throw new ArgumentNullException(nameof(appService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/sales
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<SalesDto>> GetSales(int skip = 0, int limit = 50)
        {
            var salesFromRepo = _appService.GetAll(skip, limit);
            return Ok(_mapper.Map<IEnumerable<SalesDto>>(salesFromRepo));
        }

        // GET: api/sales/Id
        [HttpGet("{salesId}", Name = "GetSale")]
        public IActionResult GetSale(string salesId)
        {
            var salesFromRepo = _appService.GetById(ObjectId.Parse(salesId));

            if (salesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SalesDto>(salesFromRepo));
        }

    }
}