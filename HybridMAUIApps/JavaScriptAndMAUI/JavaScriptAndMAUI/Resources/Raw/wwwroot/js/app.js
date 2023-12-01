
function UpdateDotNetCurrentPage(page) {
    // Notify .NET code which page we're on
    var event = {
        "event": "navigation",
        "value": page
    };
    HybridWebView.SendRawMessageToDotNet(JSON.stringify(event));
}
