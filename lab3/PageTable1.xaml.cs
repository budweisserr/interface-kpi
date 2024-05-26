using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using lab3.Commands;

namespace lab3
{
    public partial class PageTable1 : Page
    {
        private bool isDirty;

        public PageTable1()
        {
            InitializeComponent();
            isDirty = false;

            CommandBindings.Add(new CommandBinding(DataCommands.Undo, ExecuteCommand, CanExecuteCommand));
            CommandBindings.Add(new CommandBinding(DataCommands.New, ExecuteCommand, CanExecuteCommand));
            CommandBindings.Add(new CommandBinding(DataCommands.Replace, ExecuteCommand, CanExecuteCommand));
            CommandBindings.Add(new CommandBinding(DataCommands.Save, ExecuteCommand, CanExecuteCommand));
            CommandBindings.Add(new CommandBinding(DataCommands.Find, ExecuteCommand, CanExecuteCommand));
            CommandBindings.Add(new CommandBinding(DataCommands.Delete, ExecuteCommand, CanExecuteCommand));
        }

        private void CanExecuteCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == DataCommands.Undo || e.Command == DataCommands.Save || e.Command == DataCommands.Replace || e.Command==DataCommands.Delete)
            {
                e.CanExecute = isDirty;
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void ExecuteCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataCommands.Undo)
            {
                MessageBox.Show("Undo command executed");
                isDirty = false;
            }
            else if (e.Command == DataCommands.New)
            {
                MessageBox.Show("New command executed");
                isDirty = true;
            }
            else if (e.Command == DataCommands.Replace)
            {
                MessageBox.Show("Replace command executed");
                isDirty = true;
            }
            else if (e.Command == DataCommands.Save)
            {
                MessageBox.Show("Save command executed");
                isDirty = false;
            }
            else if (e.Command == DataCommands.Find)
            {
                MessageBox.Show("Find command executed");
            }
            else if (e.Command == DataCommands.Delete)
            {
                MessageBox.Show("Delete command executed");
                isDirty = false;
            }

            CommandManager.InvalidateRequerySuggested();
        }
    }
}
