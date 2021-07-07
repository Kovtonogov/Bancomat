using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для IdClient.xaml
    /// </summary>
    public partial class IdClient : Window
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
            this.DragMove();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasBlock.Visibility = Visibility.Hidden;
        }

        private void Clouse_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Close();
            this.Close();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
