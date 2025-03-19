using InterviewCrusherAdmin.CommonDomain.TemplateDto.TemplateWithChapterNames;
using InterviewCrusher.Console.Controller.Generic;
using System.ComponentModel; // For INotifyPropertyChanged
using System.Threading;
using InterviewCrusherAdmin.BusinessLogic.Template.GetTemplateChapters;
using InterviewCrusherAdmin.Controllers;
using System.Windows.Controls;
using System.Windows;
using InterviewCrusherAdmin.CommonDomain.Responses;

namespace InterviewCrusher.Console.EditGeneratedTemplate
{
  public partial class EditGeneratedTemplateChapterSide : Page, INotifyPropertyChanged
  {
    private TemplateWithChapterNamesDto _template;

    public TemplateWithChapterNamesDto Template
    {
      get => _template;
      set
      {
        _template = value;
        OnPropertyChanged(nameof(Template));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public EditGeneratedTemplateChapterSide(string templateId)
    {
      InitializeComponent();

      // Initialize Template
      Template = new TemplateWithChapterNamesDto
      {
        Title = "DaTitle",
        Description = "DaDescription",
        Id = "DaId"
      };

      // Set DataContext
      DataContext = this;

      // Load data
      LoadTemplate(templateId);
    }

    private async void LoadTemplate(string templateId)
    {
      var templateWithChapters = await new GenericCall().GetAllGeneric<GetTemplateChaptersResponse>(
          UrlConstants.TemplateController.GET_TEMPLATE_WITH_CHAPTER_NAMES_FULL_URL(templateId),
          new CancellationToken()
      );

      if (templateWithChapters?.Data != null)
      {
        TitleTextBox.Text = templateWithChapters.Data.Title;
        DescriptionTextBox.Text = templateWithChapters.Data.Description;
        ChapterDropdown.ItemsSource = templateWithChapters.Data.ChapterNamesDto;

        // Update Template properties
        //Template.Title = templateWithChapters.Data.Title;
        //Template.Description = templateWithChapters.Data.Description;
        //Template.ChapterNamesDto = new List<ChapterNamesDto>(templateWithChapters.Data.ChapterNamesDto);
      }
      else
      {
        MessageBox.Show("No data returned from the server.");
      }
    }
  }
}
