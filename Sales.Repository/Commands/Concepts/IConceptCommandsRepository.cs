using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Concepts
{
    public interface IConceptCommandsRepository
    {
        Task<Concept> CreateConcept(Concept concept);
    }
}
