namespace WindowsCanExecute.ViewModels.Interfaces;

using System.ComponentModel;

public interface IBaseViewModel : INotifyPropertyChanged
{
    bool IsBusy { get; set; }
    string Title { get; set; }
}
