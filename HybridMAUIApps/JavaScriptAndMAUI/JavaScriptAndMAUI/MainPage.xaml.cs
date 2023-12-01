using HybridWebView;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JavaScriptAndMAUI
{
    public partial class MainPage : ContentPage
    {
        private string messageText = "Hello from .NET MAUI";
        private string pageName = "<none>";

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

#if DEBUG
            myHybridWebView.EnableWebDevTools = true;
#endif

            myHybridWebView.JSInvokeTarget = new MyJSInvokeTarget(this);
        }

        public string CurrentPageName
        {
            get => pageName;
            set
            {
                pageName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SupportsMessages));
            }
        }

        public bool SupportsMessages =>
            CurrentPageName == "messages";

        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                OnPropertyChanged();
            }
        }

        private async void OnSendRawMessage(object sender, EventArgs e)
        {
            var result = await myHybridWebView.EvaluateJavaScriptAsync($"ProcessTextInJavaScript('{MessageText}')");

            await DisplayAlert("HybridWebView", $"We sent '{MessageText}' to JavaScript and it returned '{result}'.", "OK");
        }

        private async void OnSendInvokeMessage(object sender, EventArgs e)
        {
            var result = await myHybridWebView.InvokeJsMethodAsync<bool>("ProcessTextInJavaScript", MessageText);
            await DisplayAlert("HybridWebView", $"We sent '{MessageText}' to JavaScript and it returned '{result}'.", "OK");
        }

        private void OnHybridWebViewRawMessageReceived(object sender, HybridWebViewRawMessageReceivedEventArgs e)
        {
            if (e.Message is null)
                return;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var message = JsonSerializer.Deserialize<Message>(e.Message, options);
            if (message is null)
                return;

            switch (message.Event)
            {
                case "navigation": OnNavigationMessage(message); break;
                case "rawMessage": OnRawMessage(message); break;
                default: throw new InvalidOperationException("Unknown message event.");
            }

            void OnNavigationMessage(Message message)
            {
                CurrentPageName = message.Value ?? "<none>";
            }

            async void OnRawMessage(Message message)
            {
                await DisplayAlert(
                    "HybridWebView",
                    $"We received a raw message from JavaScript: '{message.Value}'.",
                    "OK");
            }
        }

        private sealed class MyJSInvokeTarget(Page Page)
        {
            public async void ProcessTextInDotNet(string message, int number)
            {
                await Page.DisplayAlert(
                    "HybridWebView",
                    $"We received a invoke message from JavaScript: '{message}'. There was also a number: {number}",
                    "OK");
            }
        }

        public class Message
        {
            public string? Event { get; set; }

            public string? Value { get; set; }
        }
    }
}
