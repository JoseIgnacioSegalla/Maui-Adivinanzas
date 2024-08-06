using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using P1.DTOs;

namespace P1.ViewModels;

public partial class MovieViewModel : ObservableObject
{
    [ObservableProperty]
    private static int count = 0;

    [ObservableProperty]
    private string name = "Nombre";

    [ObservableProperty]
    private string alternativeName1 = "NombreAlternativo1";

    [ObservableProperty]
    private string alternativeName2 = "NombreAlternativo2";

    [ObservableProperty]
    private string urlImage = "adivinanza.jpeg";

    private static int index = 0;

    private int Max = 0;

    private readonly MovieDbContext _dbContext;

    private readonly List<Movie> movies;

    public MovieViewModel()
    { 
        
        var dbContext = new MovieDbContext();
        _dbContext = dbContext;

        movies = _dbContext.Movies.ToList();

        Max = movies.Count();

        Name = movies[index].Name;
        AlternativeName1 = movies[index].AlternativeName1;
        AlternativeName2 = movies[index].AlternativeName2;
        UrlImage = movies[index].UrlImage;

    }

    

    [RelayCommand]
    public async void BtnCount(string Correct)
    {
        if(Correct == "1"){
            Count ++;
        }

        index ++;

        if(Max > index){
            Name = movies[index].Name;
            AlternativeName1 = movies[index].AlternativeName1;
            AlternativeName2 = movies[index].AlternativeName2;
            UrlImage = movies[index].UrlImage;
        }else{
           await Navigation.PopToRootAsync();
        }

       
    	
    }

}