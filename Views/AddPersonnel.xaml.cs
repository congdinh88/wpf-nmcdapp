using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace NMCDApp.Views
{
    /// <summary>
    /// Interaction logic for AddPersonnel.xaml
    /// </summary>
    public partial class AddPersonnel : Window
    {
        private ObservableCollection<DataRow> rowDataList;
        public AddPersonnel()
        {
            InitializeComponent();
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            rowDataList = new ObservableCollection<DataRow>();
            rowDataList.Add(new DataRow());
            PersonnelGrid.ItemsSource = rowDataList;
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedRow = (DataRow)e.Row.Item;
            var editedElement = e.EditingElement as System.Windows.Controls.TextBox;
            if (editedElement != null)
            {
                var columnBindingPath = ((DataGridTextColumn)e.Column).Binding.Path.Path;
                switch (columnBindingPath)
                {
                    case "Column1":
                        editedRow.Column1 = editedElement.Text;
                        break;
                    case "Column2":
                        editedRow.Column2 = editedElement.Text;
                        break;
                    case "Column3":
                        editedRow.Column3 = editedElement.Text;
                        break;
                    case "Column4":
                        editedRow.Column4 = editedElement.Text;
                        break;
                }
            }
        }
        private bool IsRowEmpty(DataRow row)
        {
            return string.IsNullOrWhiteSpace(row.Column1) ||
                   string.IsNullOrWhiteSpace(row.Column2) ||
                   string.IsNullOrWhiteSpace(row.Column3) ||
                   string.IsNullOrWhiteSpace(row.Column4);
        }

        private void PersonnelGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu hàng cuối cùng không trống, thêm hàng mới
            var lastRow = rowDataList[rowDataList.Count - 1];
            if (!IsRowEmpty(lastRow))
            {
                rowDataList.Add(new DataRow());
            }
        }
    }
    public class DataRow
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }
        public string Column9 { get; set; }
    }
}

    
