using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace FileExplorer.Views
{
    public partial class FolderNavigatorItem : UserControl
    {
        public static readonly StyledProperty<string> PathProperty = AvaloniaProperty.Register<FolderNavigatorItem, string>(nameof(Path), defaultValue: string.Empty);
        public string Path
        {
            get => GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public FolderNavigatorItem()
        {
            InitializeComponent();
            navigationButton.DataContext = this;
        }
    }

    public class FolderNavigatorItemConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string path)
            {
                var paths = path.Split('\\');
                return paths[paths.Length - 1];
            }
            return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
