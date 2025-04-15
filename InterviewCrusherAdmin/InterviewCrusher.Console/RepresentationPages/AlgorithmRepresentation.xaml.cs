using InterviewCrusher.Console.Controller.Generic;
using InterviewCrusherAdmin.BusinessLogic.GenericCrud.InsertAutoIncrementDocument;
using InterviewCrusherAdmin.CommonDomain;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.AlgorithmRepresentation;
using InterviewCrusherAdmin.Controllers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console.RepresentationPages
{
  public partial class AlgorithmRepresentation : Page
  {
    private ObservableCollection<GenerateTestCaseRepresentationDto> TestCases { get; set; } = new();
    private ObservableCollection<GenerateAlgorithmRestrictionsRepresentationDto> Restrictions { get; set; } = new();
    public List<string> Difficulties { get; set; }

    public AlgorithmRepresentation()
    {
      InitializeComponent();

      TestCasesList.ItemsSource = TestCases;
      RestrictionsList.ItemsSource = Restrictions;

      Helper.LoadChapters(this.ChapterDropdown);
      LoadDifficulties();
    }

    private void LoadDifficulties()
    {
      Difficulties = Constants.DIFFICULTIES.Difficulties;
      DifficultyComboBox.ItemsSource = Difficulties;
    }

    private void AddTestCase_Click(object sender, RoutedEventArgs e)
    {
      TestCases.Add(new GenerateTestCaseRepresentationDto());
    }

    private void AddRestriction_Click(object sender, RoutedEventArgs e)
    {
      Restrictions.Add(new GenerateAlgorithmRestrictionsRepresentationDto());
    }

    private async void SaveAlgorithm_Click(object sender, RoutedEventArgs e)
    {
      var algorithm = new AlgorithmRepresentationDto
      {
        Title = TitleTextBox.Text,
        Description = DescriptionTextBox.Text,
        Difficulty = DifficultyComboBox.Text,
        Hint = HintTextBox.Text,
        CompletedCode = CompletedCodeTextBox.Text,
        AllLanguagesAvailable = AllLanguagesCheckbox.IsChecked ?? false,
        AlgorithmSolution = new SolutionB64Dto
        {
          SolutionB64 = SolutionTextBox.Text
        },
        TestCases = TestCases.ToList(),
        AlgorithmRestrictions = Restrictions.ToList(),
        ParentId = ChapterDropdown.SelectedValue?.ToString() ?? ""
      };

      GenericCall genericCall = new();
      var request = new InsertAutoIncrementDocumentRequest<AlgorithmRepresentationDto, InterviewCrusherAdmin.Domain.Algorithm.AlgorithmRepresentation>
      {
        DocumentToInsert = algorithm
      };

      var response = await genericCall.InsertGeneric(
          request,
          UrlConstants.GenericController.INSERT_AUTO_INCREMENT_ALGO_FULL_URL(),
          CancellationToken.None
      );

      MessageBox.Show(response?.Message ?? "Saved.");
    }
  }
}
