using System.Windows;
using System.Windows.Input;

namespace Test.Dialog
{
    /// <summary>
    /// Логика взаимодействия для TakeResult3.xaml
    /// </summary>
    public partial class TakeResult3 : Window
    {
        public TakeResult3()
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
