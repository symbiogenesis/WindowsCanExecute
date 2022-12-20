namespace WindowsCanExecute.ViewModels;

using WindowsCanExecute.ViewModels.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

public abstract partial class BaseViewModel : ObservableObject, IBaseViewModel
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title = string.Empty;
}
