namespace BlazorAllTheThings.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await DisplayAlert("About", "Blazor All The Things!", "OK");
    }
}
