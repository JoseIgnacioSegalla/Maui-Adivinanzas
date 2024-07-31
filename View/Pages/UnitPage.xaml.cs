using System.Diagnostics;

namespace P1;

public partial class UnitPage : ContentPage
{
	private int _intervalSeconds = 1;
	private int _counter = 10;

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
				timer.Stop();
				await Navigation.PopToRootAsync();
				// Volver a la página principal
			}
			_counter--;
		};
		timer.Start();
	}




	private async void Print(object sender, EventArgs e)
	{

		/// Sumar 1 si es correcto, no sumar nada si no es correcto
		await Navigation.PushAsync(new UnitPage(false));
	}

}