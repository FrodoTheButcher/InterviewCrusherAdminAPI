using InterviewCrusher.Console.Singleton;
using InterviewCrusherAdmin.CommonDomain.VideosDto.GeneratedVideo;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class GenerateVideoPage : Page
  {
    public GenerateVideoPage()
    {
      InitializeComponent();
    }

    private void AddVideoButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        string videoName = VideoNameTextBox.Text;
        string videoDescription = VideoDescriptionTextBox.Text;
        string videoUrl = VideoUrlTextBox.Text;
        float videoLength = float.Parse(VideoLengthTextBox.Text);

        TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
        templateDataStorage.AddGeneratedVideoDto(new GeneratedVideoDto(videoName, videoUrl, videoLength, videoDescription));

        MessageBox.Show("Video added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
      }
      catch (System.Exception ex)
      {
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}
