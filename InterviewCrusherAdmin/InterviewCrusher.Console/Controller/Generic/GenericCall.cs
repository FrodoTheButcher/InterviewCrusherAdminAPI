using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;
using System.Net.Http;
using System.Net.Http.Json;

namespace InterviewCrusher.Console.Controller.Generic
{
  internal class GenericCall
  {
    public async Task<Response> InsertGeneric<TDto, TDb>(InsertDocumentRequest<TDto, TDb> request, CancellationToken token)
      where TDto : IDtoRepresentation
      where TDb : IDatabaseEntityRepresentation
    {
      var response = new Response();
      try
      {
        using (var httpClient = new HttpClient())
        {
          var dataresponse = await httpClient.PostAsJsonAsync("https://localhost:7235/api/Generic/GenerateTemplate", request);
          response = await dataresponse.Content.ReadFromJsonAsync<Response>();
          return response;
        }
      }
      catch (Exception ex)
      {
        response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        response.Message = ex.Message;
      }
      return response;
    }
  }
}
