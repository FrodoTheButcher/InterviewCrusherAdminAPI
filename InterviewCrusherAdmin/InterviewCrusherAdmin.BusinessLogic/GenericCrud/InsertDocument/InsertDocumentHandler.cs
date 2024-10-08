using AutoMapper;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument
{
  public class InsertDocumentHandler<DtoRepresentation, DbEntityRepresentation> : IRequestHandler<InsertDocumentRequest<DtoRepresentation, DbEntityRepresentation>, InsertDocumentResponse>
    where DtoRepresentation : IDtoRepresentation
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IRepository<DbEntityRepresentation> _repository;
    private readonly IMapper mapper;

    public InsertDocumentHandler(IRepository<DbEntityRepresentation> repository, IMapper mapper)
    {
      _repository = repository;
      this.mapper = mapper;
    }
    public async Task<InsertDocumentResponse> Handle(InsertDocumentRequest<DtoRepresentation, DbEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var insertResult = await _repository.CreateAsync(this.mapper.Map<DbEntityRepresentation>(request.DocumentToInsert), cancellationToken);
      return new InsertDocumentResponse(insertResult);
    }
  }
}
