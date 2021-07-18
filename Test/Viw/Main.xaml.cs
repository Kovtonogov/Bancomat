using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Test.Viw
{
   
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
