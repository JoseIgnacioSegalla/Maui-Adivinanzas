using CommunityToolkit.Mvvm.ComponentModel;

namespace P1.DTOs;

public partial class MovieDTO : ObservableObject
{

    [ObservableProperty]
    public int id;
    [ObservableProperty]
    public string? name;
    [ObservableProperty]
    public string? urlImage;
    [ObservableProperty]
     public IList<string>? alternativeNames;

}