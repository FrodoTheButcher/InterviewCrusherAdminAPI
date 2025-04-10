using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using System.Windows.Controls;

namespace InterviewCrusher.Console.RepresentationPages
{
  internal class Helper
  {

      public async static void LoadTemplates(ComboBox TemplateDropdown, TemplateNameDto TemplateNameDto)
      {
        GetTemplateNamesResponse response = await new GenericCall().GetAllGeneric<GetTemplateNamesResponse>(
            UrlConstants.SERVER_URL + "/" + UrlConstants.TemplateController.BASE_URL + "/" + UrlConstants.TemplateController.GET_TEMPLATE_NAMES,
            new CancellationToken()
        );

        TemplateDropdown.ItemsSource = response.Data;

        TemplateDropdown.SelectionChanged += (s, e) =>
        {
          var selectedTemplate = TemplateDropdown.SelectedItem as TemplateNameDto;
          TemplateNameDto = selectedTemplate;
        };
      }
    
  }
}
