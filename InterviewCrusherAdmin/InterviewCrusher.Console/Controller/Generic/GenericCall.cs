using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.Responses;
using InterviewCrusherAdmin.DataAbstraction;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

namespace InterviewCrusher.Console.Controller.Generic
{
  internal class GenericCall
  {
    public async Task<Response> InsertGeneric<TDto, TDb>(InsertDocumentRequest<TDto, TDb> request, string path, CancellationToken token)
      where TDto : IDtoRepresentation
      where TDb : IDatabaseEntityRepresentation
    {
      var response = new Response();
      try
      {
        using (var httpClient = new HttpClient())
        {
          var dataresponse = await httpClient.PostAsJsonAsync(path, request);
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

    public async Task<CreateResponse?> InsertGeneric(Request request, string path, CancellationToken token)
    {
      CreateResponse response = null;
      try
      {
        using (var httpClient = new HttpClient())
        {
          var DocumentToInsert = Newtonsoft.Json.JsonConvert.SerializeObject(request);
          var content = new StringContent(DocumentToInsert, Encoding.UTF8, "application/json");

          var dataResponse = await httpClient.PostAsync(path, content);

          if (dataResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
          {
            var errorResponse = await dataResponse.Content.ReadAsStringAsync();
            var validatorResponse = await dataResponse.Content.ReadFromJsonAsync<AbstractValidatorResponse>();
            response = new CreateResponse(string.Empty)
            {
              Id = string.Empty,
              IsCreated = false,
              Message = validatorResponse?.GetMessagesList() ?? "Unknown error",
              StatusCode = System.Net.HttpStatusCode.BadRequest
            };
            return response;
          }
          response = await dataResponse.Content.ReadFromJsonAsync<CreateResponse>();
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
    public async Task<TResponse> GetAllGeneric<TResponse>(string path, CancellationToken token)
      where TResponse : Response
    {
      using (var httpClient = new HttpClient())
      {

        var dataresponse = await httpClient.GetAsync(path);
        string rawJson = await dataresponse.Content.ReadAsStringAsync();

        var response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(rawJson);
        return response;
      }
    }
  }
}
