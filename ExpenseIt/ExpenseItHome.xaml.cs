using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseIt
{
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public string MainCaptionText { get; set; }
        public List<Person> ExpenseDataSource { get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
            }
        }
        public ObservableCollection<string> PersonsChecked { get; set; }


        public class Expense
        {
            public string ExpenseType { get; set; }
            public double ExpenseAmount { get; set; }
        }

        public class Person
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public List<Expense> Expenses { get; set; }
        }
        public ExpenseItHome()
        {
            InitializeComponent();
            MainCaptionText = "View Expense Report";
            LastChecked = DateTime.Now;
            DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
            ExpenseDataSource = new List<Person>()
            {
            new Person()
            {
                Name="Gosho",
                Department ="IT",
                Expenses = new List<Expense>()
                {
                    new Expense() { ExpenseType="Food", ExpenseAmount =50 },
                    new Expense() { ExpenseType="Car", ExpenseAmount=50 }
                }
            },
            new Person()
            {
                Name ="Gergana",
                Department ="Influencer",
                Expenses = new List<Expense>()
                {
                    new Expense() {  ExpenseType="Neshto", ExpenseAmount=50 },
                    new Expense() {  ExpenseType="Roze", ExpenseAmount=125 }
                }
            },
            new Person()
            {
                Name="Amun",
                Department ="Engineering",
                Expenses = new List<Expense>()
                {
                  new Expense() { ExpenseType="Tesla Model S", ExpenseAmount=90000 },
                  new Expense() { ExpenseType="Mac", ExpenseAmount=10000 },
                  new Expense() { ExpenseType="Winrar", ExpenseAmount=10 }
                }
            },
            new Person()
            {
                Name="Spasi",
                Department ="Security",
                Expenses = new List<Expense>()
                {
                    new Expense() { ExpenseType="Maybach but Amun is going to pay", ExpenseAmount=150000 }
                }
            },
            new Person()
            {
                Name="Mitko",
                Department ="Cleaning",
                Expenses = new List<Expense>()
                {
                    new Expense() { ExpenseType="Cotton", ExpenseAmount=10 }
                }
            },
            new Person()
            {
                Name="Stoyanka",
                Department ="Storage",
                Expenses = new List<Expense>()
                {
                    new Expense() { ExpenseType="Subaru", ExpenseAmount=10000 },
                    new Expense() { ExpenseType="Compass", ExpenseAmount=10 }
                }
            },
            new Person()
            {
                Name="Shefcheto na Fantaziata",
                Department ="Health",
                Expenses = new List<Expense>()
                {
                    new Expense() { ExpenseType="Chicken", ExpenseAmount=50 },
                    new Expense() { ExpenseType="Sos", ExpenseAmount=1000 },
                    new Expense() { ExpenseType="Salfetki za hvurlqne", ExpenseAmount=1000000 }
                }
            }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
            expenseReport.Height = Height;
            expenseReport.Width = Width;
            expenseReport.Show();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
            PersonsChecked.Add((peopleListBox.SelectedItem as ExpenseItHome.Person).Name);

        }
    }

}
