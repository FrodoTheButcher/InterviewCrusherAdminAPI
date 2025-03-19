using InterviewCrusherAdmin.DataAbstraction.Extensions;
using InterviewCrusherAdmin.Domain;
using InterviewCrusherAdmin.Domain.Chapter;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Chapter.CreateChapterAutoIncrement
{
  public class CreateChapterRepresentationAutoIncrementHandler : IRequestHandler<CreateChapterRepresentationAutoIncrementRequest, CreateChapterRepresentationAutoIncrementResponse>
  {
    private readonly IChapterRepresentationRepository _repository;
    private readonly AutoMapperWrapper mapWrapper;

    public CreateChapterRepresentationAutoIncrementHandler(IChapterRepresentationRepository repository, AutoMapperWrapper autoMapper)
    {
      this.mapWrapper = autoMapper ?? throw new DependencyException<AutoMapperWrapper>();
      _repository = repository ?? throw new DependencyException<IChapterRepresentationRepository>();
    }
    public async Task<CreateChapterRepresentationAutoIncrementResponse> Handle(CreateChapterRepresentationAutoIncrementRequest request, CancellationToken cancellationToken)
    {
      string id = await this._repository.CreateAutoIncrementAsync(this.mapWrapper.Mapper.Map<ChapterRepresentation>(request.RepresentationDto), cancellationToken);
      return new CreateChapterRepresentationAutoIncrementResponse(id);
    }
  }
}
