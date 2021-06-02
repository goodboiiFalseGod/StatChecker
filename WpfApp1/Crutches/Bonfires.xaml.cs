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

namespace MainApp.Crutches
{
    public partial class Bonfires : Page
    {
        public Bonfires()
        {
            InitializeComponent();
            this.Loaded += Bonfires_Loaded;
        }

        public static int global_value;

        private void Bonfires_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.cmbBonfireList.DisplayMemberPath = "bonfireName";
                this.cmbBonfireList.SelectedValuePath = "bonfireID";
                this.cmbBonfireList.ItemsSource = BonfiresItemList.LoadBonfireList();
                this.cmbBonfireList.Text = "Choose Bonfire";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public static int GetValue()
        {
            return global_value;
        }

        private void cmbBonfireList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                global_value = Int32.Parse(this.cmbBonfireList.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }
    }
}
