using MaterialDesignThemes.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace NMCDApp.Pages
{
    /// <summary>
    /// Interaction logic for Personnel.xaml
    /// </summary>
    public class PersonnelList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobPosition { get; set; }
        public string Workshop { get; set; }
        public string Tell { get; set; }
        public string Add { get; set; }
        public string TellOfDear { get; set; }
        public DateTime Date1 { get; set; }
    }

    public class SuggesList
    {
        public string Key { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
    public class AutoComplete
    {
        public ObservableCollection<string> AutoSuggestBoxSuggestions { get; set; }
        public string AutoSuggestBoxText { get; set; }
        public void AutoSuggestBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            AutoSuggestBoxText = autoSuggestBox.Text.ToLower();

            var filteredSuggestions = new ObservableCollection<string>();
            foreach (var suggestion in AutoSuggestBoxSuggestions)
            {
                var suggToLower = suggestion.ToLower();
                if (suggToLower.Contains(AutoSuggestBoxText))
                {
                    filteredSuggestions.Add(suggestion);
                }
            }
            autoSuggestBox.Suggestions = filteredSuggestions;
        }
    }

    public class AutoCompleteKey2Value
    {
        public ObservableCollection<SuggesList> AutoSuggestBoxSuggestions { get; set; }
        public string AutoSuggestBoxText { get; set; }
        public void AutoSuggestBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            AutoSuggestBoxText = autoSuggestBox.Text.ToLower();
            var filteredSuggestions = new ObservableCollection<SuggesList>();
            foreach (var suggestion in AutoSuggestBoxSuggestions)
            {
                var suggToLower = suggestion.Key.ToLower();
                if (suggToLower.Contains(AutoSuggestBoxText))
                {
                    filteredSuggestions.Add(suggestion);
                }
            }
            autoSuggestBox.Suggestions = filteredSuggestions;
        }
    }

    public partial class Personnel : Page, INotifyPropertyChanged
    {
        ObservableCollection<PersonnelList> people = new ObservableCollection<PersonnelList>
        {
            new PersonnelList { Id = "HP01234", Name = "John Doe",DateOfBirth= new DateTime(1988,01,12),JobPosition="BGĐ", Workshop = "VP", Tell="012345",Add="Hải Phòng", TellOfDear="12304", Date1=new DateTime(2020, 05, 12) },
            new PersonnelList { Id = "HP01235", Name = "Nguyễn Văn Anh",DateOfBirth=new DateTime(1985,05,12),JobPosition="KTV", Workshop = "Bảo trì cơ", Tell="012345",Add="Hải Phòng", TellOfDear="12304", Date1=new DateTime(2009, 01, 12) },
            new PersonnelList { Id = "HP11234", Name = "Sammy Doe",DateOfBirth=new DateTime(1982,02,12),JobPosition="CN", Workshop = "Đường ống", Tell="012345",Add="Hải Phòng", TellOfDear="12304", Date1=new DateTime(2014,03,12)},
            new PersonnelList { Id = "HP11244", Name = "Doe",DateOfBirth=new DateTime(1981,02,12),JobPosition="CN", Workshop = "Bảo trì cơ", Tell="012345",Add="Hải Phòng", TellOfDear="12304", Date1=new DateTime(2010,03,12)}
        };
        public Personnel()
        {
            InitializeComponent();
            DataContext = this;
            PersonnelGrid.ItemsSource = people;
            AutoCompleteId();
            AutoCompleteName();
            AutoCompleteWorshop();

        }
        // Auto complete Id box
        public void AutoCompleteId()
        {
            AutoCompleteKey2Value autoCompleteId = new AutoCompleteKey2Value();
            var suggesList = people.Select(p => new SuggesList { Key = p.Id, Value1 = p.Name, Value2 = p.Workshop }).ToList();
            autoCompleteId.AutoSuggestBoxSuggestions = new ObservableCollection<SuggesList>(suggesList);
            Id.TextChanged += autoCompleteId.AutoSuggestBox_TextChanged;
        }

        // Auto complete Name box
        public void AutoCompleteName()
        {
            AutoCompleteKey2Value autoCompleteId = new AutoCompleteKey2Value();
            var suggesList = people.Select(p => new SuggesList { Value1 = p.Id, Key = p.Name, Value2 = p.Workshop }).ToList();
            autoCompleteId.AutoSuggestBoxSuggestions = new ObservableCollection<SuggesList>(suggesList);
            Name.TextChanged += autoCompleteId.AutoSuggestBox_TextChanged;
        }

        // Auto complete Worshop box
        public void AutoCompleteWorshop()
        {
            AutoComplete autoCompleteWorshop = new AutoComplete();
            var suggesList = people.Select(p => p.Workshop).Distinct().ToList();
            autoCompleteWorshop.AutoSuggestBoxSuggestions = new ObservableCollection<string>(suggesList);
            Workshop.TextChanged += autoCompleteWorshop.AutoSuggestBox_TextChanged;
        }

        // Show/hide search bar personnel
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SearchBar.Visibility = Visibility.Collapsed;
        }

        // Button check quit job
        private void QuitJob_Checked(object sender, RoutedEventArgs e)
        {
            if (QuitJob.IsChecked == true)
            {
                Trainee.IsEnabled = false;
            }
            else
            {
                Trainee.IsEnabled = true;
            }
        }

        // Button check train
        private void Trainee_Checked(object sender, RoutedEventArgs e)
        {
            if (Trainee.IsChecked == true)
            {
                QuitJob.IsEnabled = false;
            }
            else
            {
                QuitJob.IsEnabled = true;
            }
        }


        // Process data button search
        ObservableCollection<PersonnelList> tempListDate = new ObservableCollection<PersonnelList>();
        ObservableCollection<PersonnelList> tempListWorksop = new ObservableCollection<PersonnelList>();
        ObservableCollection<PersonnelList> tempListName = new ObservableCollection<PersonnelList>();
        ObservableCollection<PersonnelList> tempListId = new ObservableCollection<PersonnelList>();
        public void ProcessBtnSearch()
        {
            string id = Id.Text.ToLower();
            string name = Name.Text.ToLower();
            string wokshop = Workshop.Text.ToLower();
            DateTime? fromDate = FromDate.SelectedDate;
            DateTime? toDate = ToDate.SelectedDate;
            if (fromDate == null && toDate == null)
            {
                tempListDate = new ObservableCollection<PersonnelList>(people);
            }
            else if (fromDate == null && toDate != null)
            {
                tempListDate = new ObservableCollection<PersonnelList>(people.Where(item => item.Date1 <= toDate));
            }
            else if (fromDate != null && toDate == null)
            {
                tempListDate = new ObservableCollection<PersonnelList>(people.Where(item => item.Date1 >= fromDate));
            }
            else
            {
                tempListDate = new ObservableCollection<PersonnelList>(people.Where(item => item.Date1 >= fromDate && item.Date1 <= toDate));
            }
            if(wokshop == "")
            {
                tempListWorksop= new ObservableCollection<PersonnelList>(tempListDate);
            }
            else 
            { 
                tempListWorksop = new ObservableCollection<PersonnelList>(tempListDate.Where(item=>item.Workshop.ToLower()==wokshop)); 
            }
            if (name == "")
            {
                tempListName = new ObservableCollection<PersonnelList>(tempListWorksop);
            }
            else
            {
                tempListName = new ObservableCollection<PersonnelList>(tempListWorksop.Where(item => item.Name.ToLower() == name));
            }
            if (id == "")
            {
                tempListId = new ObservableCollection<PersonnelList>(tempListName);
            }
            else
            {
                tempListId = new ObservableCollection<PersonnelList>(tempListWorksop.Where(item => item.Id.ToLower() == id));
            }
            PersonnelGrid.ItemsSource = tempListId;
        }

        // Event button search
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessBtnSearch();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Id_SuggestionChosen(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            AutoCompleteKey2Value autoCompleteId = new AutoCompleteKey2Value();
            var suggesList = people.Select(p => new SuggesList { Key = p.Id, Value1 = p.Name, Value2 = p.Workshop }).ToList();
            foreach (var item in suggesList)
            {
                if (Id.Text == item.Key)
                {
                    Name.Text = item.Value1;
                    Workshop.Text = item.Value2;
                }
            }
        }

        private void Name_SuggestionChosen(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            AutoCompleteKey2Value autoCompleteId = new AutoCompleteKey2Value();
            var suggesList = people.Select(p => new SuggesList { Key = p.Id, Value1 = p.Name, Value2 = p.Workshop }).ToList();
            foreach (var item in suggesList)
            {
                if (Name.Text == item.Value1)
                {
                    Id.Text = item.Key;
                    Workshop.Text = item.Value2;
                }
            }
        }


        //Relations beetwen from date and to date
        private DateTime? _startDate;
        private DateTime? _endDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                if (value != _startDate)
                {
                    _startDate = value;
                    OnPropertyChanged();
                    if (_startDate.HasValue && _endDate.HasValue && _startDate > _endDate)
                    {
                        EndDate = _startDate;
                    }
                }
            }
        }
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                if (value != _endDate)
                {
                    _endDate = value;
                    OnPropertyChanged();
                    if (_endDate.HasValue && _startDate.HasValue && _endDate < _startDate)
                    {
                        StartDate = _endDate;
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        // Event button cancel
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Id.Text = "";
            Name.Text = "";
            Workshop.Text = "";
            FromDate.SelectedDate = null;
            ToDate.SelectedDate= null;
            PersonnelGrid.ItemsSource = people;
        }
    }
}
