# MauiWithMvvCross

A .NET MAUI sample demonstrating enterprise-grade MVVM using the MvvmCross framework. This project serves as a reference implementation for scalable, testable .NET MAUI applications with advanced MVVM patterns.

## Overview

MauiWithMvvCross showcases **enterprise MVVM patterns** with MvvmCross:
- **MvvmCross Framework** - Mature, production-ready MVVM framework with 10+ years of development
- **IoC Container** - Built-in dependency injection with automatic service registration
- **ViewModel-First Navigation** - Route to ViewModels instead of Views
- **Automatic Bindings** - Powerful data binding with change notifications
- **Plugin System** - Extensible architecture for common cross-platform features
- **Testability** - Designed from ground up for unit testing

## Project Structure

```
MauiWithMvvCross/
├── MauiProgram.cs                    # MvvmCross setup & IoC configuration
├── App.xaml / App.xaml.cs           # Global resources & styling
├── AppShell.xaml / AppShell.xaml.cs  # Shell navigation
├── MainPage.xaml / MainPage.xaml.cs  # Main UI with bindings
│
├── ViewModels/
│   ├── BaseViewModel.cs              # Base class with IsBusy, Title
│   └── MainViewModel.cs              # Counter demo with MvxCommand
│
├── Resources/
│   ├── Styles/
│   │   ├── Colors.xaml               # Color palette (light/dark)
│   │   └── Styles.xaml               # 30+ component styles
│   ├── Images/ / Fonts/ / AppIcon/
│   └── Splash/
│
└── Platforms/
    ├── iOS/
    │   ├── AppDelegate.cs
    │   ├── Program.cs
    │   └── Setup.cs                  # iOS-specific MvvmCross setup
    └── Android/
        ├── MainActivity.cs
        ├── MainApplication.cs
        └── Setup.cs                  # Android-specific MvvmCross setup
```

## Tech Stack

| Component | Version | Purpose |
|-----------|---------|---------|
| **.NET** | 10.0 | Runtime framework |
| **.NET MAUI** | 10.0.10 | Cross-platform UI |
| **MvvmCross** | 10.0.0 | Enterprise MVVM framework |
| **Microsoft.Extensions.DependencyInjection** | 10.0.0 | DI container |
| **Target Platforms** | iOS 15.0+, Android 21+ | Supported |

## Architecture

### MvvmCross Framework

MvvmCross is an **enterprise-grade MVVM framework** with:
- Built-in IoC container
- ViewModel-first navigation
- Automatic view-to-ViewModel binding
- Plugin system for features
- 10+ years of production use

### IoC Container Setup

```csharp
// In MauiProgram.cs
var builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .ConfigureFonts(fonts => { /* ... */ })
    .UseMvvmCross();

var app = builder.Build();
```

### ViewModel Implementation

**BaseViewModel** (MvxViewModel):
- Inherits from `MvxViewModel` (MvvmCross base class)
- Provides `IsBusy` and `Title` properties
- `SetProperty()` for reactive changes
- Base for all ViewModels

**MainViewModel**:
- `[ObservableProperty]` for properties
- `IMvxCommand` for command binding
- Constructor injection of services
- Automatic change notifications

### ViewModel-First Navigation

MvvmCross uses **ViewModel-first routing**:

```csharp
// Navigate to ViewModel directly
[RelayCommand]
private async Task Navigate()
{
    await Shell.Current.GoToAsync(nameof(SecondViewModel));
}
```

### Binding Pattern

```xml
<!-- Automatic binding to ViewModel properties -->
<Label Text="{Binding Message}" />
<Button Command="{Binding IncrementCounterCommand}" />
```

## Key Features

- **Enterprise MVVM** - Production-grade patterns and practices
- **IoC Container** - Automatic service registration and resolution
- **ViewModel-First Navigation** - Route by ViewModel, not View
- **Automatic Bindings** - Seamless property-to-UI binding
- **Plugin System** - Extensible architecture
- **Testability** - Designed for unit testing
- **Platform-Specific Setup** - iOS and Android configurations
- **Theme Support** - Light/dark theming
- **30+ Built-in Styles** - Comprehensive component styling

