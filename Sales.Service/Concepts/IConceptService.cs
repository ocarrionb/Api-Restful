using Sales.Domain.Requests.Concepts;
using Sales.Domain.Responses.Concepts;

namespace Sales.Service.Concepts
{
    public interface IConceptService
    {
        Task<ConceptResponse> CreateConcet(CreateConceptRequest request);
    }
}
