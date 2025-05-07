namespace layout;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await Task.Delay(2000); // Simula carga inicial
            var hasAuth = await SecureStorage.GetAsync("hasAuth");
            Console.WriteLine($"Debug - hasAuth: {hasAuth}"); // Log para debug

            var targetRoute = (hasAuth != null && hasAuth == "true") ? "//home" : "//login";
            await Shell.Current.GoToAsync(targetRoute);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            await Shell.Current.GoToAsync("//login"); // Fallback
        }
    }
}