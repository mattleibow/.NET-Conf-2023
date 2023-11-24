namespace BlazorAllTheThings.Services;

public class StarService
{
    public int NumberOfStars { get; private set; }

    public void AddStar()
    {
        NumberOfStars++;
    }
}
