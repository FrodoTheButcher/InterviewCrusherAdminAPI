using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Domain;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetAllDocuments
{
  public class GetAllDocumentsHandler<DtoRepresentation, DatabaseEntityRepresentation> : IRequestHandler<GetAllDocumentsRequest<DtoRepresentation, DatabaseEntityRepresentation>, GetAllDocumentsResponse<DtoRepresentation>>
      where DtoRepresentation : IDtoRepresentation
      where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IGenericCrudRepository<DatabaseEntityRepresentation> repository;
    private readonly AutoMapperWrapper mapWrapper;

    public GetAllDocumentsHandler(IGenericCrudRepository<DatabaseEntityRepresentation> repository, AutoMapperWrapper mapper)
    {
      this.repository = repository ?? throw new DependencyException<IGenericCrudRepository<DatabaseEntityRepresentation>>();
      this.mapWrapper = mapper ?? throw new DependencyException<AutoMapperWrapper>();
    }
    public async Task<GetAllDocumentsResponse<DtoRepresentation>> Handle(GetAllDocumentsRequest<DtoRepresentation, DatabaseEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var document = await this.repository.GetAllAsync(cancellationToken);
      List<DtoRepresentation> dto = this.mapWrapper.Mapper.Map<List<DtoRepresentation>>(document);
      return new GetAllDocumentsResponse<DtoRepresentation>(dto);
    }
  }
}
