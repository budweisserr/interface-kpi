using System.Windows.Input;

namespace lab3.Commands
{
    public static class DataCommands
    {
        public static RoutedCommand Undo { get; } = new RoutedCommand("Undo", typeof(DataCommands));
        public static RoutedCommand New { get; } = new RoutedCommand("New", typeof(DataCommands));
        public static RoutedCommand Replace { get; } = new RoutedCommand("Replace", typeof(DataCommands));
        public static RoutedCommand Save { get; } = new RoutedCommand("Save", typeof(DataCommands));
        public static RoutedCommand Find { get; } = new RoutedCommand("Find", typeof(DataCommands));
        public static RoutedCommand Delete { get; } = new RoutedCommand("Delete", typeof(DataCommands));

        static DataCommands()
        {
            Undo.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));
            New.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            Replace.InputGestures.Add(new KeyGesture(Key.H, ModifierKeys.Control));
            Save.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
            Find.InputGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));
            Delete.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control));
        }
    }
}
