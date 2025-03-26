using Microsoft.AspNetCore.Mvc;

namespace InterviewCrusherAdmin.Controllers
{
  public class UrlConstants
  {
    public const string SERVER_URL = "https://localhost:7235";
    public class GenericController
    {
      public const string BASE_URL = "api/Generic/";
      public const string GENERATE_VIDEO = "GenerateVideo";
      public const string GENERATE_ALGORITHM = "GenerateAlgorithm";
      public const string GENERATE_QUIZ = "GenerateQuiz";
      public const string GENERATE_TEMPLATE = "GenerateTemplate";

      public const string INITIALIZE_TEMPLATE = "InitializeTemplate";
      public const string INITIALIZE_CHAPTER = "InitializeChapter";

      public const string INSERT_AUTO_INCREMENT_CHAPTER = "InsertAutoIncrementChapter";
      public const string INSERT_AUTO_INCREMENT_QUIZ = "InsertAutoIncrementQuiz";
      public const string INSERT_AUTO_INCREMENT_VIDEO = "InsertAutoIncrementVideo";
      public const string INSERT_AUTO_INCREMENT_ALGORITHM = "InsertAutoIncrementAlgorithm";
      public const string GET_CHAPTERS_BY_TEMPLATE_ID = "GetChaptersByTemplateId";

      public const string DELETE_GENERATED_TEMPLATE = "DeleteGeneratedTemplate";
      public const string GET_GENERATED_TEMPLATE = "GetGeneratedTemplate";
      public const string GET_GENERATED_TEMPLATES = "GetGeneratedTemplates";
      public const string REPLACE_GENERATED_TEMPLATE = "ReplaceGeneratedTemplate";

      public string BASE_URL_PATH => BASE_URL;
      public string GENERATE_VIDEO_UR => GENERATE_VIDEO;
      public string GENERATE_ALGORITHM_URL => GENERATE_ALGORITHM;
      public string ENERATE_QUIZ => GENERATE_QUIZ;
      public string GENERATED_TEMPLATE => GENERATE_TEMPLATE;
      public string INITIALIZED_TEMPLATE => INITIALIZE_TEMPLATE;
      public string DELETE_GENERATED_TEMPLATE_URL(string id) => $"{DELETE_GENERATED_TEMPLATE}/{id}";

      public static string GET_CHAPTER_NAMES_BY_TEMPLATE_ID_FULL_URL(string id) => $"{SERVER_URL}/{BASE_URL}/{GET_CHAPTERS_BY_TEMPLATE_ID}/{id}";

      public string GET_GENERATED_TEMPLATE_URL(string id) => $"{GET_GENERATED_TEMPLATE}/{id}";

      public string REPLACE_GENERATED_TEMPLATE_URL => REPLACE_GENERATED_TEMPLATE;

    }

    public static class TemplateController
    {
      public const string BASE_URL = "api/Template";
      public const string GET_TEMPLATE_NAMES = "GetTemplateNames";
      public const string GET_TEMPLATE_WITH_CHAPTER_NAMES = "GetTemplateWithChapterNames";

      public static string GET_TEMPLATE_WITH_CHAPTER_NAMES_FULL_URL(string id) => $"{SERVER_URL}/{BASE_URL}/{GET_TEMPLATE_WITH_CHAPTER_NAMES}/{id}";

    }

    public static class ChapterController
    {
      public const string BASE_URL = "api/Chapter";
      public const string CREATE_CHAPTER_REPRESENTATION = "CreateChapterRepresentation";

      public static string CREATE_CHAPTER_REPRESENTATION_FULL_URL() => $"{SERVER_URL}/{BASE_URL}/{CREATE_CHAPTER_REPRESENTATION}";
    }
  }
}
