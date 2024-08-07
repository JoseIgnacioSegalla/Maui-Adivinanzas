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
    private bool visible = false;

   

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

    private static int count = 0;

    private readonly MovieDbContext _dbContext;

    private readonly List<Movie> movies;

    public MovieViewModel()
    { 
        
        var dbContext = new MovieDbContext();
        _dbContext = dbContext;
        
        movies = _dbContext.Movies.ToList();

        Max = movies.Count();


       

         ChangeMovies();
      
        Visible = true;

    }


    [RelayCommand]
    public void BtnCount(string Correct)
    {
        
        
        if(Correct == "1"){
            count ++;
        }
        


        if(Max > index)
        {
            ChangeMovies();
            
        }else{

            Shell.Current.GoToAsync("//MainPage");

            count = 0;
            index = 0;

            ChangeMovies();
        }
        
    }

    public void ChangeMovies()  
    {
            Name = movies[index].Name;
            AlternativeName1 = movies[index].AlternativeName1;
            AlternativeName2 = movies[index].AlternativeName2;
            UrlImage = movies[index].UrlImage;

            index++;
    }



    [ObservableProperty]
    private  int counter = 10;

    
    public void StartCountdown()
    {
        var timer = Shell.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(2);
        timer.Tick += (s, e) =>
        {
            if (Counter == 0)
            {
                timer.Stop();
                
            }
            Counter--; 
            Debug.WriteLine($"Tiempo actual: {Counter}");

        };
        timer.Start();
    }
    

}