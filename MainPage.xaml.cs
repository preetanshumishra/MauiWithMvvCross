using MauiWithMvvCross.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MauiWithMvvCross;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = MauiProgram.ServiceProvider.GetRequiredService<MainViewModel>();
	}
}
