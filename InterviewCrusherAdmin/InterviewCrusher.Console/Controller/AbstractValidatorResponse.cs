namespace InterviewCrusher.Console.Controller
{
  using System.Collections.Generic;
  using System.Text.Json.Serialization;

  public class AbstractValidatorResponse
  {
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("errors")]
    public Dictionary<string, List<string>> Errors { get; set; }

    [JsonPropertyName("traceId")]
    public string TraceId { get; set; }

    public string GetMessagesList()
    {
      if (Errors == null || Errors.Count == 0)
        return "No validation errors.";

      return string.Join("\n", Errors.SelectMany(
          kvp => kvp.Value.Select(errorMsg => $"{kvp.Key}: {errorMsg}")
      ));
    }
  }

}
