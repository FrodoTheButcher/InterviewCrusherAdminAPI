using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.DeleteDocument
{
  public class DeleteDocumentHandler<DbEntityRepresentation> : IRequestHandler<DeleteDocumentRequest<DbEntityRepresentation>, DeleteDocumentResponse>
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IGenericCrudRepository<DbEntityRepresentation> _repository;

    public DeleteDocumentHandler(IGenericCrudRepository<DbEntityRepresentation> repository)
    {
      _repository = repository ?? throw new DependencyException<IGenericCrudRepository<DbEntityRepresentation>>();
    }
    public async Task<DeleteDocumentResponse> Handle(DeleteDocumentRequest<DbEntityRepresentation> request, CancellationToken cancellationToken)
    {
      bool deleted = await this._repository.DeleteAsync(request.Id, cancellationToken);
      return new DeleteDocumentResponse(deleted);
    }
  }
}
