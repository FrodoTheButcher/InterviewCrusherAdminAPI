using InterviewCrusherAdmin.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusher.AbstractDomain.Template
{
  public class BaseTemplateDto : IDtoRepresentation
  {
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string AvarageTimeToFinish { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int CoinsEarnedIfFinished { get; set; }
  }
}
