using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Domain;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.ReplaceDocument
{
  public class ReplaceDocumentHandler<DatabaseEntityRepresentation>
    : IRequestHandler<ReplaceDocumentRequest<DatabaseEntityRepresentation>, ReplaceDocumentResponse>
    where DatabaseEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IRepository<DatabaseEntityRepresentation> repository;
    public ReplaceDocumentHandler(IRepository<DatabaseEntityRepresentation> repository, AutoMapperWrapper mapper)
    {
      this.repository = repository ?? throw new DependencyException<IRepository<DatabaseEntityRepresentation>>();
    }

    public async Task<ReplaceDocumentResponse> Handle(ReplaceDocumentRequest<DatabaseEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var replaced = await this.repository.ReplaceAsync(request.DocumentToReplace.Id, request.DocumentToReplace, cancellationToken);
      return new ReplaceDocumentResponse(replaced);
    }
  }
}
