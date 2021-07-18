using System.Windows;
using System.Windows.Input;
using Test.Model;

namespace Test
{
    public partial class MainWindow : Window
    {       

        public MainWindow()
        {
            
            InitializeComponent();                       
            CreateBancomat createBancomat = new CreateBancomat();            
            createBancomat.Create();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }        

    }
}
