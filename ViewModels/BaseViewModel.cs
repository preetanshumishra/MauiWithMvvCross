using MvvmCross.Base;
using MvvmCross.ViewModels;

namespace MauiWithMvvCross.ViewModels
{
	public abstract class BaseViewModel : MvxViewModel
	{
		private bool _isBusy;
		private string _title = string.Empty;

		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
		}
	}
}
