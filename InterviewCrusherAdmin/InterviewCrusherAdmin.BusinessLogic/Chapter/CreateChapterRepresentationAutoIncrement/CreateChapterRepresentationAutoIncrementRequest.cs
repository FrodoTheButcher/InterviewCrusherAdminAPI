using Amazon.Runtime.Internal;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using MediatR;

namespace InterviewCrusherAdmin.BusinessLogic.Chapter.CreateChapterAutoIncrement
{
  public class CreateChapterRepresentationAutoIncrementRequest : Request, IRequest<CreateChapterRepresentationAutoIncrementResponse>
  {
    public ChapterRepresentationDto RepresentationDto { get; set; } = new ChapterRepresentationDto();
  }
}
