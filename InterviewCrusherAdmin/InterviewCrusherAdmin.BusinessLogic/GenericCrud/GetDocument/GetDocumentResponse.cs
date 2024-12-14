using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocument
{
  public class GetDocumentResponse<DtoRepresentation> : GetResponse<DtoRepresentation>
    where DtoRepresentation : IDtoRepresentation
  {
    public GetDocumentResponse(DtoRepresentation data) : base(data)
    {
    }
  }
}
