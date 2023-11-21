namespace WhatsNewMAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    // Accelerators

    private async void OnAboutClicked(object sender, EventArgs e)
    {
        await DisplayAlert("About", "What's New with .NET MAUI?", "THIS!");
    }

    // Windows

    private void OnNewClicked(object sender, EventArgs e)
    {
        Application.Current!.OpenWindow(new SecondWindow());
    }

    // Drop

    private void OnDragOver(object sender, DragEventArgs e) => 
        e.AcceptedOperation = DataPackageOperation.Copy;

    private void OnDragLeave(object sender, DragEventArgs e) =>
        e.AcceptedOperation = DataPackageOperation.None;

    private async void OnDrop(object sender, DropEventArgs e)
    {
        var img = await e.Data.GetImageAsync();
        bot.Source = img;
    }

    // Pointers

    bool inside;
    bool down;
    Point? loc;

    private void OnEntered(object sender, PointerEventArgs e)
    {
        inside = true;
        loc = e.GetPosition(bot);
        UpdateLabel();
    }

    private void OnExited(object sender, PointerEventArgs e)
    {
        inside = false;
        UpdateLabel();
    }

    private void OnMoved(object sender, PointerEventArgs e)
    {
        loc = e.GetPosition(bot);
        UpdateLabel();
    }

    private void OnPressed(object sender, PointerEventArgs e)
    {
        down = true;
        UpdateLabel();
    }

    private void OnReleased(object sender, PointerEventArgs e)
    {
        down = false;
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        pointerLabel.Text = $"Inside: {inside}, Pressed: {down}, Location: {loc?.X:0.0},{loc?.Y:0.0}";
    }
}
