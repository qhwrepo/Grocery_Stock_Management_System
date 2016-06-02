using System;
using System.Windows;
using MODEL;
using BLL;
using System.Data;


namespace UI
{
    /// <summary>
    /// User.xaml 的交互逻辑
    /// </summary>
    public partial class User : Window
    {
        private gsms_User user;
        private gsms_UserManager um;

        public User()
        {
            InitializeComponent();
            WidgetsInitialization();

            user = new gsms_User();
            um = new gsms_UserManager();
            LoadData();
        }

        #region DataGrid Loading
        private void LoadData()
        {
            try
            {
                DataTable DT = um.show_User();
                dataGrid_User_Data.ItemsSource = DT.DefaultView;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Widgets Initialization
        public void WidgetsInitialization()
        {
            dataGrid_User_Data.IsReadOnly = true;
            comboBox_User_Identity.Items.Add("Administrator");
            comboBox_User_Identity.Items.Add("Stock Manager");
            comboBox_User_Identity.SelectedIndex = -1;
        }
        #endregion

        private void button_User_Add_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_User_Password.Text=="" || textBox_User_Username.Text=="" || comboBox_User_Identity.SelectedIndex == -1)
            {
                MessageBox.Show("Username, Password or Identity can't be empty", "Add New User Failed!", MessageBoxButton.OK);
                return;
            }
            user.Username = textBox_User_Username.Text;
            user.Password = textBox_User_Password.Text;
            user.Useridentity = comboBox_User_Identity.Text;
            //Add new user
            try
            {
                if (um.add_User(user) > 0)
                {
                    MessageBox.Show("Add new user successfully!");
                    LoadData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Woops! There is a user with the same username already!", "User existed!");
            }
            
        }

        private void button_User_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_User_Delete_Click(object sender, RoutedEventArgs e)
        {
            //Check if any row is selected
            if(dataGrid_User_Data.SelectedItem == null)
            {
                MessageBox.Show("Please select one item!");
                return;
            }
            
            //Assign datagrid value to user
            DataRowView row = (DataRowView)dataGrid_User_Data.SelectedItem;
            user.Username = row["Username"].ToString();
            user.Password = row["Password"].ToString();
            user.Useridentity = row["UserIdentity"].ToString();
            
            //Delete confirmation
            MessageBoxResult MBR = MessageBox.Show("Do you really want to delete this user?", "Deleting user", MessageBoxButton.YesNo);
            if(MBR == MessageBoxResult.Yes)
            {
                um.delete_User(user);
                LoadData();
            }
            else
            {
                return;
            }
        }
    }
}
