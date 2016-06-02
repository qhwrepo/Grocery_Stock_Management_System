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
using MODEL;
using BLL;
using Microsoft.Win32;

namespace UI
{
    /// <summary>
    /// Item.xaml 的交互逻辑
    /// </summary>
    
    public partial class Item : Window
    {
        #region Declaration
        private gsms_Item item;
        private gsms_ItemManager IM;
        #endregion

        #region Initialization
        public Item()
        {
            InitializeComponent();
            WidgetsInitialization();
            item = new Item();
            IM = new gsms_ItemManager();
        }

        public void WidgetsInitialization()
        {
            comboBox_Item_Classification.SelectedIndex = 0;
            comboBox_Item_Classification.Items.Add("Food");
            comboBox_Item_Classification.Items.Add("Drink");
            comboBox_Item_Classification.Items.Add("Daily Supplies");
            comboBox_Item_Classification.Items.Add("Other Products");
        }
        #endregion

        #region Exit Dialog
        private void button_Item_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Add Item
        private void button_Item_Add_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Item_Brand.Text == "" || textBox_Item_Code.Text == "" || textBox_Item_Name.Text == "" || textBox_Item_Number.Text == "" || textBox_Item_Origin.Text == "")
            {
                MessageBox.Show("Item Name, Item Code, Brand, Number or Origin can't be null!", "Add new item failed!");
            }
            else
            {
                item.Brand = textBox_Item_Brand.Text;
                item.Classification = comboBox_Item_Classification.Text;
                item.Name = textBox_Item_Name.Text;
                item.Number = int.Parse(textBox_Item_Number.Text);
                item.Code = int.Parse(textBox_Item_Code.Text);
                item.Origin = textBox_Item_Origin.Text;
                item.Specification = textBox_Item_Specification.Text;
                //item.Photo = image_Item_Photo.

                try
                {
                    if (IM.add_Item(item) > 0)
                    {
                        MessageBox.Show("Successfully add a new item!", "Success");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Woops! It seems this item ID is already existed!");
                }
            }          
        }
        #endregion

        #region Image Selection
        private void button_Item_Photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a picture of this item";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                image_Item_Photo.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
        #endregion
    }
}
