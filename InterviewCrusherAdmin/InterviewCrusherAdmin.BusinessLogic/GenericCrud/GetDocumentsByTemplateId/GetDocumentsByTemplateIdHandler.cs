using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain;
using MediatR;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsByTemplateId
{
  public class GetDocumentsByTemplateIdHandler<DatabaseEntityRepresentation> : IRequestHandler<GetDocumentsByTemplateIdRequest<DatabaseEntityRepresentation>, GetDocumentsByTemplateIdResponse>
      where DatabaseEntityRepresentation : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    private readonly IAutoIncrementRepository<DatabaseEntityRepresentation> repository;

    public GetDocumentsByTemplateIdHandler(IAutoIncrementRepository<DatabaseEntityRepresentation> repository)
    {
      this.repository = repository ?? throw new DependencyException<IAutoIncrementRepository<DatabaseEntityRepresentation>>();
    }
    public async Task<GetDocumentsByTemplateIdResponse> Handle(GetDocumentsByTemplateIdRequest<DatabaseEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var documents = await this.repository.GetByTemplateIdSortedByNumber(request.Id, cancellationToken);
      return new GetDocumentsByTemplateIdResponse(documents);
    }
  }
}
