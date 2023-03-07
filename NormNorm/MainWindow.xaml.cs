using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using Classes;


namespace NormNorm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.Delete();
            }
            InitializeComponent();
            User.CreateAdmin();
            Group.CreateGroups();
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {

            User user = User.LogIn(login.Text, password.Password);
            if (user != null)
            {
                Hide();
                Journal journal = new Journal();
                journal.ShowDialog();
                Show();
            }
            else MessageBox.Show("Uncorrected login or password", "Error", MessageBoxButton.OK);
        }
    }
}
