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
  /// Interaction logic for Chapter.xaml
  /// </summary>
  public partial class GenerateChapterPage : Page
  {
    public GenerateChapterPage()
    {
      InitializeComponent();
    }
    private void AddChapterButton_Click(object sender, RoutedEventArgs e)
    {
      string templateId = TemplateIdTextBox.Text;
      string chapterName = ChapterNameTextBox.Text;
      string description = DescriptionTextBox.Text;

      if (string.IsNullOrWhiteSpace(templateId) || string.IsNullOrWhiteSpace(chapterName))
      {
        MessageBox.Show("Template ID and Chapter Name are required fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
      }

      MessageBox.Show($"Chapter Added:\nTemplate ID: {templateId}\nChapter Name: {chapterName}\nDescription: {description}",
          "Chapter Information", MessageBoxButton.OK, MessageBoxImage.Information);

    }
  }
}
