namespace BlazorAllTheThings.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState) =>
        new Window(new AppShell())
        {
            Width = 1200,
            Height = 650
        };
}
