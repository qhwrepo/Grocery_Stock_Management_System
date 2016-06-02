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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string username, string identity)
        {
            InitializeComponent();
            if (identity.Equals("Administrator"))
            {
                button_Main_Exit.Height /= 2;
                this.button_Main_Manage.Visibility = Visibility.Visible;
            }
                
            this.label_Main_Username.Content = "WELCOME!  " + username;
            showSystemClock();
        }

        #region System Clock
        //system clock
        private void showSystemClock()
        {
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.label_Main_Time.Content = "DATE : " + DateTime.Now.ToString("dd/MM/yyyy") + " \nTIME : " + DateTime.Now.ToString("HH:mm:ss");
            }, this.Dispatcher);
        }
        #endregion

        private void button_Main_Add_Click(object sender, RoutedEventArgs e)
        {
            Item item = new Item();
            item.Owner = this;
            item.ShowDialog();

        }

        private void button_Main_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Main_Manage_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Owner = this;
            user.ShowDialog();
            user.Focus();
        }
    }
}
