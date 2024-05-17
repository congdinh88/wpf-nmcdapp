using NMCDApp.Pages;
using NMCDApp.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NMCDApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListPersonnel.ItemsSource = ShowBtnPer();
        }
		
		private void Expander_Expanded(object sender, RoutedEventArgs e)
		{
			Expander expandedExpander = sender as Expander;

			foreach (Expander expander in LeftMenu.Children)
			{
				if (expander != expandedExpander && expander.IsExpanded)
				{
					expander.IsExpanded = false;
				}
			}
			LeftMenu.Children.Remove(expandedExpander);
			LeftMenu.Children.Insert(0, expandedExpander);
		}
        private string [] ShowBtnPer()
        {
            string[] strArray =
            {
                "CBCNV",
                "Nghỉ phép",
                "Lịch trực",
            };
				return strArray;
		}
		private void ListPersonnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string s = ListPersonnel.SelectedItem.ToString();
			switch (s)
			{
				case "CBCNV":
					MainContent.Navigate(new Personnel());
                    break;
				case "Nghỉ phép":
					MainContent.Navigate(new Absence());
					break;
				case "Lịch trực":
					MainContent.Navigate(new WorkShedule());
					break;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (MainContent.Content is WorkShedule workShedule)
			{
				workShedule.SearchBar.Visibility = Visibility.Visible;
			}
            if (MainContent.Content is Personnel personnel)
            {
                personnel.SearchBar.Visibility = Visibility.Visible;
            }

        }


		//Event button add new
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddPersonnel addPersonnel = new AddPersonnel();
            //switch (tempAdd)
            //{
            //    case "CBCNV":
            //        addPersonnel.Show();
            //        break;
            //    case "Nghỉ phép":
            //        break;
            //    case "Lịch trực":
            //        break;
            //}
            if (MainContent.Content is Personnel personnel)
            {
                addPersonnel.Show();
            }
        }
    }
}