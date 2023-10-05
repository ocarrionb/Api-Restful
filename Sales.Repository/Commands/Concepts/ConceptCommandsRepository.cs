using Sales.Domain;
using Sales.Domain.Entity;

namespace Sales.Repository.Commands.Concepts
{
    public sealed class ConceptCommandsRepository : IConceptCommandsRepository
    {
        private readonly ApplicationDbContext _context;
        public ConceptCommandsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Concept> CreateConcept(Concept concept)
        {
            _context.Concept.Add(concept);
            await _context.SaveChangesAsync();
            return concept;
        }
    }
}
