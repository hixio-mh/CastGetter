using CastGetter.VM;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CastGetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            base.DataContext = viewModel;
        }

        private void CommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }
    }
}
