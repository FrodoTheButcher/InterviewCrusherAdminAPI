using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;
using InterviewCrusherAdmin.Domain.Chapter;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter
{
  public class GenerateVideo : IDatabaseEntityRepresentation, IAutoIncrementEntity
  {
    public string Title { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public float VideoLength { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ParentId { get; set; } = string.Empty;
    public ushort ExerciseNumber { get; set; } = ushort.MinValue;
  }
}
