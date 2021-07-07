using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using MainApp.Properties;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace MainApp.Crutches
{
    public class Gson
    {
        public class SettingsRoot
        {
            public bool UseHotkeys { get; set; }
            public bool AllowUseEverywhere { get; set; }
            public Hotkeys[] hotkeys { get; set; }
        }

        public class Hotkeys
        {
            public int Tag { get; set; }
            public Hotkey hotkey { get; set; }
        }

        public class Hotkey
        {
            public int Key { get; set; }
            public int Modifier { get; set; }
            public string Description { get; set; }
        }
    }

    public static partial class Toolz
    {
        public static Gson.SettingsRoot GetSettings(Dictionary<int, Hotkey> _hk, bool u, bool a)
        {
            var hk = new List<Gson.Hotkeys>();
            foreach (KeyValuePair<int, Hotkey> t in _hk)
            {
                hk.Add(new Gson.Hotkeys()
                {
                    Tag = t.Value.Tag,
                    hotkey = new Gson.Hotkey()
                    {
                        Key = (int)t.Value.Key,
                        Description = t.Value.Description,
                        Modifier = (int)t.Value.KeyModifiers
                    }
                });
            }
            var r = new Gson.SettingsRoot()
            {
                UseHotkeys = u,
                AllowUseEverywhere = a,
                hotkeys = hk.ToArray()
            };

            return r;
        }

        public static Gson.SettingsRoot LoadConf(bool defaults)
        {
            var name = "userconf.json";
            if (defaults || !File.Exists(name)) File.WriteAllBytes(name, Resources.defconf);
            var conf = File.ReadAllText(name);

            return JsonConvert.DeserializeObject<Gson.SettingsRoot>(conf);
        }

        public static Dictionary<int, Hotkey> Deserialize(Gson.Hotkeys[] hk)
        {
            Dictionary<int, Crutches.Hotkey> keys = new Dictionary<int, Crutches.Hotkey>();
            foreach (Gson.Hotkeys _hk in hk)
            {
                try 
                {
                
                    keys.Add(GetVirtualKeyCode(_hk.hotkey.Key, _hk.hotkey.Modifier), new Crutches.Hotkey
                        (
                        (Key)_hk.hotkey.Key,
                        (ModifierKeys)_hk.hotkey.Modifier,
                        _hk.hotkey.Description,
                        _hk.Tag
                        ));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return keys;
        }

        public static int GetVirtualKeyCode(Key k, ModifierKeys m)
        {
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey(k);
            var Id = virtualKeyCode + ((int)m * 0x10000);
            return Id;
        }
        public static int GetVirtualKeyCode(int k, int m)
        {
            int virtualKeyCode = KeyInterop.VirtualKeyFromKey((Key)k);
            var Id = virtualKeyCode + (m * 0x10000);
            return Id;
        }

        public static string KeyCodeToUnicode(Key key)
        {
            byte[] keyboardState = new byte[255];
            bool keyboardStateStatus = GetKeyboardState(keyboardState);

            if (!keyboardStateStatus) return "";

            uint virtualKeyCode = (uint)KeyInterop.VirtualKeyFromKey(key);
            uint scanCode = MapVirtualKey(virtualKeyCode, 0);
            IntPtr inputLocaleIdentifier = GetKeyboardLayout(0);

            StringBuilder result = new StringBuilder();
            ToUnicodeEx(virtualKeyCode, scanCode, new byte[255], result, (int)5, (uint)0, inputLocaleIdentifier);

            return result.ToString();
        }
        public static string GetSteamProfileName(string Link)
        {
            WebClient client = new WebClient();
            Stream data = client.OpenRead(Link); //link
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            string[] stringarrray = s.Split('\n');
            Regex regex = new Regex(@"<\w*\s\w*=\""(actual_persona_name)\"">(.*)<\/\w*>");
            foreach (string line in stringarrray)
            {
                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);
                    //Console.WriteLine(line);
                    return match.Groups[2].Value; //result
                }
            }
            data.Close();
            reader.Close();

            return String.Empty;
        }

        public static int ContainsTag(Dictionary<int, Hotkey> _hk, int t)
        {
            foreach (var item  in _hk)
                if (item.Value.Tag == t) return item.Key;

            return -1;
        }

        [DllImport("user32.dll")]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
    }
}
