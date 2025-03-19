using InterviewCrusher.Console.Singleton;
using InterviewCrusherAdmin.CommonDomain.AlgorithmDto.GeneratedAlgorithm;
using InterviewCrusherAdmin.Domain.GenerateTemplateDto.GenerateTemplate.GenerateChapter.GenerateAlgorithm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace InterviewCrusher.Console
{
  public partial class GenerateAlgorithmPage : Page
  {
    public ObservableCollection<GenerateTestCaseDto> TestCases { get; set; }
    public ObservableCollection<GenerateAlgorithmExampleDto> Examples { get; set; }
    public ObservableCollection<GenerateAlgorithmRestrictionsDto> Restrictions { get; set; }

    public GenerateAlgorithmPage()
    {
      InitializeComponent();

      TestCases = new ObservableCollection<GenerateTestCaseDto>();
      Examples = new ObservableCollection<GenerateAlgorithmExampleDto>();
      Restrictions = new ObservableCollection<GenerateAlgorithmRestrictionsDto>();

      AlgoTestcasesView.ItemsSource = TestCases;
      AlgoExamplesView.ItemsSource = Examples;
      AlgoRestrictionsView.ItemsSource = Restrictions;
    }

    private void AddTestCaseButton_Click(object sender, RoutedEventArgs e)
    {
      TestCases.Add(new GenerateTestCaseDto
      {
        InputData = TestCaseInputData.Text,
        ExpectedOutput = TestCaseOutput.Text,
        Tip = TestCaseTip.Text
      });

      TestCaseInputData.Clear();
      TestCaseOutput.Clear();
      TestCaseTip.Clear();
    }

    private void AddExampleButton_Click(object sender, RoutedEventArgs e)
    {
      Examples.Add(new GenerateAlgorithmExampleDto
      {
        Explanation = ExampleExplanation.Text,
        InputData = ExampleInputData.Text,
        ExpectedOutput = ExampleOutput.Text
      });

      ExampleExplanation.Clear();
      ExampleInputData.Clear();
      ExampleOutput.Clear();
    }

    private void AddRestrictionButton_Click(object sender, RoutedEventArgs e)
    {
      Restrictions.Add(new GenerateAlgorithmRestrictionsDto
      {
        RestrictionName = RestrictionName.Text,
        RestrictionDescription = RestrictionDescription.Text
      });

      RestrictionName.Clear();
      RestrictionDescription.Clear();
    }

    private void AddAlgoButton_Click(object sender, RoutedEventArgs e)
    {
      TemplateDataStorage templateDataStorage = TemplateDataStorage.Instance;
      templateDataStorage.AddGeneratedAlgorithmDto(new GeneratedAlgorithmDto
      {
        AlgorithmRestrictions = new List<GenerateAlgorithmRestrictionsDto>(Restrictions),
        Examples = new List<GenerateAlgorithmExampleDto>(Examples),
        AlgorithmSolution = AlgoSolutionB64.Text,
        TestCases = new List<GenerateTestCaseDto>(TestCases),
        AllLanguagesAvailable = AlLanguagesAreAvailable.IsChecked ?? false,
        Description = AlgoDescriptionTextBox.Text,
        Difficulty = DifficultyComboBox.Text,
        Hint = AlgoHint.Text,
        Name = AlgoNameTextBox.Text

      });
      MessageBox.Show("Algorithm added successfully!");
    }
  }

}
