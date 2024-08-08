using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Übung_OwnSimpleTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        }

        private void onFontSizeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (wrapPanel == null)
            {
                return;
            }
            foreach (Button ForEachbutton in wrapPanel.Children)
            {
                ForEachbutton.FontSize = e.NewValue;
            }
        }

        private void onFontChanged(object sender, SelectionChangedEventArgs e)
        {
            showFont((FontFamily)fontList.SelectedItem);
        }

        private void showFont(FontFamily fontFamily)
        {
            wrapPanel.Children.Clear();                 // ich gucke in den x:Name nach sseinen Kinder und leere sie
            int from = int.Parse(fromUnicode.Text);
            int to = int.Parse(toUnicode.Text);
            for (int i = from; i <= to; i++)
            {
                Button button = new Button()
                {
                    Content = (char)i,
                    FontFamily = fontFamily,
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,
                    Margin = new Thickness(2),
                    ToolTip = $"Unicode: &#x{i:x4};\n Dezimal:{i}",     //&#x bedeutet Unicode anzeigen
                    FontSize = fontSizeSlider.Value,
                };
                wrapPanel.Children.Add(button);
            }
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}