namespace TestingApp;

public partial class MainPage : ContentPage
{
    private const double InitialHeaderHeight = 50;
    private const double HeaderShrinkAmount = 10;
    public List<string> Items { get; set; } = [];

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;

        for (var  i = 0; i < 100; i++)
        {
            Items.Add("Item " + i);
        }

        Items = [.. Items];
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        // Get the vertical scroll position
        var offset = e.VerticalOffset;

        // Calculate the header height based on the scroll position
        var newHeight = Math.Max(InitialHeaderHeight - offset, InitialHeaderHeight - HeaderShrinkAmount);
        Header.HeightRequest = newHeight;

        // Calculate the background color opacity based on the scroll position
        var opacity = Math.Min(offset / InitialHeaderHeight, 1.0); // Caps the opacity at 1.0 
        Header.BackgroundColor = Colors.Green.WithAlpha((float)opacity); // Pick the color
    }
}
