using System.Diagnostics;
using P1.ViewModels;
namespace P1;

public partial class MoviePage : ContentPage
{

    


	public MoviePage()
    {
        InitializeComponent();
        
		
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var viewModel = (MovieViewModel)BindingContext;
        viewModel.StartCountdown(20);

    }
    

}