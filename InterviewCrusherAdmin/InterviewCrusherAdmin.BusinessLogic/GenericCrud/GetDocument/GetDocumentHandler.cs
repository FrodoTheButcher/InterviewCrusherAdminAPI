using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Domain;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument
{
  public class GetDocumentHandler<DtoRepresentation, DatabaseEntityRepresentation> : IRequestHandler<GetDocumentRequest<DtoRepresentation, DatabaseEntityRepresentation>, GetDocumentResponse<DtoRepresentation>>
    where DtoRepresentation : IDtoRepresentation
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IRepository<DatabaseEntityRepresentation> repository;
    private readonly AutoMapperWrapper mapWrapper;

    public GetDocumentHandler(IRepository<DatabaseEntityRepresentation> repository, AutoMapperWrapper mapper)
    {
      this.repository = repository ?? throw new DependencyException<IRepository<DatabaseEntityRepresentation>>();
      this.mapWrapper = mapper ?? throw new DependencyException<AutoMapperWrapper>();
    }
    public async Task<GetDocumentResponse<DtoRepresentation>> Handle(GetDocumentRequest<DtoRepresentation, DatabaseEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var document = await this.repository.GetAsync(request.Id, cancellationToken);
      var dto = this.mapWrapper.Mapper.Map<DtoRepresentation>(document);
      return new GetDocumentResponse<DtoRepresentation>(dto);
    }
  }
}
