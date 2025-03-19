using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusher.Console.EditGeneratedTemplate;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using System.Threading;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class TemplateDropdownWindow : Page
  {
    public TemplateDropdownWindow()
    {
      InitializeComponent();
      LoadTemplates();
    }

    private async void LoadTemplates()
    {
      GetTemplateNamesResponse response = await new GenericCall().GetAllGeneric<GetTemplateNamesResponse>(
          UrlConstants.SERVER_URL + "/" + UrlConstants.TemplateController.BASE_URL + "/" + UrlConstants.TemplateController.GET_TEMPLATE_NAMES,
          new CancellationToken()
      );

      TemplateDropdown.ItemsSource = response.Data;

      TemplateDropdown.SelectionChanged += (s, e) =>
      {
        var selectedTemplate = TemplateDropdown.SelectedItem as TemplateNameDto;
        if (selectedTemplate != null)
        {
          // Navigate to the EditGeneratedTemplateChapterSide page and pass the selected template ID
          var editTemplatePage = new EditGeneratedTemplateChapterSide(selectedTemplate.Id);
          NavigationService?.Navigate(editTemplatePage);
        }
      };
    }
  }
}
