using InterviewCrusher.Console.Singleton;
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
      string chapterName = ChapterNameTextBox.Text;
      string chapterDescription = DescriptionTextBox.Text;

      TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
      templateDataStorage.AddGeneratedChapterDtoWithPreviousDataAndCleanIt(chapterName, chapterDescription);
      MessageBox.Show("Chapter added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
