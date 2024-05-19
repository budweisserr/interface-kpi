using lab3;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace lab3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private int _timeInMinutes;
        private int _timeRemaining;
        private string _minutesInput;
        private string _timeDisplay;

        public MainViewModel()
        {
            StartCommand = new RelayCommand(StartTimer, CanStartTimer);
            StopCommand = new RelayCommand(StopTimer, CanStopTimer);
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
        }

        public string MinutesInput
        {
            get => _minutesInput;
            set
            {
                if (_minutesInput != value)
                {
                    _minutesInput = value;
                    OnPropertyChanged(nameof(MinutesInput));
                    ((RelayCommand)StartCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string TimeDisplay
        {
            get => _timeDisplay;
            set
            {
                _timeDisplay = value;
                OnPropertyChanged(nameof(TimeDisplay));
            }
        }

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        private bool CanStartTimer(object parameter)
        {
            return int.TryParse(MinutesInput, out _timeInMinutes) && _timeInMinutes > 0;
        }

        private void StartTimer(object parameter)
        {
            _timeRemaining = _timeInMinutes * 60; // Convert minutes to seconds
            _timer.Start();
            UpdateTimeDisplay();
            MessageBox.Show($"Таймер поставлено на {_timeInMinutes} хвилин(и).");
        }

        private bool CanStopTimer(object parameter)
        {
            return _timer.IsEnabled;
        }

        private void StopTimer(object parameter)
        {
            _timer.Stop();
            MessageBox.Show("Таймер зупинено.");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining--;
                UpdateTimeDisplay();
            }
            else
            {
                _timer.Stop();
                MessageBox.Show("Час вичерпано!");
            }
        }

        private void UpdateTimeDisplay()
        {
            TimeDisplay = $"{_timeRemaining / 60:D2}:{_timeRemaining % 60:D2}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
