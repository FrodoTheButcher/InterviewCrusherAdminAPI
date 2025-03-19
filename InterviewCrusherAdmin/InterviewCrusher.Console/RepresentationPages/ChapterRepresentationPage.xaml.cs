using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.Chapter.CreateChapterAutoIncrement;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.ChapterDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using InterviewCrusherAdmin.Domain.Chapter;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console.RepresentationPages
{
  /// <summary>
  /// Interaction logic for ChapterRepresentationPage.xaml
  /// </summary>
  public partial class ChapterRepresentationPage : Page
  {
    private TemplateNameDto TemplateNameDto;
    public ChapterRepresentationPage()
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
        this.TemplateNameDto = selectedTemplate;
      };
    }
    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      if(this.TemplateNameDto == null)
      {
        MessageBox.Show("Template not selected");
        return;
      }
      string title = this.TitleTextBox.Text;
      string description = this.DescriptionTextBox.Text;
      string templateId = this.TemplateNameDto.Id;
      string sourceLink = this.SourceLinkTextBox.Text;
      string sourceCode = this.SourceCodeTextBox.Text;

      ChapterRepresentationDto chapterRepresentationDto = new ChapterRepresentationDto(title, templateId, description, sourceLink, sourceCode); ;
      GenericCall genericCall = new GenericCall();
      CreateChapterRepresentationAutoIncrementRequest request = new CreateChapterRepresentationAutoIncrementRequest();
      request.RepresentationDto = chapterRepresentationDto;
      var response = await genericCall.InsertGeneric(request, UrlConstants.ChapterController.CREATE_CHAPTER_REPRESENTATION_FULL_URL(), CancellationToken.None);
      if (response != null)
      {
        MessageBox.Show(response.Message);
      }
    }
  }
}
