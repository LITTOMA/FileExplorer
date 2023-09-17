using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using FileExplorer.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FileExplorer.Views
{
    public partial class FolderNavigator : UserControl
    {
        public static readonly StyledProperty<string> PathProperty = AvaloniaProperty.Register<FolderNavigator, string>(nameof(Path), defaultValue: string.Empty);
        public string Path
        {
            get => GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public static readonly DirectProperty<FolderNavigator, IEnumerable<string>> ItemsProperty = AvaloniaProperty.RegisterDirect<FolderNavigator, IEnumerable<string>>(nameof(Items), o => o.Items);
        private IEnumerable<string> _items;
        public IEnumerable<string> Items
        {
            get => _items;
            set => SetAndRaise(ItemsProperty, ref _items, value);
        }

        public FolderNavigator()
        {
            InitializeComponent();

            navigatorItems.DataContext = this;
            PathProperty.Changed.AddClassHandler<FolderNavigator>(OnPathChanged);
        }

        private void OnPathChanged(FolderNavigator navigator, AvaloniaPropertyChangedEventArgs args)
        {
            if (args.NewValue is string path)
            {
                var paths = PathUtils.ParsePathHierarchy(path);
                Items = new ObservableCollection<string>(paths);
            }
        }
    }
}
