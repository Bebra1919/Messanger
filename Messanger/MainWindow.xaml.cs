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

namespace Messanger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SqlConnection conn = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Messenger; Integrated Security=SSPI;");
            conn.Open();
            Sqlcommand sqlcommand = new Sqlcommand($"SELECT * FROM Messenger WHERE Login = '{LoginBox.Text}' and USER_PASSWORD = '{PasswordBox. Password}';", conn);
            SqlDataReader reader = SqlCommand.ExecuteReader();
            if (reader.Read)
            {
                User user = new User((int)reader[0], reader[1].ToString(), reader[2].ToString());
                reader.Close;
                Messanger secondwindow = new Messanger(user);
                secondwindow.Show();
                this.Close();
            }
            else
            {
                ExeptionBlock.Text = "Неверный логин или пароль";
            }

           

        }
    }
}
