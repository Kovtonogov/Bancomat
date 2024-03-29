﻿using System.Windows;
using Test.VM;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();

            var viewModel = new MainWindowVM();
            window.DataContext = viewModel;
            viewModel.EventCloseWindow += (sender, args) => { window.Close(); };
            window.Show();

            base.OnStartup(e);
        }
    }
}
