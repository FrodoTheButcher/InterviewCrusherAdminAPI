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
      
      string videoName = VideoNameTextBox.Text;
      string videoDescription = VideoDescriptionTextBox.Text;
      string videoUrl = VideoUrlTextBox.Text;
      string chapterId = ChapterIdTextBox.Text;

      // Validate and use the collected data
      if (string.IsNullOrWhiteSpace(videoName) || string.IsNullOrWhiteSpace(videoUrl))
      {
        MessageBox.Show("Video Name and Video URL are required fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
      }

      // Here you can add logic to handle these values, such as storing them in a database
      // For now, we’ll just display the information in a message box
      MessageBox.Show($"Video Added:\nName: {videoName}\nDescription: {videoDescription}\nURL: {videoUrl}\nChapter ID: {chapterId}",
          "Video Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}
