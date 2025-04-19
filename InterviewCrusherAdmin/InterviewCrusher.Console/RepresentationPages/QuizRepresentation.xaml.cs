using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.Controllers;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace InterviewCrusher.Console.RepresentationPages
{
  public partial class QuizRepresentation : Page
  {
    private ObservableCollection<GenerateQuizAnswerDto> QuizAnswers { get; set; } = new();
    private List<string> Base64Images { get; set; } = new();

    public List<string> Difficulties { get; set; }

    public ObservableCollection<ImageItem> ImageItems { get; set; } = new();

    public QuizRepresentation()
    {
      InitializeComponent();

      QuizAnswersList.ItemsSource = QuizAnswers;
      SelectedImagesList.ItemsSource = ImageItems;

      Helper.LoadChapters(this.ChapterDropdown);
      LoadDifficulties();

     // this.PreviewKeyDown += QuizRepresentation_PreviewKeyDown;
    }

    private void LoadDifficulties()
    {
      Difficulties = Constants.DIFFICULTIES.Difficulties;
      DifficultyComboBox.ItemsSource = Difficulties;
    }

    private void AddAnswer_Click(object sender, RoutedEventArgs e)
    {
      QuizAnswers.Add(new GenerateQuizAnswerDto());
    }

    private async void SaveQuiz_Click(object sender, RoutedEventArgs e)
    {
      var quiz = new GeneratedQuizDto
      {
        Title = TitleTextBox.Text,
        Description = DescriptionTextBox.Text,
        Difficulty = DifficultyComboBox.Text,
        Hint = HintTextBox.Text,
        QuizAnswers = QuizAnswers.ToList(),
        ParentId = ChapterDropdown.SelectedValue?.ToString(),
        Images = Base64Images
      };

      GenericCall genericCall = new GenericCall();
      var request = new InsertAutoIncrementDocumentRequest<GeneratedQuizDto, GenerateQuiz>
      {
        DocumentToInsert = quiz
      };

      var response = await genericCall.InsertGeneric(
          request,
          UrlConstants.GenericController.INSERT_AUTO_INCREMENT_QUIZ_FULL_URL(),
          CancellationToken.None
      );

      if (response != null)
        MessageBox.Show(response.Message);

      MessageBox.Show($"Quiz \"{quiz.Title}\" cu {quiz.QuizAnswers.Count} răspunsuri și {Base64Images.Count} imagini salvat.");
    }

    private void UploadImages_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog
      {
        Multiselect = true,
        Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
      };

      if (openFileDialog.ShowDialog() == true)
      {
        foreach (var filename in openFileDialog.FileNames)
        {
          try
          {
            byte[] imageBytes = File.ReadAllBytes(filename);
            string base64 = Convert.ToBase64String(imageBytes);
            Base64Images.Add(base64);

            ImageItems.Add(new ImageItem
            {
              Preview = LoadBitmapImage(imageBytes),
              Base64 = base64
            });
          }
          catch (Exception ex)
          {
            MessageBox.Show($"Eroare la încărcarea imaginii: {ex.Message}");
          }
        }
      }
    }

    private void PasteScreenshot_Click(object sender, RoutedEventArgs e)
    {
      if (Clipboard.ContainsImage())
      {
        try
        {
          var image = Clipboard.GetImage();
          var encoder = new PngBitmapEncoder();
          encoder.Frames.Add(BitmapFrame.Create(image));

          using (var ms = new MemoryStream())
          {
            encoder.Save(ms);
            byte[] imageBytes = ms.ToArray();
            string base64 = Convert.ToBase64String(imageBytes);
            Base64Images.Add(base64);

            ImageItems.Add(new ImageItem
            {
              Preview = LoadBitmapImage(imageBytes),
              Base64 = base64
            });
          }

          MessageBox.Show("Screenshot adăugat cu succes!");
        }
        catch (Exception ex)
        {
          MessageBox.Show($"Eroare la procesarea clipboardului: {ex.Message}");
        }
      }
      else
      {
        MessageBox.Show("Clipboardul nu conține o imagine.");
      }
    }

    private BitmapImage LoadBitmapImage(byte[] imageBytes)
    {
      using (var stream = new MemoryStream(imageBytes))
      {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.StreamSource = stream;
        bitmap.EndInit();
        bitmap.Freeze();
        return bitmap;
      }
    }

    private void RemoveImage_Click(object sender, RoutedEventArgs e)
    {
      if (sender is Button button && button.Tag is ImageItem imageItem)
      {
        Base64Images.Remove(imageItem.Base64);
        ImageItems.Remove(imageItem);
      }
    }

    private void QuizRepresentation_PreviewKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
      {
        PasteScreenshot_Click(null, null);
      }
    }

    public class ImageItem
    {
      public BitmapImage Preview { get; set; }
      public string Base64 { get; set; }
    }
  }
}
