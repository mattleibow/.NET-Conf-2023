namespace WhatsNewMAUI;

public partial class SecondWindow : Window
{
    public SecondWindow()
    {
        InitializeComponent();
    }

    // Drag

    private void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        e.Data.Image = heroGraphic.Source;
    }
}
