using System;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InfoCommand _infoCommand = new InfoCommand();
        public InfoCommand InformationCommand
        {
            get { return _infoCommand; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public class InfoCommand : ICommand
        {
            public void Execute(object parameter)
            {
                MessageBox.Show("Hello, world!");
                NamesWindow namesWindow = new NamesWindow();
                namesWindow.Show();
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
        }
    }
}
