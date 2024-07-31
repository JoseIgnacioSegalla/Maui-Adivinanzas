namespace P1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		
		InitializeComponent();
	}

	
protected override bool OnBackButtonPressed()
{
	return false;
}
}
