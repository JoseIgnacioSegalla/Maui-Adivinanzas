using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace P1.ViewModels;

public partial class MovieViewModel : ObservableObject
{




    [ObservableProperty]
    private int totalScore = 0;

    [ObservableProperty]
    private string name = "Nombre";

    [ObservableProperty]
    private string alternativeName1 = "NombreAlternativo1";

    [ObservableProperty]
    private string alternativeName2 = "NombreAlternativo2";

    [ObservableProperty]
    private string urlImage = "adivinanza.jpeg";

    [ObservableProperty]
    private int counter = 10;

    [ObservableProperty]
    private bool correctImage = false;

    [ObservableProperty]
    private bool incorrectImage = false;


    private static int index = 0;

    private int Max = 0;

    private static int Score = 0;

    private readonly MovieDbContext _dbContext;

    private readonly List<Movie> movies;

    public MovieViewModel()
    {
        var dbContext = new MovieDbContext();

        _dbContext = dbContext;

        movies = _dbContext.Movies.ToList();

        Max = movies.Count() - 1;

    }

    [RelayCommand]
    public void On()
    {   
        index = 0;
        Score = 0;
        StartCountdown(20);
        ShowMovie();
    }

    [RelayCommand]
    public async Task BtnChangeAsync()
    {
        await Shell.Current.GoToAsync("//MoviePage");
    }


    [RelayCommand]
    public async Task BtnCount(string Correct)
    {


        if (Correct == movies[index].Name)
        {
            Score++;
            


            CorrectImage = true;
            IncorrectImage = false;

        }
        else
        {

            CorrectImage = false;
            IncorrectImage = true;
        }


        if (Max > index)
        {
            index++;

            ShowMovie();

            await Task.Delay(500);
            CorrectImage = false;
            IncorrectImage = false;

        }
        else
        {

            await Task.Delay(500);
            await Shell.Current.GoToAsync("//MainPage");

            CorrectImage = false;
            IncorrectImage = false;
            index = 0;
            Counter = -1;
            ShowMovie();
        }

    }

    [RelayCommand]
    public void TotalCounter()
    {
        TotalScore = Score;
       
    }
    public void ShowMovie()
    {

        var random = new Random();
        int randomNumber = random.Next(0, 3);

        if (movies != null)
        {


            if (randomNumber == 0)
            {

                Name = movies[index].Name;
                AlternativeName1 = movies[index].AlternativeName1;
                AlternativeName2 = movies[index].AlternativeName2;


            }
            else if (randomNumber == 1)
            {
                Name = movies[index].AlternativeName1;
                AlternativeName1 = movies[index].AlternativeName2;
                AlternativeName2 = movies[index].Name;

            }
            else
            {
                Name = movies[index].AlternativeName2;
                AlternativeName1 = movies[index].Name;
                AlternativeName2 = movies[index].AlternativeName1;


            }

            UrlImage = movies[index].UrlImage;

        }


    }

   


    [RelayCommand]
    public void StartCountdown(int max)
    {

        Counter = max;

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
            

        };
        timer.Start();
    }

}