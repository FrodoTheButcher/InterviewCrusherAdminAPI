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
    public ObservableCollection<GenerateTestCase> TestCases { get; set; }
    public ObservableCollection<GenerateAlgorithmExample> Examples { get; set; }
    public ObservableCollection<GenerateAlgorithmRestrictions> Restrictions { get; set; }

    public GenerateAlgorithmPage()
    {
      InitializeComponent();

      TestCases = new ObservableCollection<GenerateTestCase>();
      Examples = new ObservableCollection<GenerateAlgorithmExample>();
      Restrictions = new ObservableCollection<GenerateAlgorithmRestrictions>();

      AlgoTestcasesView.ItemsSource = TestCases;
      AlgoExamplesView.ItemsSource = Examples;
      AlgoRestrictionsView.ItemsSource = Restrictions;
    }

    private void AddTestCaseButton_Click(object sender, RoutedEventArgs e)
    {
      TestCases.Add(new GenerateTestCase
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
      Examples.Add(new GenerateAlgorithmExample
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
      Restrictions.Add(new GenerateAlgorithmRestrictions
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
        AlgorithmRestrictions = new System.Collections.Generic.List<GenerateAlgorithmRestrictions>(Restrictions),
        Examples = new System.Collections.Generic.List<GenerateAlgorithmExample>(Examples),
        AlgorithmSolution = new GenerateAlgorithmSolution { SolutionB64 = AlgoSolutionB64.Text },
        TestCases = new System.Collections.Generic.List<GenerateTestCase>(TestCases),
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
