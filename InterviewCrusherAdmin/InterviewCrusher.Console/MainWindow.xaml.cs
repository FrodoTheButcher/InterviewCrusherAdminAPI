using InterviewCrusher.Console.RepresentationPages;
using InterviewCrusher.Console.Singleton;
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
    private void NavigateToGenerateTemplate(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new GenerateTemplateRoute());
    }

    private void NavigateToViewChapterRepresentation(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new ChapterRepresentationPage());
    }
    private void NavigateToViewTemplates(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new TemplateDropdownWindow());
    }

    private void NavigateToViewVideoRepresentation(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new VideoRepresentation());

    }

    private void MainContentFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {

    }

    private void NavigateToViewQuizRepresentation(object sender, RoutedEventArgs e)
    {
      MainContentFrame.Navigate(new QuizRepresentation());
    }
  }
}
