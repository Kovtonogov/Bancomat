using System.Windows;
using System.Windows.Input;

namespace Test.Dialog
{
    /// <summary>
    /// Логика взаимодействия для TakeResult4.xaml
    /// </summary>
    public partial class TakeResult4 : Window
    {
        public TakeResult4()
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
