using System;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MultiViewChange.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableObject _mainWindowInnerView = new PlaceholderViewModel();
    
    private bool _isPaneOpen = false;

    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set
        {
            SetProperty(ref _isPaneOpen, value);
            if (value == true)
            {
                ABtnContent = "Apple";
                BBtnContent = "Banana";
            }
            else
            {
                ABtnContent = "A";
                BBtnContent = "B";
            }
        }
    }
    
    [ObservableProperty] private string _aBtnContent = "A";
    [ObservableProperty] private string _bBtnContent = "B";
    
    public MainWindowViewModel(){}

    [RelayCommand]
    private void SplitViewMouseEnter()
    {
        IsPaneOpen = true;
    }
    
    [RelayCommand]
    private void SplitViewMouseLeave()
    {
        IsPaneOpen = false;
    }

    public void ShowAppleView()
    {
        if(MainWindowInnerView is not AppleViewModel)
            MainWindowInnerView = new AppleViewModel();
    }

    public void ShowBananaView()
    {
        if(MainWindowInnerView is not BananaViewModel)
            MainWindowInnerView = new BananaViewModel();
    }
}