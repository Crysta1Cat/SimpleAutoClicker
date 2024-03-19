using SimpleAutoClicker.Core.WinApi;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace SimpleAutoClicker.Core
{
    public class KeyboardHook : IDisposable
    {
        private IntPtr globalKeyboardHookId;
        private IntPtr currentModuleId;
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private User32.LowLevelHook HookKeyboardDelegate;
        private GCHandle HookKeyboardDelegateRef;
        private Action<string> keyPressedCallback;

        public KeyboardHook()
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            this.currentModuleId = User32.GetModuleHandle(currentModule.ModuleName);
        }

        public void CreateKeyboardHook(ref Action<string> keyPressedCallback)
        {
            this.keyPressedCallback = keyPressedCallback;
            HookKeyboardDelegate = HookKeyboardCallbackImplementation;
            HookKeyboardDelegateRef = GCHandle.Alloc(HookKeyboardDelegate);
            globalKeyboardHookId = User32.SetWindowsHookEx(WH_KEYBOARD_LL, HookKeyboardDelegate, currentModuleId, 0);
        }

        private IntPtr HookKeyboardCallbackImplementation(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var keyValue = (KeyCode)Marshal.ReadInt32(lParam);
            if (keyValue == KeyCode.LControlKey) { return User32.CallNextHookEx(globalKeyboardHookId, nCode, wParam, lParam); }
            bool ctrl = false;
            if (User32.GetAsyncKeyState(KeyCode.LControlKey) != 0)
            {
                ctrl = true;
            }
            if (ctrl)
            {
                KeyParser($"key ctrl+{keyValue} wParam {wParam.ToString()} lParam {lParam.ToString()}");
            }
            else { KeyParser($"key {keyValue} wParam {wParam.ToString()} lParam {lParam.ToString()}"); }


            
            return User32.CallNextHookEx(globalKeyboardHookId, nCode, wParam, lParam);
        }

        private void KeyParser(string character)
        {
            keyPressedCallback.Invoke(character);
        }

        public void Print()
        {
            Console.WriteLine(HookKeyboardDelegate);
        }

        public void Dispose()
        {
            if (globalKeyboardHookId != IntPtr.Zero)
                User32.UnhookWindowsHookEx(globalKeyboardHookId);
        }
    }
}
