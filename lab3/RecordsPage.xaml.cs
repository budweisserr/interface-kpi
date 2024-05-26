using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace lab3
{
    public partial class RecordsPage : Page
    {
        private List<TimerRecords> _allRecords;

        public RecordsPage()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void LoadRecords()
        {
            using (var context = new DBLab6Entities())
            {
                _allRecords = context.TimerRecords.ToList();
                RecordsDataGrid.ItemsSource = _allRecords;
            }
        }

        private void RecordsDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem is TimerRecords selectedRecord)
            {
                if (selectedRecord.RemainingTime > 0)
                {
                    ((MainViewModel)Application.Current.MainWindow.DataContext).LoadTimerRecord(selectedRecord);
                    
                }
                else
                {
                    MessageBox.Show("The selected record has expired.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
