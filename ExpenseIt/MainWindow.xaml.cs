using System.Windows;

namespace ExpenseIt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExpenseItHome homeWindow = new ExpenseItHome();
            homeWindow.Height = Height;
            homeWindow.Width = Width;
            homeWindow.Show();
            Close();
        }
    }
}
