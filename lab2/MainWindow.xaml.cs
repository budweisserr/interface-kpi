using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var saveCommand = new CommandBinding(ApplicationCommands.Save, Executed_Save, CanExecute_Save);
            var openCommand = new CommandBinding(ApplicationCommands.Open, Executed_Open, CanExecute_Open);
            var eraseCommand = new CommandBinding(ApplicationCommands.New, Executed_Erase, CanExecute_Erase);
            CommandBindings.Add(saveCommand);
            CommandBindings.Add(openCommand);
            CommandBindings.Add(eraseCommand);
        }

        private void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = InputTextBox.Text.Trim().Length > 0;
        }

        private void Executed_Save(object sender, ExecutedRoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, InputTextBox.Text);
            }
        }

        private void CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Executed_Open(object sender, ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                InputTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }
        private void CanExecute_Erase(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = InputTextBox.Text.Trim().Length > 0;
        }

        private void Executed_Erase(object sender, ExecutedRoutedEventArgs e)
        {
            InputTextBox.Text = "";
        }
    }
}

