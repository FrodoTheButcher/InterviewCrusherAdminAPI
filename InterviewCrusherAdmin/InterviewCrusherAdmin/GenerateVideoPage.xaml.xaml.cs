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
      TextBox VideoNameTextBox = (TextBox)FindName("VideoNameTextBox");
      TextBox VideoDescriptionTextBox = (TextBox)FindName("VideoDescriptionTextBox");
      TextBox VideoUrlTextBox = (TextBox)FindName("VideoUrlTextBox");
      TextBox ChapterIdTextBox = (TextBox)FindName("ChapterIdTextBox");

      string videoName = VideoNameTextBox.Text;
      string videoDescription = VideoDescriptionTextBox.Text;
      string videoUrl = VideoUrlTextBox.Text;
      string chapterId = ChapterIdTextBox.Text;

      if (string.IsNullOrWhiteSpace(videoName) || string.IsNullOrWhiteSpace(videoUrl))
      {
        MessageBox.Show("Video Name and Video URL are required fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
      }

      MessageBox.Show($"Video Added:\nName: {videoName}\nDescription: {videoDescription}\nURL: {videoUrl}\nChapter ID: {chapterId}",
          "Video Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
