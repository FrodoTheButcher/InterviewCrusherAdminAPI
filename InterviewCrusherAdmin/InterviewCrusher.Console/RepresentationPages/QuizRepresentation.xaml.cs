using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.QuizDto.GenerateQuizDto;
using InterviewCrusherAdmin.CommonDomain.TemplateDto;
using InterviewCrusherAdmin.Controllers;
using InterviewCrusherAdmin.Domain.Chapter;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateQuiz;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static InterviewCrusherAdmin.CommonDomain.Constants;

namespace InterviewCrusher.Console.RepresentationPages
{
  /// <summary>
  /// Interaction logic for QuizRepresentation.xaml
  /// </summary>
  public partial class QuizRepresentation : Page
  {
    private ObservableCollection<GenerateQuizAnswerDto> QuizAnswers { get; set; } = new();
    private TemplateNameDto TemplateNameDto;
    public List<string> Difficulties { get; set; }

    public QuizRepresentation()
    {
      InitializeComponent();

      QuizAnswersList.ItemsSource = QuizAnswers;

      Helper.LoadTemplates(this.TemplateDropdown, this.TemplateNameDto);
      LoadDifficulties();
    }

    private void AddAnswer_Click(object sender, RoutedEventArgs e)
    {
      QuizAnswers.Add(new GenerateQuizAnswerDto());
    }
    private void LoadDifficulties()
    {
      Difficulties = Constants.DIFFICULTIES.Difficulties;
      DifficultyComboBox.ItemsSource = Difficulties;
    }
    private async void SaveQuiz_Click(object sender, RoutedEventArgs e)
    {
      var quiz = new GeneratedQuizDto
      {
        Title = TitleTextBox.Text,
        Description = DescriptionTextBox.Text,
        Difficulty = this.DifficultyComboBox.Text,
        Hint = HintTextBox.Text,
        ExerciseNumber = ushort.TryParse(ExerciseNumberTextBox.Text, out var num) ? num : (ushort)0,
        QuizAnswers = QuizAnswers.ToList(),
        ParentId = TemplateNameDto?.Id ?? string.Empty
      };
      GenericCall genericCall = new GenericCall();
      InsertAutoIncrementDocumentRequest<GeneratedQuizDto, GenerateQuiz> request = new();
      request.DocumentToInsert = quiz;
      var response = await genericCall.InsertGeneric(request, UrlConstants.GenericController.INSERT_AUTO_INCREMENT_VIDEO_FULL_URL(), CancellationToken.None);
      if (response != null)
      {
        MessageBox.Show(response.Message);
      }
      MessageBox.Show($"Quiz \"{quiz.Title}\" with {quiz.QuizAnswers.Count} answers saved for template: {quiz.ParentId}");
    }
  }
}
