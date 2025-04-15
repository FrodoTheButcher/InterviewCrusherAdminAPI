using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.GetDocumentsName;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using System.Windows.Controls;

namespace InterviewCrusher.Console.RepresentationPages
{
  internal class Helper
  {

      public async static void LoadTemplates(ComboBox TemplateDropdown)
      {
        GetDocumentsNameResponse response = await new GenericCall().GetAllGeneric<GetDocumentsNameResponse>(
            UrlConstants.SERVER_URL + "/" + UrlConstants.GenericController.BASE_URL + "/" + UrlConstants.GenericController.GET_TEMPLATE_NAMES,
            new CancellationToken()
        );

        TemplateDropdown.ItemsSource = response.Data;

        TemplateDropdown.SelectionChanged += (s, e) =>
        {
          var selectedTemplate = TemplateDropdown.SelectedItem as BaseDataEntity;
        };
      }

    public async static void LoadChapters(ComboBox ChapterDropdown)
    {
      GetDocumentsNameResponse response = await new GenericCall().GetAllGeneric<GetDocumentsNameResponse>(
          UrlConstants.SERVER_URL + "/" + UrlConstants.GenericController.BASE_URL + "/" + UrlConstants.GenericController.GET_CHAPTER_NAMES,
          new CancellationToken()
      );

      ChapterDropdown.ItemsSource = response.Data;

      ChapterDropdown.SelectionChanged += (s, e) =>
      {
        var selectedTemplate = ChapterDropdown.SelectedItem as BaseDataEntity;
      };
    }

  }
}
