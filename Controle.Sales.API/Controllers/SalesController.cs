using AutoMapper;
using System.Collections.Generic;
using Controle.Sales.Application.Interfaces;
using Controle.Sales.Application.Models;
using Controle.Sales.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<SalesDto>>> GetSales(int skip = 0, int limit = 50)
        {
            var salesFromRepo = await _appService.GetAll(skip, limit);
            return Ok(_mapper.Map<IEnumerable<SalesDto>>(salesFromRepo));
            //return Ok(await _appService.GetAll(skip, limit));
        }

        // GET: api/sales/Id
        [HttpGet("{salesId}", Name = "GetSale")]
        public async Task<IActionResult> GetSale(string salesId)
        {
           // var salesFromRepo = _appService.GetById(ObjectId.Parse(salesId));
            var salesFromRepo = await _appService.GetById(salesId);

            if (salesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SalesDto>(salesFromRepo));
        }

        // POST api/sales
        [HttpPost]
        public async Task<IActionResult> Post(SalesCommand model)
        {
            try
            {
                await _appService.Create(model);

                return Ok("Insert sucess!!!...");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Carga masiva from file csv
        /// </summary>
        private void Bulk()
        {
            string[] formats = {"M/d/yyyy", "M/d/yyyy",
                     "MM/dd/yyyy", "M/d/yyyy",
                     "M/d/yyyy", "M/d/yyyy",
                     "M/d/yyyy", "M/d/yyyy",
                     "MM/dd/yyyy", "M/dd/yyyy",
                     "MM/d/yyyy" };


            //
            //foreach (var e in new ChoCSVReader<Employee>("1000Sales.csv")
            //    .WithFirstLineHeader()
            //    .QuoteAllFields().WithDelimiter(",")
            //    .Configure(x => x.Culture = CultureInfo.InvariantCulture))
            //{
            //    model.Region = e.Region;
            //    model.Country = e.Country;
            //    model.ItemType = e.ItemType;
            //    model.SalesChannel = e.SalesChannel;
            //    model.OrderPriority = e.OrderPriority;
            //    model.OrderDate = DateTime.ParseExact(e.OrderDate, formats, null);
            //    model.OrderID = e.OrderID;
            //    model.ShipDate = DateTime.ParseExact(e.ShipDate, formats, null);
            //    model.UnitsSold = e.UnitsSold;
            //    model.UnitPrice = e.UnitPrice;
            //    model.UnitCost = e.UnitCost;
            //    model.TotalRevenue = e.TotalRevenue;
            //    model.TotalCost = e.TotalCost;
            //    model.TotalProfit = e.TotalProfit;

            //}
        }
    }
}