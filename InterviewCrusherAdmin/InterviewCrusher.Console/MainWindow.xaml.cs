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
      TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
    }
  }
}
