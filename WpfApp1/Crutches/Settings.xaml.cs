using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Linq;

namespace MainApp.Crutches
{
    public partial class Settings : Window
    {
        public KeyPressedArgs LastKeyPressed;
        public Settings()
        {
            InitializeComponent();
            this.Loaded += Settings_Loaded;
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();
            LastKeyPressed = null;
        }

        private void HotkeyHandler(object sender, KeyEventArgs e)
        {
            if (LastKeyPressed == null) return;
            int Tag = Convert.ToInt32((sender as TextBox).Tag);
            if (e.Key == Key.LeftCtrl) return;
            if (e.Key == Key.LeftShift) return;
            if (e.Key == Key.LeftAlt) return;
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Windows)) return;

            string desc = GetSentence(LastKeyPressed);
            int _key = Toolz.GetVirtualKeyCode(LastKeyPressed.KeyPressed, LastKeyPressed.Modifiers);

            if (!((MainWindow)this.Owner).hotkeys.ContainsKey(_key))
            {
                HotkeyReset(sender, null);
                ((MainWindow)this.Owner).hotkeys.Add(_key, new Hotkey(LastKeyPressed.KeyPressed, LastKeyPressed.Modifiers, desc, Tag));
                (sender as TextBox).Text = desc;
            }
            LastKeyPressed = null;
        }

        public string GetSentence(KeyPressedArgs e)
        {
            string text_ = "";
            if (e.Modifiers.HasFlag(ModifierKeys.Control)) text_ += "CTRL + ";
            if (e.Modifiers.HasFlag(ModifierKeys.Alt)) text_ += "ALT + ";
            if (e.Modifiers.HasFlag(ModifierKeys.Shift)) text_ += "SHIFT + ";
            string keyStr = e.KeyPressed.ToString();
            int keyInt = (int)e.KeyPressed;
            if (e.KeyPressed >= Key.D0 && e.KeyPressed <= Key.D9)
                keyStr = char.ToString((char)(e.KeyPressed - Key.D0 + '0'));
            else if (e.KeyPressed >= Key.A && e.KeyPressed <= Key.Z)
                keyStr = char.ToString((char)(e.KeyPressed - Key.A + 'A'));
            else if ((keyInt >= 84 && keyInt <= 89) || keyInt >= 140)
                keyStr = Toolz.KeyCodeToUnicode(e.KeyPressed);
            text_ += keyStr;

            return text_.ToLowerInvariant();
        }

        public void HotkeyReset(object sender, MouseButtonEventArgs e)
        {
            var tag = Convert.ToInt32((sender as TextBox).Tag);
            var index = Toolz.ContainsTag(((MainWindow)this.Owner).hotkeys, tag);
            if (((MainWindow)this.Owner).hotkeys.ContainsKey(index)) ((MainWindow)this.Owner).hotkeys.Remove(index);
            (sender as TextBox).Text = "";
            (sender as TextBox).Focus();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.IsClosed = true;
        }

        public bool IsClosed { get; private set; }

        private void RestoreDefaults_Click(object sender, RoutedEventArgs e)
        {
            var data = Toolz.LoadConf(true);
            ((MainWindow)this.Owner).AllowUseEverywhere = data.AllowUseEverywhere;
            ((MainWindow)this.Owner).EnableHotkeys = data.UseHotkeys;
            ((MainWindow)Owner).hotkeys = null;
            ((MainWindow)Owner).hotkeys = Toolz.Deserialize(data.hotkeys);
            Update(data.hotkeys);
        }

        private void Update(Gson.Hotkeys[] hk)
        {
            Dispatcher.Invoke(() =>
            {
                AllowUseEverywhereChk.IsChecked = ((MainWindow)this.Owner).AllowUseEverywhere;
                EnableHotkeysChk.IsChecked = ((MainWindow)this.Owner).EnableHotkeys;
                if (hk != null)
                {
                    var dict = hk.ToDictionary(x => x.Tag, x => x.hotkey.Description);
                    
                    foreach (TextBox item in Textboxes1.Children)
                    {
                        if (item is TextBox)
                            item.Text = dict.ContainsKey(Convert.ToInt32(item.Tag)) ? dict[Convert.ToInt32(item.Tag)].ToLowerInvariant() : "";
                    }
                    foreach (TextBox item in Textboxes2.Children)
                    {
                        if (item is TextBox)
                            item.Text = dict.ContainsKey(Convert.ToInt32(item.Tag)) ? dict[Convert.ToInt32(item.Tag)].ToLowerInvariant() : "";
                    }
                }
            });
        }

        private void AllowUseEverywhere_Checked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).AllowUseEverywhere = true;
        }

        private void AllowUseEverywhere_Unchecked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).AllowUseEverywhere = false;
        }

        private void EnableHotkeys_Checked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).EnableHotkeys = true;
        }

        private void EnableHotkeys_Unchecked(object sender, RoutedEventArgs e)
        {
            ((MainWindow)this.Owner).EnableHotkeys = false;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            var r = Toolz.GetSettings(((MainWindow)this.Owner).hotkeys,
            ((MainWindow)this.Owner).EnableHotkeys,
            ((MainWindow)this.Owner).AllowUseEverywhere);
            string json = JsonConvert.SerializeObject(r, Formatting.Indented);
            File.WriteAllText("userconf.json", json);
            base.Close();
            GC.Collect();
        }

        private void LoadSettings()
        {
            var data = Toolz.LoadConf(false);
            ((MainWindow)this.Owner).AllowUseEverywhere = data.AllowUseEverywhere;
            ((MainWindow)this.Owner).EnableHotkeys = data.UseHotkeys;
            ((MainWindow)this.Owner).hotkeys = Toolz.Deserialize(data.hotkeys);
            Update(data.hotkeys);
        }
    }
}
