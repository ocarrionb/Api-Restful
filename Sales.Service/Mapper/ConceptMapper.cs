using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Concepts;
using Sales.Domain.Responses.Concepts;

namespace Sales.Service.Mapper
{
    public sealed class ConceptMapper : Profile
    {
        public ConceptMapper() 
        {
            CreateMap<CreateConceptRequest, Concept>();
            CreateMap<Concept, ConceptResponse>();
        }
    }
}
