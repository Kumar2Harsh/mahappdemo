using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTutorialSeries
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickEvent(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Wpf Tutorial series!!!");
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Employee (EmpID,EmpName,DOB,Address,Country,Gender,PhotoUrl) values" +
                "(@EmpID,@EmpName,@DOB,@Address,@Country,@Gender,@PhotoUrl)", connection);
            var empId = Convert.ToInt32(txtEmpID.Text);
            var dob = Convert.ToDateTime(dpDOB.Text);
            var gender = (bool)rbMale.IsChecked ? "Male" : "Female";
            command.Parameters.AddWithValue("@EmpID", empId);
            command.Parameters.AddWithValue("@EmpName", txtName.Text);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Address", txtAddress.Text);
            command.Parameters.AddWithValue("@Country", cbCountry.SelectedItem);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@PhotoUrl", "");
            command.ExecuteNonQuery();
            MessageBox.Show("Sucessfully Saved", "Sucess");
        }

        private void GetDetails(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Employee where EmpID=@EmpID", connection);
            var empId = Convert.ToInt32(txtEmpID.Text);
            command.Parameters.AddWithValue("@EmpID", empId);
            var reader=command.ExecuteReader();
            while(reader.Read())
            {
                txtName.Text = reader["EmpName"].ToString();
                dpDOB.Text = reader["DOB"].ToString();
                txtAddress.Text = reader["Address"].ToString();
                var country = reader["Country"].ToString();
                var gender = reader["Gender"].ToString();
                cbCountry.SelectedItem = country;
                if (gender == "Male")
                    rbMale.IsChecked = true;
                else
                    rbFemale.IsChecked = true;
            }

        }

        private void Update(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("update Employee set EmpID=@EmpID,EmpName=@EmpName," +
                "DOB=@DOB,Address=@Address,Country=@Country,Gender=@Gender,PhotoUrl=@PhotoUrl where EmpID=@EmpID", connection);
            var empId = Convert.ToInt32(txtEmpID.Text);
            var dob = Convert.ToDateTime(dpDOB.Text);
            var gender = (bool)rbMale.IsChecked ? "Male" : "Female";
            command.Parameters.AddWithValue("@EmpID", empId);
            command.Parameters.AddWithValue("@EmpName", txtName.Text);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Address", txtAddress.Text);
            command.Parameters.AddWithValue("@Country", cbCountry.SelectedItem);
            command.Parameters.AddWithValue("@Gender", gender);
            command.Parameters.AddWithValue("@PhotoUrl", "");
            command.ExecuteNonQuery();
            MessageBox.Show("Sucessfully Updated", "Sucess");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=EmployeeDB;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Employee where EmpID=@EmpID", connection);
            var empId = Convert.ToInt32(txtEmpID.Text);
            command.Parameters.AddWithValue("@EmpID", empId);
            command.ExecuteNonQuery();
            MessageBox.Show("Sucessfully deleted", "Sucess");
        }

        private void ChengeThemeToDark(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(this, "Dark.Blue");
        }

        private void ChengeThemeToLight(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(this, "Light.Blue");
        }
    }
}
