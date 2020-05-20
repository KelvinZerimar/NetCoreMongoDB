using AutoMapper;
using Application.App.Commands;
using Application.App.Models;
using Domain.DomainEntities;

namespace Service.WebApi.Mappings
{
    public class SalesProfile: Profile
    {
        public SalesProfile()
        {
            CreateMap<Sale, SalesDto>();
            CreateMap<SalesCommand, Sale>();
        }
    }
}
