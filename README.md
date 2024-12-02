# LingoLift
A lightweight application designed to translate PDF documents.

### Project layout
This project was created with the project and solution placed in the same directory due to its small scale.

### Resources:
- [RelayCommand](https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern)
- [OpenFileDialog](https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0)
- [PdfPig](https://dev.to/eliotjones/reading-a-pdf-in-c-on-net-core-43ef)
```bash
dotnet add package PdfPig
```

## Dev notes on Setting up WPF MVVM Projects:
---

## Creating a the MainViewModel:

### Hooking up the ViewModel to the Xaml Window:
- 3 Options: 
	- Code-Behind: Dynamic, flexible, and easier for debugging.
	- XAML: Declarative, pure MVVM, and clean separation of concerns. ✔
	- Modern Practice: Dependency Injection for scalability and flexibility.

In App.xaml:
```xml
<Application x:Class="LingoLift.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:LingoLift" !-- Reference the namespace of the viewmodel -->
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <local:MainViewModel x:Key="MainViewModel" /> !-- Create an instance of the viewmodel -->
    </Application.Resources>
</Application>

```

In MainWindow.xaml:
```xml
<Window x:Class="LingoLift.MainWindow"
        <!-- ... Boiler Plate code...--> 
        DataContext="{StaticResource MainViewModel}"> <!-- Set the DataContext to the viewmodel -->
    <Grid>
    </Grid>
</Window>

```

### Different ViewModel approaches:

| **Scenario**                            | **Recommended Approach**								     | Notes                                 |
|-----------------------------------------|--------------------------------------------------------------|---------------------------------------|
| Dynamic UI with bindings ✔              | `INotifyPropertyChanged` or similar							 | Most Common Approach                  |
| Simple static or read-only data         | No `INotifyPropertyChanged` required					     |									     |
| Large-scale apps with consistent MVVM   | Base class or framework (e.g., Prism, CommunityToolkit.Mvvm) |										 |
| Reactive programming required           | ReactiveUI or Rx											 |										 |


Example of getting text font 
```csharp
foreach (var letter in page.Letters)
                {
                    Debug.WriteLine($"Character: '{letter.Value}'");
                    Debug.WriteLine($"Font Name: {letter.FontName}");
                    Debug.WriteLine($"Font Size: {letter.FontSize}");
                    Debug.WriteLine($"Position: {letter.GlyphRectangle.BottomLeft} to {letter.GlyphRectangle.TopRight}");
                    Debug.WriteLine(new string('-', 40));
                }
```


12/1 
- Project initialization
- Simple Button / UI Setup

12/2
- Added OpenFileDialog
- Added PdfPig Parsing