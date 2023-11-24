namespace BlazorAllTheThings.Services;

public interface IAdditionalMenuItems
{
    IEnumerable<(string Url, string Title)> GetMenuItems();
}

public class NoAdditionalMenuItems : IAdditionalMenuItems
{
    public IEnumerable<(string Url, string Title)> GetMenuItems() =>
        Enumerable.Empty<(string Url, string Title)>();
}
