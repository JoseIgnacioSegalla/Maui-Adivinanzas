using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using P1.DTOs;

namespace P1.ViewModels;

public partial class TotalViewModel : ObservableObject
{

    [ObservableProperty]
    private int totalScore = 0;

    [RelayCommand]
    public async Task BtnChangeAsync()
    {
        await Shell.Current.GoToAsync("//MoviePage");
    }


}