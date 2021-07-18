using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Test.Model;
using Test.VM;

namespace Test.Viw
{
   
    public partial class Acces : UserControl
    {
      

        public Acces(int a)
        { 
            InitializeComponent();
            if (a == 0)
            {
                DoubleAnimation loyautWidth = new DoubleAnimation();
                loyautWidth.From = loadingscreen.ActualWidth;
                loyautWidth.To = 800;
                loyautWidth.Duration = TimeSpan.FromSeconds(0.5);
                loyautWidth.Completed += ButtonAnimation_Completed;
                loadingscreen.BeginAnimation(Button.WidthProperty, loyautWidth);
            }
            else
            {
                space.Visibility = Visibility.Visible;
                Con();
            }

        }

        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {
            space.Visibility = Visibility.Visible;
            Con();
        }

        private void Loading_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void Con()
        {
            
            Connect connect = new Connect();
            MainWindowVM mainWindowVM = new MainWindowVM();
            Task<string> task = connect.ConnectingAsync();
            string result = await task;
            Loading.Command.Execute(mainWindowVM.TConnect);
            
        }
    }
}
