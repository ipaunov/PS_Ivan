using System.Windows;

namespace ExpenseIt
{
    public partial class ExpenseReport : Window
    {
        public ExpenseReport()
        {
            InitializeComponent();
        }

        public ExpenseReport(object data)
            : this()
        {
            DataContext = data;
        }

    }
}
