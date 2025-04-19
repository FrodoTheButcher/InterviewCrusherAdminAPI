using InterviewCrusher.Console.Singleton;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class GenerateQuizPage : Page
  {
    public GeneratedQuizDto Quiz { get; set; }
    public ObservableCollection<GenerateQuizAnswerDto> QuizAnswers { get; set; }
    public ObservableCollection<string> QuizImages { get; set; }

    public GenerateQuizPage()
    {
      InitializeComponent();

      Quiz = new GeneratedQuizDto();
      QuizAnswers = new ObservableCollection<GenerateQuizAnswerDto>();
      QuizImages = new ObservableCollection<string>();

      AnswersListView.ItemsSource = QuizAnswers;
      ImagesListBox.ItemsSource = QuizImages;
    }

    private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrWhiteSpace(NewAnswerNameTextBox.Text))
      {
        MessageBox.Show("Answer name cannot be empty.");
        return;
      }

      if (string.IsNullOrWhiteSpace(NewAnswerExplanationTextBox.Text))
      {
        MessageBox.Show("Answer explanation cannot be empty.");
        return;
      }

      var newAnswer = new GenerateQuizAnswerDto
      {
        Name = NewAnswerNameTextBox.Text,
        IsCorrect = NewAnswerIsCorrectCheckBox.IsChecked ?? false,
        Explanation = NewAnswerExplanationTextBox.Text
      };

      QuizAnswers.Add(newAnswer);

      NewAnswerNameTextBox.Text = string.Empty;
      NewAnswerExplanationTextBox.Text = string.Empty;
      NewAnswerIsCorrectCheckBox.IsChecked = false;
    }

    private void AddImageButton_Click(object sender, RoutedEventArgs e)
    {
      var openFileDialog = new OpenFileDialog
      {
        Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp",
        Multiselect = true
      };

      if (openFileDialog.ShowDialog() == true)
      {
        foreach (string filename in openFileDialog.FileNames)
        {
          if (!QuizImages.Contains(filename))
          {
            QuizImages.Add(filename);
          }
        }
      }
    }

    private void SubmitQuizButton_Click(object sender, RoutedEventArgs e)
    {
      Quiz.Title = QuizNameTextBox.Text;
      Quiz.Description = QuizDescriptionTextBox.Text;
      Quiz.Difficulty = (DifficultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
      Quiz.Hint = HintTextBox.Text;
      Quiz.QuizAnswers = new List<GenerateQuizAnswerDto>(QuizAnswers);
      Quiz.Images = new List<string>(QuizImages); // Add image paths

      if (string.IsNullOrWhiteSpace(Quiz.Title))
      {
        MessageBox.Show("Quiz name cannot be empty.");
        return;
      }

      if (QuizAnswers.Count == 0)
      {
        MessageBox.Show("You must add at least one answer.");
        return;
      }

      TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
      templateDataStorage.AddGeneratedQuizDto(Quiz);
      MessageBox.Show($"Quiz '{Quiz.Title}' submitted with {Quiz.QuizAnswers.Count} answers and {Quiz.Images.Count} images.");
    }
  }
}
