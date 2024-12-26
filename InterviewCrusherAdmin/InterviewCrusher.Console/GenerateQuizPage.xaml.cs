using InterviewCrusher.Console.Singleton;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class GenerateQuizPage : Page
  {
    public GeneratedQuizDto Quiz { get; set; }
    public ObservableCollection<GenerateQuizAnswer> QuizAnswers { get; set; }

    public GenerateQuizPage()
    {
      InitializeComponent();

      // Initialize Quiz DTO and the Answers collection
      Quiz = new GeneratedQuizDto();
      QuizAnswers = new ObservableCollection<GenerateQuizAnswer>();

      // Bind the Answers collection to the ListView
      AnswersListView.ItemsSource = QuizAnswers;
    }

    private void AddAnswerButton_Click(object sender, RoutedEventArgs e)
    {
      // Validate inputs
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

      // Add a new answer to the collection
      var newAnswer = new GenerateQuizAnswer
      {
        Name = NewAnswerNameTextBox.Text,
        IsCorrect = NewAnswerIsCorrectCheckBox.IsChecked ?? false,
        Explanation = NewAnswerExplanationTextBox.Text
      };

      QuizAnswers.Add(newAnswer);

      // Clear input fields
      NewAnswerNameTextBox.Text = string.Empty;
      NewAnswerExplanationTextBox.Text = string.Empty;
      NewAnswerIsCorrectCheckBox.IsChecked = false;
    }

    private void SubmitQuizButton_Click(object sender, RoutedEventArgs e)
    {
      // Populate the Quiz object with user inputs
      Quiz.Name = QuizNameTextBox.Text;
      Quiz.Description = QuizDescriptionTextBox.Text;
      Quiz.Difficulty = (DifficultyComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
      Quiz.Hint = HintTextBox.Text;
      Quiz.QuizAnswers = new List<GenerateQuizAnswer>(QuizAnswers);

      // Validate Quiz data
      if (string.IsNullOrWhiteSpace(Quiz.Name))
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
      // Show a success message or handle the submitted Quiz object
      MessageBox.Show($"Quiz '{Quiz.Name}' submitted with {Quiz.QuizAnswers.Count} answers.");
    }
  }
}
