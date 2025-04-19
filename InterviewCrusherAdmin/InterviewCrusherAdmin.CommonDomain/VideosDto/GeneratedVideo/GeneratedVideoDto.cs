using InterviewCrusher.AbstractDomain.Video;
using InterviewCrusherAdmin.DataAbstraction;

namespace InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo
{
  public class GeneratedVideoDto : BaseVideoDto, IDtoRepresentation
  {

    public GeneratedVideoDto()
    {
    }

    public GeneratedVideoDto(string name, string url, float videoLength, string description)
    {
      Title = name;
      Url = url;
      VideoLength = videoLength;
      Description = description;
    }
  }
}
