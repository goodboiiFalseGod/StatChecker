using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace MainApp.Crutches
{
    public class LowLevelKeyboardListener
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public event EventHandler<KeyPressedArgs> OnKeyPressed;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        private bool altDown = false;
        private bool shiftDown = false;
        private bool ctrlDown = false;

        public LowLevelKeyboardListener()
        {
            _proc = HookCallback;
        }

        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                Key Code = KeyInterop.KeyFromVirtualKey(Marshal.ReadInt32(lParam));
                switch (Code)
                {
                    case Key.LeftAlt:
                        altDown = true; break;
                    case Key.LeftCtrl:
                        ctrlDown = true; break;
                    case Key.LeftShift:
                        shiftDown = true; break;
                }
                
            }

            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
            {
                Key Code = KeyInterop.KeyFromVirtualKey(Marshal.ReadInt32(lParam));
                switch (Code)
                {
                    case Key.LeftAlt:
                        altDown = false; break;
                    case Key.LeftCtrl:
                        ctrlDown = false; break;
                    case Key.LeftShift:
                        shiftDown = false; break;
                    default:
                        int vkCode = Marshal.ReadInt32(lParam);

                        OnKeyPressed?.Invoke(this, new KeyPressedArgs(KeyInterop.KeyFromVirtualKey(vkCode), GetModifierKeys()));
                        break;
                }

            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private ModifierKeys GetModifierKeys()
        {
            ModifierKeys a = ModifierKeys.None;
            if (ctrlDown) a |= ModifierKeys.Control;
            if (altDown) a |= ModifierKeys.Alt;
            if (shiftDown) a |= ModifierKeys.Shift;
            return a;
        }
    }



    public class KeyPressedArgs : EventArgs
    {
        public Key KeyPressed { get; private set; }
        public ModifierKeys Modifiers { get; private set; }

        public KeyPressedArgs(Key key, ModifierKeys mod)
        {
            KeyPressed = key;
            Modifiers = mod;
        }
    }

    public class Hotkey
    {
        public Key Key { get; private set; }
        public ModifierKeys KeyModifiers { get; set; }
        public string Description { get; set; }
        public int Tag { get; set; }

        public Hotkey(Key k, ModifierKeys m, string d, int t)
        {
            Key = k;
            KeyModifiers = m;
            Description = d;
            Tag = t;
        }
    }
}
