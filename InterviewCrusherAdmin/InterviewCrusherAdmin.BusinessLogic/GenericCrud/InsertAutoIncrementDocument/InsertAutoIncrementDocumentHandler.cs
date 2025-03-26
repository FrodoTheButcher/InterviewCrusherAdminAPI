using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument
{
  public class InsertAutoIncrementDocumentHandler<DtoRepresentation, DbEntityRepresentation> : IRequestHandler<InsertAutoIncrementDocumentRequest<DtoRepresentation, DbEntityRepresentation>, InsertAutoIncrementDocumentResponse>
   where DtoRepresentation : IDtoRepresentation
   where DbEntityRepresentation : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    private readonly IAutoIncrementRepository<DbEntityRepresentation> _repository;
    private readonly AutoMapperWrapper autoMapperWrapper;
    public InsertAutoIncrementDocumentHandler(IAutoIncrementRepository<DbEntityRepresentation> repository, AutoMapperWrapper mapper)
    {
      _repository = repository ?? throw new DependencyException<IAutoIncrementRepository<DbEntityRepresentation>>();
      this.autoMapperWrapper = mapper ?? throw new DependencyException<AutoMapperWrapper>();
    }
    public async Task<InsertAutoIncrementDocumentResponse> Handle(InsertAutoIncrementDocumentRequest<DtoRepresentation, DbEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var insertResult = await _repository.CreateAutoIncrementAsync(this.autoMapperWrapper.Mapper.Map<DbEntityRepresentation>(request.DocumentToInsert), cancellationToken);
      return new InsertAutoIncrementDocumentResponse(insertResult);
    }
  }
}
