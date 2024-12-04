namespace MauiPickerItemDisplayBindingBug;

public class MainPageViewModel : ViewModel
{
    int x = 4;
    public int DesiredValuePower
    {
        get => x;
        set => x = value;
    }

    public MainPageViewModel()
    {
        
    }
}
