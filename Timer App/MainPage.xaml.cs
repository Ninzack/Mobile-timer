using Microsoft.Maui.ApplicationModel;
using System.Windows.Input;

namespace Timer_App
{
    public partial class MainPage : ContentPage
    {
        private DateTime endTime;
        private bool isCounting;
        private Timer timer;
        public ICommand ToggleThemeCommand { get; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            timer = new Timer(TimerTick, null, Timeout.Infinite, 1000);
            //ToggleThemeCommand = new Command(ToggleTheme);

        }

        public DateTime EndDate => datePicker.Date;
        public TimeSpan EndTime => timePicker.Time;

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            endTime = EndDate.Add(EndTime);
            StartTimer();
        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            StopTimer();
        }

        private void StartTimer()
        {
            if (!isCounting)
            {
                isCounting = true;
                timer.Change(0, 1000); // Start the timer with a due time of 0 (immediately) and a period of 1000 milliseconds (1 second)
            }
        }

        private void StopTimer()
        {
            if (isCounting)
            {
                isCounting = false;
                timer.Change(Timeout.Infinite, Timeout.Infinite); // Stop the timer
            }
        }

        private void TimerTick(object state)
        {
            DateTime currentTime = DateTime.Now;

            if (endTime > currentTime)
            {
                TimeSpan timeLeft = endTime - currentTime;

                CountdownDays = $"{Math.Floor(timeLeft.TotalDays)} days";
                CountdownHours = $"{timeLeft.Hours} hours";
                CountdownMinutes = $"{timeLeft.Minutes} minutes";
                CountdownSeconds = $"{timeLeft.Seconds} seconds";
            }
            else
            {
                CountdownDays = "0 days";
                CountdownHours = "0 hours";
                CountdownMinutes = "0 minutes";
                CountdownSeconds = "0 seconds";
                StopTimer();
            }
        }

        //private void ToggleTheme()
        //{
        //    // Get the current theme
        //    var currentTheme = App.Current.RequestedTheme;

        //    // Toggle between light and dark mode
        //    App.Current.UserAppTheme = (currentTheme == AppTheme.Light) ? AppTheme.Dark : AppTheme.Light;

        //    // You may also need to update your UI based on the selected theme
        //    UpdateTheme();
        //}

        //private void UpdateTheme()
        //{
        //    // Perform any UI updates based on the selected theme
        //    // For example, you can switch the background color, text color, etc.
        //    if (App.Current.UserAppTheme == AppTheme.Light)
        //    {
        //        // Set light theme styles
        //        this.BackgroundColor = Color.FromHex("#FFFFFF"); // White
        //                                                         // Add any other light theme styles as needed
        //    }
        //    else
        //    {
        //        // Set dark theme styles
        //        this.BackgroundColor = Color.FromHex("#000000"); // Black
        //                                                         // Add any other dark theme styles as needed
        //    }
        //}




        #region Bindable Properties

        public string CountdownDays
        {
            get => (string)GetValue(CountdownDaysProperty);
            set => SetValue(CountdownDaysProperty, value);
        }

        public static readonly BindableProperty CountdownDaysProperty =
            BindableProperty.Create(nameof(CountdownDays), typeof(string), typeof(MainPage), string.Empty);

        public string CountdownHours
        {
            get => (string)GetValue(CountdownHoursProperty);
            set => SetValue(CountdownHoursProperty, value);
        }

        public static readonly BindableProperty CountdownHoursProperty =
            BindableProperty.Create(nameof(CountdownHours), typeof(string), typeof(MainPage), string.Empty);

        public string CountdownMinutes
        {
            get => (string)GetValue(CountdownMinutesProperty);
            set => SetValue(CountdownMinutesProperty, value);
        }

        public static readonly BindableProperty CountdownMinutesProperty =
            BindableProperty.Create(nameof(CountdownMinutes), typeof(string), typeof(MainPage), string.Empty);

        public string CountdownSeconds
        {
            get => (string)GetValue(CountdownSecondsProperty);
            set => SetValue(CountdownSecondsProperty, value);
        }

        public static readonly BindableProperty CountdownSecondsProperty =
            BindableProperty.Create(nameof(CountdownSeconds), typeof(string), typeof(MainPage), string.Empty);

        #endregion
    }
}