﻿using AutoMapper;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.DataAbstraction.Repositories;
using InterviewCrusherAdmin.Domain;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument
{
  public class InsertDocumentHandler<DtoRepresentation, DbEntityRepresentation> : IRequestHandler<InsertDocumentRequest<DtoRepresentation, DbEntityRepresentation>, InsertDocumentResponse>
    where DtoRepresentation : IDtoRepresentation
    where DbEntityRepresentation : IDatabaseEntityRepresentation
  {
    private readonly IGenericCrudRepository<DbEntityRepresentation> _repository;
    private readonly AutoMapperWrapper autoMapperWrapper;
    public InsertDocumentHandler(IGenericCrudRepository<DbEntityRepresentation> repository, AutoMapperWrapper mapper)
    {
      _repository = repository ?? throw new DependencyException<IGenericCrudRepository<DbEntityRepresentation>>();
      this.autoMapperWrapper = mapper ?? throw new DependencyException<AutoMapperWrapper>();
    }
    public async Task<InsertDocumentResponse> Handle(InsertDocumentRequest<DtoRepresentation, DbEntityRepresentation> request, CancellationToken cancellationToken)
    {
      var insertResult = await _repository.CreateAsync(this.autoMapperWrapper.Mapper.Map<DbEntityRepresentation>(request.DocumentToInsert), cancellationToken);
      return new InsertDocumentResponse(insertResult);
    }
  }
}
