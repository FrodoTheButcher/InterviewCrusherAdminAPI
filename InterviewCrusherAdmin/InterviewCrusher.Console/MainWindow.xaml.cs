using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void NavigateToVideo(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateVideoPage());
    }

    private void NavigateToQuiz(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateQuizPage());
    }

    private void NavigateToAlgorithm(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateAlgorithmPage());
    }

    private void NavigateToChapter(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateChapterPage());
    }

    private void NavigateToTemplate(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateTemplatePage());
    }
  }
}
