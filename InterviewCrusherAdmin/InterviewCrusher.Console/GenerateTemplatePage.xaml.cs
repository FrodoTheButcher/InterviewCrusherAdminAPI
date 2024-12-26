using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusher.Console.Singleton;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertDocument;
using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate;
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

namespace InterviewCrusher.Console
{
  /// <summary>
  /// Interaction logic for GenerateTemplatePage.xaml
  /// </summary>
  public partial class GenerateTemplatePage : Page
  {
    public GenerateTemplatePage()
    {
      InitializeComponent();
    }
    private void SelectImageButton_Click(object sender, RoutedEventArgs e)
    {
      var openFileDialog = new Microsoft.Win32.OpenFileDialog
      {
        Filter = "Image Files (*.png; *.jpg; *.jpeg)|*.png;*.jpg;*.jpeg"
      };

      if (openFileDialog.ShowDialog() == true)
      {
        TemplateImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
      }
    }

    private async void AddTemplateButton_Click(object sender, RoutedEventArgs e)
    {
      string image = string.Empty;
      try
      {
        image = TemplateImage.Source.ToString();

      }
      catch (Exception ex)
      {
      }
      string templateName = TemplateNameTextBox.Text;
      string templateDescription = TemplateDescriptionTextBox.Text;
      string averageTimeText = AverageTimeTextBox.Text;

      TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
      var generateTemplateDto = new GenerateTemplateDto
      {
        Title = templateName,
        Difficulty = 10,
        Description = templateDescription,
        Image = image,
        GeneratedChaptersDtos = templateDataStorage.GetGeneratedChaptersAndClearEverything(),
      };
      InsertDocumentRequest<GenerateTemplateDto, GenerateTemplate> insertDocumentRequest = new InsertDocumentRequest<GenerateTemplateDto, GenerateTemplate>();
      insertDocumentRequest.DocumentToInsert = generateTemplateDto;

      GenericCall genericCall = new GenericCall();
      await genericCall.InsertGeneric<GenerateTemplateDto, GenerateTemplate>(insertDocumentRequest, CancellationToken.None);
    }
  }
}
