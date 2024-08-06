using CommunityToolkit.Mvvm.ComponentModel;

namespace P1.ViewModels;


public partial class TimerViewModel : ObservableObject
{

   
	[ObservableProperty]
    private int _Counter = 10;
    
    [ObservableProperty]
    private int _IntervalSeconds = 2;
	
    public TimerViewModel()
    {
        StartCountdown();
    }

    private async void StartCountdown()
	{
		var timer = Application.Current.Dispatcher.CreateTimer();
		timer.Interval = TimeSpan.FromSeconds(_IntervalSeconds);
		timer.Tick += (s, e) =>
		{
		
			if (_Counter == 0)
			{
				//Detener el timer
				timer.Stop();
				
				//Enviar la puntuacion total 
				// Volver a la página principal
				
				
			}
			_Counter--;
		};
		timer.Start();
        
	}
}