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
using MODEL;
using BLL;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        gsms_User user;
        gsms_UserManager um;
        
        #region Initialization
        public Login()
        {
            InitializeComponent();
            WidgetsInitialization();
            user = new gsms_User();
            um = new gsms_UserManager();
        }

        public void WidgetsInitialization()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            comboBox_Login_Identity.Items.Add("Administrator");
            comboBox_Login_Identity.Items.Add("Stock Manager");
            comboBox_Login_Identity.SelectedIndex = 1;
            textBox_Login_Username.Focus();
        }
        #endregion

        private void button_Login_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Login_Login_Click(object sender, RoutedEventArgs e)
        {
            user.Username = textBox_Login_Username.Text;
            user.Password = passwordBox_Login_Password.Password;
            user.Useridentity = comboBox_Login_Identity.Text;
            if (um.search_User(user) > 0)
            {
                MainWindow MW = new MainWindow(this.textBox_Login_Username.Text, this.comboBox_Login_Identity.Text);
                this.Hide();
                MW.Show();
            }
            else
                MessageBox.Show("Please check your username, password and identity!");
        }
    }
}
