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
using Test.Model;
using Test.VM;

namespace Test.Viw
{
    /// <summary>
    /// Логика взаимодействия для Acces.xaml
    /// </summary>
    public partial class Acces : UserControl
    {
      

        public Acces()
        { 
            InitializeComponent();
            DoubleAnimation loyautWidth = new DoubleAnimation();
            loyautWidth.From = loadingscreen.ActualWidth;
            loyautWidth.To = 800;
            loyautWidth.Duration = TimeSpan.FromSeconds(0.5);
            loyautWidth.Completed += ButtonAnimation_Completed;
            loadingscreen.BeginAnimation(Button.WidthProperty, loyautWidth);
        }

        private void ButtonAnimation_Completed(object sender, EventArgs e)
        {

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
