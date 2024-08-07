using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


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

    [ObservableProperty]
    private  int counter = 10;

    [ObservableProperty]
    private bool correctImage = false;

    [ObservableProperty]

    private bool incorrectImage = false;



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
    public async Task BtnCount(string Correct)
    {
        

        if(Correct == "1"){
            count ++;
            CorrectImage = true;
            IncorrectImage = false;
          //si isvalid es true = Image (Correct)

        }else{
           
            CorrectImage = false;
            IncorrectImage = true;
            
        //se isvalid es false = Image (Incorrect)

        }

        if(Max > index)
        {
            ChangeMovies();
            await Task.Delay(500);
            CorrectImage = false;
            IncorrectImage = false;
             
        }else{
           
            await Task.Delay(500);
            await Shell.Current.GoToAsync("//MainPage");

            CorrectImage = false;
            IncorrectImage = false;
            count = 0;
            index = 0;
            Counter = -1;

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

    

   
    
    public void StartCountdown(int MaxCount)
    {
        Counter = MaxCount;

        var timer = Shell.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) =>
        {
            if (Counter <= 0)
            {
                timer.Stop();
                Shell.Current.GoToAsync("//MainPage");
                
            }
            Counter--; 
            Debug.WriteLine($"Tiempo actual: {Counter}");

        };
        timer.Start();
    }

}