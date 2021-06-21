using System;
using System.Windows;
using System.Windows.Controls;

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

        public void SetValue(int value)
        {
            try
            {
                var i = GetItemFromId(value);
                if (i != null) this.cmbBonfireList.SelectedItem = i;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        public Bonfire GetItemFromId(int value)
        {
            foreach (Bonfire item in cmbBonfireList.ItemsSource)
                if (item.bonfireID == value.ToString())
                    return item;

            return null;
        }

        private void cmbBonfireList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbBonfireList.SelectedValue.ToString() != null)
                {
                    var s = Int32.Parse(this.cmbBonfireList.SelectedValue.ToString());
                    global_value = s;
                    SoulsMemory.JunkCode.SetLastBonfire(global_value);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }
    }
}
