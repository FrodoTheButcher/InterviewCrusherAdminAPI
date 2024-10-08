using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo
{
  public class GeneratedVideoDto : IDtoRepresentation
  {
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public float VideoLength { get; set; }

    public string Description { get; set; } = string.Empty;
  }
}
