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
using Test.VM;


namespace Test.Viw
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        public Main(int a)
        {
            InitializeComponent();

            if (a == 0)
            {
                DoubleAnimation loyautheight = new DoubleAnimation();
                loyautheight.From = loyaut.ActualHeight;
                loyautheight.To = 700;
                loyautheight.Duration = TimeSpan.FromSeconds(0.1);
                loyaut.BeginAnimation(Button.HeightProperty, loyautheight);

                DoubleAnimation loyautWidth = new DoubleAnimation();
                loyautWidth.From = loyaut.ActualWidth;
                loyautWidth.To = 450;
                loyautWidth.Duration = TimeSpan.FromSeconds(0.5);
                loyautWidth.Completed += ButtonAnimation_Completed;
                loyaut.BeginAnimation(Button.WidthProperty, loyautWidth);
            }
            else
                client.Visibility = Visibility.Visible;
        }


        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {
            client.Visibility = Visibility.Visible;           
         
        }

        


    }
}
