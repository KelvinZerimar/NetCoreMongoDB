﻿using Application.App.Commands;
using Application.App.Interfaces;
using Application.App.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.WebApi.Validators;
using System;
using System.Threading.Tasks;

namespace Service.WebApi.Controllers
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
        public async Task<ActionResult> GetSales(int param, int skip = 0, int limit = 20)
        {
            var salesFromRepo = await _appService.GetAll(skip, limit);
            //
            var req = Request.Headers;
            var req2 = Request.Body;
            var paginationMetadata = await _appService.GetCountAll();
            Response.Headers.Add("X-Pagination", paginationMetadata.ToString());

            //return Ok(_mapper.Map<IEnumerable<SalesDto>>(salesFromRepo));
            //return Ok(await _appService.GetAll(skip, limit));
            return Ok(salesFromRepo);
        }

        // GET: api/sales/salesId/GetSale
        [HttpGet("{salesId}/GetSale", Name = "GetSale")]
        public async Task<IActionResult> GetSale(string salesId)
        {
            //var salesFromRepo1 = _appService.GetById(ObjectId.Parse(salesId));
            var salesFromRepo = await _appService.GetById(salesId);

            if (salesFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SalesDto>(salesFromRepo));
        }

        // GET: api/sales/texto
        [HttpGet("{texto}/GetCountry", Name = "GetCountry")]
        public async Task<IActionResult> GetCountry(string texto)
        {
            var salesFromRepo = await _appService.GetCountry(texto);
            /*if (salesFromRepo.Count() == 0)
            {
                return NotFound();
            }*/

            //return Ok(_mapper.Map<IEnumerable<SalesDto>>(salesFromRepo));
            return Ok(salesFromRepo);
        }

        // POST api/sales
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalesCommand model)
        {
            try
            {
                var validator = new SalesValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid == false)
                {
                    return BadRequest(validationResult.Errors[0].ErrorMessage);
                }

                await _appService.Create(model);

                return Ok("Insert OK.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cargo massive from file csv
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