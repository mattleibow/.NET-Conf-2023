
namespace WhatsNewMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var window = new MainWindow();

        var display = DeviceDisplay.MainDisplayInfo;

		window.X = (display.Width / display.Density - window.Width) / 2.0;
        window.Y = (display.Height / display.Density - window.Height) / 2.0;

		return window;
    }
}
