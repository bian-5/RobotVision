using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 手写识别
{
    public static class WinApi
    {
        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern int SendMessage(
             int hwnd,
             int wMsg,
             int wParam,
             int lParam);
        [DllImport("user32.dll", EntryPoint = "PostMessageW")]
        public static extern int PostMessage(
             int hwnd,
             int wMsg,
             int wParam,
             int lParam);
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetFocus();
        [DllImport("user32.dll")]
        public static extern int AttachThreadInput(
             int idAttach,
             int idAttachTo,
             int fAttach);
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(
             int hwnd,
             int lpdwProcessId);
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
        public const int WM_MOUSEACTIVATE = 0x21;
        public const int WM_KEYDOWN = 0x100;
        public const int MA_NOACTIVATE = 3;
        public const int WS_EX_NOACTIVATE = 0x8000000;
    }

}
