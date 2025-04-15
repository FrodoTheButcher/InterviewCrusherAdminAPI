using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateNames;
using InterviewCrusherAdmin.CommonDomain.AbstractImplementations;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using InterviewCrusherAdmin.Domain.Chapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterviewCrusher.Console.RepresentationPages
{
  /// <summary>
  /// Interaction logic for VideoRepresentation.xaml
  /// </summary>
  public partial class VideoRepresentation : Page
  {
    public VideoRepresentation()
    {
      InitializeComponent();
      Helper.LoadChapters(this.ChapterDropdown);
    }
   
    private async void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      string title = this.TitleTextBox.Text;
      string description = this.DescriptionTextBox.Text;
      string templateId = this.ChapterDropdown.SelectedValue.ToString();
      string sourceLink = this.SourceLinkTextBox.Text;
      string sourceCode = this.VideoLength.Text;

      ChapterRepresentationDto chapterRepresentationDto = new ChapterRepresentationDto(title, templateId, description, sourceLink, sourceCode); ;
      GenericCall genericCall = new GenericCall();
      InsertAutoIncrementDocumentRequest<ChapterRepresentationDto, ChapterRepresentation> request = new();
      request.DocumentToInsert = chapterRepresentationDto;
      var response = await genericCall.InsertGeneric(request, UrlConstants.GenericController.INSERT_AUTO_INCREMENT_VIDEO_FULL_URL(), CancellationToken.None);
      if (response != null)
      {
        MessageBox.Show(response.Message);
      }
    }
  }
}
