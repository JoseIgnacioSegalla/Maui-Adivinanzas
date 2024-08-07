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

    }


    public void StartCountdown()
	{
		var timer = Shell.Current.Dispatcher.CreateTimer();
		timer.Interval = TimeSpan.FromSeconds(_IntervalSeconds);
		timer.Tick += (s, e) =>
		{
		
			if (_Counter == 0)
			{
				
				timer.Stop();
				
			
				
			}
			_Counter--;
		};
		timer.Start();
        
	}
}