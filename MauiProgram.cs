using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using P1.ViewModels;


namespace P1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		
		builder
		.UseMauiCommunityToolkit()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});



		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MovieViewModel>();
		builder.Services.AddDbContext<MovieDbContext>();
		
		using( var dbContext = new MovieDbContext() ){
		
			dbContext.Database.EnsureCreated();
			
		}

		
		
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
