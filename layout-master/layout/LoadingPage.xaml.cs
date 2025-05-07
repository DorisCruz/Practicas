namespace layout;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        InitializeComponent();
        CheckAuthStatus();
    }

    private async void CheckAuthStatus()
    {
        await Task.Delay(2000);
        var hasAuth = await SecureStorage.GetAsync("hasAuth");
        await Shell.Current.GoToAsync(hasAuth == "true" ? "//home" : "//login"); // Correcto
    }
}