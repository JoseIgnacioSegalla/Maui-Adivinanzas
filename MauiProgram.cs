using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


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



		builder.Services.AddDbContext<MovieDbContext>();
		builder.Services.AddTransient<MainPage>();


		using( var dbContext = new MovieDbContext() ){
		
			dbContext.Database.EnsureCreated();
			
		}

		
		
#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
