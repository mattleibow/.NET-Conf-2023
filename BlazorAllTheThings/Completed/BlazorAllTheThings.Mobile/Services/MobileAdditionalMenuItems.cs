using BlazorAllTheThings.Services;

namespace BlazorAllTheThings.Mobile.Services;

public class MobileAdditionalMenuItems : IAdditionalMenuItems
{
    public IEnumerable<(string Url, string Title)> GetMenuItems()
    {
        yield return ("/mobile", "Mobile");
    }
}
