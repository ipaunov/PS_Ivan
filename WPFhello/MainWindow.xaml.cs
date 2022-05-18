using System.Windows;
using System.Windows.Controls;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length >= 2)
            {
                MessageBox.Show("Здрасти!!! " + txtName.Text + " !!!\n Това е твоята първа програма на Visual Studio 2022!");
            }
            else
            {
                MessageBox.Show("Не е подадено име.");
            }
        }

        private void btnGreeting_Click(object sender, RoutedEventArgs e)
        {
            /*string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg); */
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }
    }
}
