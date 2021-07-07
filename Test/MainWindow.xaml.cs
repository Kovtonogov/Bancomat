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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DoubleAnimation loyautheight = new DoubleAnimation();
            loyautheight.From = loyaout.ActualHeight;
            loyautheight.To = 700;
            loyautheight.Duration = TimeSpan.FromSeconds(0.1);
            loyaout.BeginAnimation(Button.HeightProperty, loyautheight);

            DoubleAnimation loyautWidth = new DoubleAnimation();
            loyautWidth.From = loyaout.ActualWidth;
            loyautWidth.To = 400;
            loyautWidth.Duration = TimeSpan.FromSeconds(0.5);
            loyautWidth.Completed += ButtonAnimation_Completed;
            loyaout.BeginAnimation(Button.WidthProperty, loyautWidth);

        }

        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {


            IdClient idClient = new IdClient();
            idClient.Owner = this;
            idClient.Show();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }        

    }
}
