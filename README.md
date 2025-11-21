# MauiWithMvvmCross

A .NET MAUI mobile application demonstrating MVVM (Model-View-ViewModel) architecture using the MvvmCross enterprise framework with Dependency Injection.

## Overview

This project showcases enterprise-grade MVVM development with .NET MAUI using the mature MvvmCross framework. It demonstrates:

- **MVVM Pattern Implementation**: Clean separation between UI (View), presentation logic (ViewModel), and data (Model)
- **MvxViewModel Integration**: Leverages MvvmCross's robust base classes and infrastructure
- **Enterprise MVVM Framework**: Demonstrates the advantages of using a full-featured MVVM framework
- **Service Locator Pattern**: Static ServiceProvider for flexible service resolution
- **Counter Application**: Interactive demo showing state management and command binding
- **Framework Comparison**: Shows how MvvmCross differs from lightweight MVVM approaches

This is one of three demonstration projects comparing different MVVM frameworks:
- **MauiWithMvvm** - Community Toolkit MVVM with constructor injection (lightweight, best practice)
- **MauiWithPrism** - Service locator pattern with static ServiceProvider (flexible)
- **MauiWithMvvmCross** (this project) - MvvmCross enterprise framework integration (feature-rich)

## Features

- **MvvmCross Framework**: Enterprise-grade MVVM implementation with MvvmCross library
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection for managing application dependencies
- **Service Locator Pattern**: Static ServiceProvider for elegant service resolution
- **Observable Properties**: Property change notification using MvxViewModel's SetProperty method
- **Commands**: Command implementation with MvvmCross's IMvxCommand
- **Multi-Platform Support**: Runs on Android and iOS
- **Counter Functionality**: Interactive counter demo with dynamic message updates

## Project Structure

```
MauiWithMvvmCross/
├── ViewModels/
│   ├── BaseViewModel.cs          # Abstract base class extending MvxViewModel
│   └── MainViewModel.cs          # ViewModel for MainPage with counter logic
├── MainPage.xaml                 # Main UI page
├── MainPage.xaml.cs              # Code-behind with service resolution
├── App.xaml                      # Application resources
├── App.xaml.cs                   # App startup logic
├── AppShell.xaml                 # Navigation shell
├── MauiProgram.cs                # DI configuration and app startup
├── LICENSE                       # MIT License
└── README.md                     # This file
```

## Getting Started

### Prerequisites

- .NET 10 SDK or later
- Visual Studio 2022, Visual Studio Code, or JetBrains Rider
- Android SDK (for Android builds)
- Xcode (for iOS builds on macOS)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build for all platforms
dotnet build

# Build for specific platform
dotnet build -f net10.0-android
dotnet build -f net10.0-ios
```

### Running the Application

```bash
# Run on Android emulator
dotnet run -f net10.0-android

# Run on iOS simulator
dotnet run -f net10.0-ios
```

## MVVM Implementation

### BaseViewModel

The `BaseViewModel` class extends `MvxViewModel` and serves as the foundation for all ViewModels:

```csharp
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
```

### MainViewModel

The `MainViewModel` demonstrates:

- Observable properties for data binding
- Command implementation with IMvxCommand
- Counter functionality with dynamic message updates

```csharp
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
```

## Dependency Injection

Services are registered and configured in `MauiProgram.cs`:

```csharp
var services = new ServiceCollection();

services.AddSingleton<AppShell>();
services.AddSingleton<MainPage>();
services.AddSingleton<MainViewModel>();

var serviceProvider = services.BuildServiceProvider();
MauiProgram.ServiceProvider = serviceProvider;
```

The static `ServiceProvider` allows for elegant service resolution throughout the application:

```csharp
// In MainPage.xaml.cs
BindingContext = MauiProgram.ServiceProvider.GetRequiredService<MainViewModel>();
```

## Architecture Patterns

### Service Locator Pattern

This project uses the Service Locator pattern for resolving dependencies:

```csharp
public static IServiceProvider ServiceProvider { get; private set; }
```

This approach provides flexibility and simplicity for MAUI applications.

### MvvmCross Benefits

- Enterprise-grade MVVM framework
- Built-in navigation service
- Plugin architecture
- Comprehensive binding system
- Strong community support

## Technologies Used

- **.NET MAUI**: Cross-platform mobile framework
- **MvvmCross**: Enterprise MVVM framework
- **Microsoft.Extensions.DependencyInjection**: Dependency injection container
- **C# 13**: Latest language features

## Supported Platforms

- Android 21.0+
- iOS 15.0+

## License

MIT License - See LICENSE file for details

## Author

Preetanshu Mishra
