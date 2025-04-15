using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using MediatR;
namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName
{
  public class GetDocumentsNameHandler<DatabaseEntityRepresentation> : IRequestHandler<GetDocumentsNameRequest<DatabaseEntityRepresentation>, GetDocumentsNameResponse>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IGenericCrudRepository<DatabaseEntityRepresentation> repository;

    public GetDocumentsNameHandler(IGenericCrudRepository<DatabaseEntityRepresentation> repository)
    {
      this.repository = repository;
    }
    public async Task<GetDocumentsNameResponse> Handle(GetDocumentsNameRequest<DatabaseEntityRepresentation> request, CancellationToken cancellationToken)
    {
      List<IBaseDataEntity> response = await this.repository.GetBaseDatas(cancellationToken);
      List<BaseDataEntity> converted = response
          .Select(x => x as BaseDataEntity)
          .Where(x => x != null)
          .ToList();
      return new GetDocumentsNameResponse(converted);
    }
  }
}
