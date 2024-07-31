namespace P1;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	
	}

	private async void CambiarPantalla(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new UnitPage(true));

	}


}

