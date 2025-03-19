using InterviewCrusherAdmin.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter
{
  public class GenerateVideo : IDatabaseEntityRepresentation
  {
    public string Name { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public float VideoLength { get; set; }

    public string Description { get; set; } = string.Empty;

    public short ExerciseNumber { get; set; }
  }
}
