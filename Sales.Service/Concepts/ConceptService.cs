using AutoMapper;
using Sales.Domain.Entity;
using Sales.Domain.Requests.Concepts;
using Sales.Domain.Responses.Concepts;
using Sales.Repository.Commands.Concepts;

namespace Sales.Service.Concepts
{
    public class ConceptService : IConceptService
    {
        private readonly IConceptCommandsRepository _commandsRepository;
        private readonly IMapper _mapper;
        public ConceptService(IConceptCommandsRepository commandsRepository,
            IMapper mapper)
        {
            _commandsRepository = commandsRepository;
            _mapper = mapper;
        }
        public async Task<ConceptResponse> CreateConcet(CreateConceptRequest request)
            => _mapper.Map<ConceptResponse>(await _commandsRepository.CreateConcept(_mapper.Map<Concept>(request)));
    }
}
