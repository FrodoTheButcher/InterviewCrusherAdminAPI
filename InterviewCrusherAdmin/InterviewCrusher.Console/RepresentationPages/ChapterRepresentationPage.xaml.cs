using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
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
    public ChapterRepresentationPage()
    {
      InitializeComponent();
      Helper.LoadTemplates(this.TemplateDropdown);
    }
   
    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      string title = this.TitleTextBox.Text;
      string description = this.DescriptionTextBox.Text;
      string templateId = this.TemplateDropdown.SelectedValue.ToString();
      string sourceLink = this.SourceLinkTextBox.Text;
      string sourceCode = this.SourceCodeTextBox.Text;

      ChapterRepresentationDto chapterRepresentationDto = new ChapterRepresentationDto(title, templateId, description, sourceLink, sourceCode); ;
      GenericCall genericCall = new GenericCall();
      InsertAutoIncrementDocumentRequest<ChapterRepresentationDto, ChapterRepresentation> request = new();
      request.DocumentToInsert = chapterRepresentationDto;
      var response = await genericCall.InsertGeneric(request, UrlConstants.GenericController.INSERT_AUTO_INCREMENT_CHAPTER_FULL_URL(), CancellationToken.None);
      if (response != null)
      {
        MessageBox.Show(response.Message);
      }
    }
  }
}
