using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentInfoSystem
{

    public partial class MainWindow : Window
    {
        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();
            DataContext = this;

            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int count = queryStudents.Count();

            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void ClearFields()
        {
            txtName.Text = "";
            txtMiddleName.Text = "";
            txtFamilyName.Text = "";
            txtFaculty.Text = "";
            txtSpecialty.Text = "";
            txtEducationalDegree.Text = "";
            listboxStat.ItemsSource = "";
            txtFacultyNumber.Text = "";
            txtCourse.Text = "";
            txtFlow.Text = "";
            txtGroup.Text = "";
        }

        public void GetStudentInfo()
        {
            List<Student> students = StudentData.TestStudents;

            txtName.Text = students[0].name;
            txtMiddleName.Text = students[0].middleName;
            txtFamilyName.Text = students[0].familyName;
            txtFaculty.Text = students[0].faculty;
            txtSpecialty.Text = students[0].specialty;
            txtEducationalDegree.Text = students[0].educationalDegree;
            listboxStat.ItemsSource = StudStatusChoices;
            txtFacultyNumber.Text = students[0].facultyNumber;
            txtCourse.Text = students[0].course.ToString();
            txtFlow.Text = students[0].flow.ToString();
            txtGroup.Text = students[0].group.ToString();
        }

        public void DisableFields()
        {
            btnClear.IsEnabled = false;
            btnShowData.IsEnabled = false;
        }

        public void EnableFields()
        {
            btnClear.IsEnabled = true;
            btnShowData.IsEnabled = true;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnDisableCntrls_Click(object sender, RoutedEventArgs e)
        {
            DisableFields();
        }

        private void btnShowData_Click(object sender, RoutedEventArgs e)
        {
            GetStudentInfo();
        }

        private void btnEnableCntrls_Click(object sender, RoutedEventArgs e)
        {
            EnableFields();
        }


        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }
    }
}
