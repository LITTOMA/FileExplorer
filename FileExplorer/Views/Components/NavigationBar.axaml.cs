using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FileExplorer.Views
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();

            pathEditor.LostFocus += PathEditor_LostFocus;
        }

        private void Navigator_Tapped(object? sender, TappedEventArgs e)
        {
            if (!pathEditor.IsFocused)
            {
                Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    await Task.Delay(10);
                    pathEditor.IsVisible = true;
                    pathEditor.Focus();
                    pathEditor.CaretIndex = pathEditor.Text.Length;
                });
            }
        }

        private void PathEditor_LostFocus(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pathEditor.IsVisible = false;
        }
    }
}
