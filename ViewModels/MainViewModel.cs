using MvvmCross.Commands;

namespace MauiWithMvvCross.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private string _message = "Welcome to MAUI with MvvmCross!";
		private int _counter;

		public string Message
		{
			get => _message;
			set => SetProperty(ref _message, value);
		}

		public int Counter
		{
			get => _counter;
			set => SetProperty(ref _counter, value);
		}

		public IMvxCommand IncrementCounterCommand { get; }

		public MainViewModel()
		{
			Title = "Main Page";
			IncrementCounterCommand = new MvxCommand(IncrementCounter);
		}

		private void IncrementCounter()
		{
			Counter++;
			Message = Counter == 1
				? "Clicked 1 time"
				: $"Clicked {Counter} times";
		}
	}
}
