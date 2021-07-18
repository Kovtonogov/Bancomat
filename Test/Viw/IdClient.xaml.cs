using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;


namespace Test.Viw
{
    public partial class IdClient : UserControl
    {
        public IdClient()
        {
            InitializeComponent();
            DoubleAnimation loyautheight = new DoubleAnimation();
            loyautheight.From = PasswordWindow.ActualHeight;
            loyautheight.To = 450;
            loyautheight.Duration = TimeSpan.FromSeconds(0.1);
            PasswordWindow.BeginAnimation(Button.HeightProperty, loyautheight);

            DoubleAnimation loyautWidth = new DoubleAnimation();
            loyautWidth.From = PasswordWindow.ActualWidth;
            loyautWidth.To = 800;
            loyautWidth.Duration = TimeSpan.FromSeconds(0.5);
            loyautWidth.Completed += ButtonAnimation_Completed;
            PasswordWindow.BeginAnimation(Button.WidthProperty, loyautWidth);
        }

        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {
            pas.Visibility = Visibility.Visible;

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DragMove();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasBlock.Visibility = Visibility.Hidden;
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }

       
    }
}