## Quick Start

### Prerequisites
- .NET 10.0 SDK
- Xcode 15+ (iOS)
- Android SDK 21+ (Android)

### Build & Run

```bash
dotnet restore
dotnet build

# iOS Simulator
dotnet run -f net10.0-ios

# Android Emulator
dotnet run -f net10.0-android

# Production builds
dotnet publish -f net10.0-ios -c Release
dotnet publish -f net10.0-android -c Release
```

## MVVM Patterns

### Observable Properties
```csharp
public partial class MainViewModel : MvxViewModel
{
    [ObservableProperty]
    private int counter = 0;

    [ObservableProperty]
    private string message = "Click the button";
}
```

### MvxCommand
```csharp
[RelayCommand]
private void IncrementCounter()
{
    Counter++;
    Message = $"Clicked {Counter} times";
}
```

### Data Binding
```xml
<Label Text="{Binding Message}" FontSize="20" />
<Button Text="Click" Command="{Binding IncrementCounterCommand}" />
```

## Styling System

**Color Palette** (`Resources/Styles/Colors.xaml`):
- **Primary**: #512BD4 (Purple)
- **Secondary**: #DFD8F7 (Light Purple)
- **Tertiary**: #2B0B98 (Dark Purple)
- **Grayscale**: Gray100-Gray950

**Component Styles** (`Resources/Styles/Styles.xaml`):
- 30+ control styles (Button, Label, Entry, DatePicker, etc.)
- Light/dark theme support via `AppThemeBinding`
- Visual state management (Normal, Disabled, PointerOver)
- Minimum touch targets (44x44px) for accessibility

## Platform-Specific Configuration

### iOS Setup
File: `Platforms/iOS/Setup.cs`
- Extends `MvxIosSetup<App>`
- Platform-specific logging configuration
- UIKit customizations

### Android Setup
File: `Platforms/Android/Setup.cs`
- Extends `MvxAndroidSetup<App>`
- Android-specific logging
- Android Framework integration

## Extending the Project

### Adding a New ViewModel

1. Create class inheriting from `MvxViewModel`:
   ```csharp
   public partial class NewViewModel : MvxViewModel
   {
       [ObservableProperty]
       private string title = "My Page";

       [RelayCommand]
       private void MyCommand() { }
   }
   ```

2. Create corresponding XAML page
3. ViewModel automatically resolves from IoC

### Adding Services

1. Define service interface
2. Implement service
3. Register in `MauiProgram.cs`:
   ```csharp
   services.AddSingleton<IMyService, MyService>();
   ```
4. Inject in ViewModels:
   ```csharp
   public MyViewModel(IMyService service) { }
   ```

## Testing

MvvmCross was designed for testability:

```csharp
[TestClass]
public class MainViewModelTests
{
    [TestMethod]
    public void IncrementCounter_ShouldUpdateMessage()
    {
        var viewModel = new MainViewModel();
        viewModel.IncrementCounterCommand.Execute();
        Assert.IsTrue(viewModel.Message.Contains("1"));
    }
}
```

## MvvmCross Advantages

- ✅ **Mature Framework** - 10+ years of production use
- ✅ **Plugin System** - Extend with plugins
- ✅ **ViewModel-First** - Better code organization
- ✅ **Testable** - Designed for unit testing
- ✅ **Cross-Platform** - Share logic across platforms
- ✅ **Community** - Large community and resources
- ✅ **Documentation** - Extensive guides and samples

## When to Use MvvmCross

**Excellent for**:
- ✅ Large enterprise applications
- ✅ Complex business logic
- ✅ High testability requirements
- ✅ Shared ViewModels across platforms
- ✅ Long-term maintenance

**Consider alternatives for**:
- ❌ Simple single-page apps
- ❌ Rapid prototyping
- ❌ Learning basic MVVM patterns

## Resources

- [MvvmCross Documentation](https://www.mvvmcross.com/)
- [MvvmCross Samples](https://github.com/MvvmCross/MvvmCross)
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Enterprise MVVM Patterns](https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-in-practice-the-little-things-that-make-a-big-difference)

## License

MIT License - See LICENSE file for details.
