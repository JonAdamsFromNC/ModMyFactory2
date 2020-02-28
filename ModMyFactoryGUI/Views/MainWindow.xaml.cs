using Avalonia;
using Avalonia.Markup.Xaml;
using ModMyFactoryGUI.Controls;

namespace ModMyFactoryGUI.Views
{
    partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
