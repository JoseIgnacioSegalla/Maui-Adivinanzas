using System.Diagnostics;

namespace P1;

public partial class UnitPage : ContentPage
{
	private int _intervalSeconds = 1;
	private int _counter = 10;
	private static int _totalPoints = 0;

	public UnitPage(bool InitializeCountDown)
	{
		InitializeComponent();


		if (InitializeCountDown)
		{
			StartCountdown();
		}
	}

	private async void StartCountdown()
	{
		var timer = Application.Current.Dispatcher.CreateTimer();
		timer.Interval = TimeSpan.FromSeconds(_intervalSeconds);
		timer.Tick += async (s, e) =>
		{
			Debug.WriteLine(_counter);

			if (_counter == 0)
			{
				//Detener el timer
				timer.Stop();
				//Enviar la puntuacion total 
				// Volver a la página principal
				await Navigation.PopToRootAsync();
				
			}
			_counter--;
		};
		timer.Start();
	}




	private async void RefreshPage(object sender, EventArgs e)
	{

		// Sumar 1 si es correcto, no sumar nada si no es correcto
		/*if (Labelnombre == nombrePelicula){
			_totalPoints ++;
		}
		*/
		// Agregarle +1 a la puntuacion total
		_totalPoints ++;
		Debug.WriteLine($"Puntuacion Total:{_totalPoints}");
		await Navigation.PushAsync(new UnitPage(false));
		
	}

}