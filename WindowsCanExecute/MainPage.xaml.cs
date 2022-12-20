namespace WindowsCanExecute;

using WindowsCanExecute.ViewModels;

public partial class MainPage
{
    public MainPage()
    {
        this.InitializeComponent();

        this.BindingContext = new MainViewModel();
    }
}
