namespace WindowsCanExecute.ViewModels;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        this.Title = "CanExecute Bug Example";

        this.CloseCommand = new AsyncRelayCommand(this.OnClose);
        this.AddRecordCommand = new AsyncRelayCommand<string>(this.OnAddRecord, _ => !this.IsBusy);
        this.ClearRecordsCommand = new AsyncRelayCommand(this.OnClearRecords, () => !this.IsBusy && this.Records.Count > 0);
        this.AcceptRecordsCommand = new AsyncRelayCommand(this.OnAcceptRecords, () => !this.IsBusy && this.Records.Count > 0);
    }

    public ICommand CloseCommand { get; }
    public ICommand AddRecordCommand { get; }
    public IAsyncRelayCommand ClearRecordsCommand { get; }
    public IAsyncRelayCommand AcceptRecordsCommand { get; }

    [ObservableProperty]
    private string recordText = string.Empty;

    public ObservableCollection<string> Records { get; } = new();

    private async Task OnAcceptRecords()
    {
        this.IsBusy = true;

        try
        {
            await Shell.Current.DisplayAlert("Accepted", "Records Accepted", "Close");
        }
        catch { throw; }
        finally
        {
            this.IsBusy = false;
        }
    }

    private async Task OnClose() => Process.GetCurrentProcess().Kill();

    private async Task OnAddRecord(string? record)
    {
        if (record is null)
        {
            throw new ArgumentNullException(nameof(record));
        }

        this.IsBusy = true;

        try
        {
            this.Records.Add(record);
            this.recordText = string.Empty;
        }
        catch { throw; }
        finally
        {
            this.IsBusy = false;
            this.AcceptRecordsCommand.NotifyCanExecuteChanged();
            this.ClearRecordsCommand.NotifyCanExecuteChanged();
        }
    }

    private async Task OnClearRecords()
    {
        this.IsBusy = true;

        try
        {
            this.Records.Clear();
            this.recordText = string.Empty;
        }
        catch { throw; }
        finally
        {
            this.IsBusy = false;
            this.AcceptRecordsCommand.NotifyCanExecuteChanged();
            this.ClearRecordsCommand.NotifyCanExecuteChanged();
        }
    }
}
