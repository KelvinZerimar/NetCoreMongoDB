using AutoMapper;
using Controle.Sales.Application.Models;
using Controle.Sales.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle.Sales.API.Mappings
{
    public class SalesProfile: Profile
    {
        public SalesProfile()
        {
            CreateMap<Sale, SalesDto>();
        }
    }
}
