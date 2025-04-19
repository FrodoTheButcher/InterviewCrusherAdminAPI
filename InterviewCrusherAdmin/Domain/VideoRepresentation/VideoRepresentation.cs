using InterviewCrusher.AbstractDomain.Video;
using InterviewCrusherAdmin.DataAbstraction;
using InterviewCrusherAdmin.DataAbstraction.IAutoIncrementRepository;

namespace InterviewCrusherAdmin.Domain.VideoRepresentation
{
  public class VideoRepresentation : BaseVideo, IDatabaseEntityRepresentation, IAutoIncrementEntity 
  {

  }
}
