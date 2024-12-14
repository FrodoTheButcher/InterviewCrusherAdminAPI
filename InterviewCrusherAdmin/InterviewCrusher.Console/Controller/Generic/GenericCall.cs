using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.Responses;
using System.Net.Http;
using System.Net.Http.Json;

namespace InterviewCrusher.Console.Controller.Generic
{
  internal class GenericCall
  {
    public async Task<Response> InsertGeneric<T>(T request, CancellationToken token)
      where T : Request
    {
      var response = new Response();
      try
      {
        using (var httpClient = new HttpClient())
        {
          var dataresponse = await httpClient.PostAsJsonAsync("https://yourapiurl.com/api/GenerateTemplate", request);
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
