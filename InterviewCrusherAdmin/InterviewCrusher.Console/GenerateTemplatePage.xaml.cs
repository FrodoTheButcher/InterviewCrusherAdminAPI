using InterviewCrusherAdmin.CommonDomain.TemplateDto.GenerateTemplateDto;
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

    private void AddTemplateButton_Click(object sender, RoutedEventArgs e)
    {
      string image = TemplateImage.Source.ToString();
      string templateName = TemplateNameTextBox.Text;
      string templateDescription = TemplateDescriptionTextBox.Text;
      string averageTimeText = AverageTimeTextBox.Text;

      List<string> selectedChapterIds = ChapterIdsListBox.SelectedItems
          .OfType<ListBoxItem>()
          .Select(item => item.Content.ToString())
          .ToList();


      var generateTemplateDto = new GenerateTemplateDto
      {
        Title = templateName,
       // Chapters = selectedChapterIds,
        Difficulty = 10,
        Description = templateDescription,
        Image = image
      };
      //call the controller from the ASP.NET API 

    }
  }
}
