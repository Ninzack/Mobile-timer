namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private bool isTimerRunning = false;
    private DateTime targetDateTime; // Declare targetDateTime at the class level

    public MainPage()
    {
        InitializeComponent();
    }

    //alleen aan passen tussen dit
    [Obsolete]
    private void ButtonClickHandler(object sender, EventArgs e)
    {
        if (!isTimerRunning)
        {
            // Set the target date and time for the countdown (e.g., 1 day from now)
            targetDateTime = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0));

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                // Calculate the time remaining
                TimeSpan timeRemaining = targetDateTime - DateTime.Now;

                // Check if the countdown has reached zero
                if (timeRemaining.TotalSeconds <= 0)
                {
                    resultLabel.Text = "Countdown expired!";
                    isTimerRunning = false;
                    return false; // Stop the timer
                }

                // Update the label with the countdown
                resultLabel.Text = $"{(int)timeRemaining.TotalDays}d {(int)timeRemaining.Hours}h {(int)timeRemaining.Minutes}m {timeRemaining.Seconds}s";

                // Return true to continue the timer
                return isTimerRunning;
            });

            isTimerRunning = true;
        }
    }
    //en dit
}