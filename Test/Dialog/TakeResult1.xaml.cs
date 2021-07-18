using System.Windows;
using System.Windows.Input;

namespace Test.Dialog
{
    /// <summary>
    /// Логика взаимодействия для TakeResult1.xaml
    /// </summary>
    public partial class TakeResult1 : Window
    {
        public TakeResult1()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
