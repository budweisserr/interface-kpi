using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab3
{
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void ViewRecords_Click(object sender, RoutedEventArgs e)
        {
            TimerGrid.Visibility = Visibility.Collapsed;
            RecordsGrid.Visibility = Visibility.Visible;
            LoadRecords();
        }

        private void BackToTimer_Click(object sender, RoutedEventArgs e)
        {
            RecordsGrid.Visibility = Visibility.Collapsed;
            TimerGrid.Visibility = Visibility.Visible;
        }

        private void LoadRecords()
        {
            using (var context = new DBLab6Entities())
            {
                RecordsDataGrid.ItemsSource = context.TimerRecords.ToList();
            }
        }

        private void RecordsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RecordsDataGrid.SelectedItem is TimerRecords selectedRecord)
            {
                if (selectedRecord.RemainingTime > 0)
                {
                    ((MainViewModel)this.DataContext).LoadTimerRecord(selectedRecord);
                    BackToTimer_Click(this, null);
                }
                else
                {
                    MessageBox.Show("Вибір цього запису неможливий.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
