using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;
using System.Windows;
using static System.Windows.Forms.Control;
using System.Windows.Forms;

// A console application does not automatically add a reference to System.Windows.Forms.dll.
//Right-click your project in Solution Explorer and select Add reference...and then find System.Windows.Forms and add it.

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // run F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Winium.Desktop.Driver
        // before test
        [TestMethod]
        public void TestMethod1()
        {
            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = "C:\\Windows\\System32\\notepad.exe";

            WiniumDriver driver = new WiniumDriver(@"F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Winium.Desktop.Driver", options);
            driver.FindElementByName("Безымянный – Блокнот");
            driver.Keyboard.PressKey(OpenQA.Selenium.Keys.Alt);
            Thread.Sleep(500);
            driver.Keyboard.SendKeys("Ф");// RUS keyboard should be turned on
            Thread.Sleep(500);
            driver.Keyboard.ReleaseKey(OpenQA.Selenium.Keys.Alt);
            Thread.Sleep(500);
            driver.Keyboard.SendKeys(OpenQA.Selenium.Keys.Escape);
            driver.Keyboard.SendKeys(OpenQA.Selenium.Keys.Escape);
            driver.FindElementByClassName("Edit").SendKeys("Hello winium!");
            Thread.Sleep(500);
            driver.FindElementById("Close").Click();
            driver.FindElementById("CommandButton_7").Click();
        }
        


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }


        private static List<IntPtr> _results = new List<IntPtr>();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        [DllImport("user32")]
        private static extern bool EnumChildWindows(IntPtr window, EnumWindowsProc callback, int lParam);

        private static bool WindowEnum(IntPtr hWnd, int lParam)
        {
            int processID = 0;
            int threadID = GetWindowThreadProcessId(hWnd, out processID);
            if (threadID == lParam)
            {
                _results.Add(hWnd);
                EnumChildWindows(hWnd, WindowEnum, threadID);
            }
            return true;
        }
        private static IntPtr[] GetWindowHandlesForThread(int threadHandle)
        {
            _results.Clear();
            EnumWindows(WindowEnum, threadHandle);
            return _results.ToArray();
        }

        private static string GetText(IntPtr hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        public const int GWL_ID = -12;
        public const int WM_GETTEXT = 0x000D;

        [DllImport("User32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int index);
        [DllImport("User32.dll")]
        public static extern IntPtr SendDlgItemMessage(IntPtr hWnd, int IDDlgItem, int uMsg, int nMaxCount, StringBuilder lpString);
        [DllImport("User32.dll")]
        public static extern IntPtr GetParent(IntPtr hWnd);
        private static StringBuilder GetEditText(IntPtr hWnd)
        {
            Int32 dwID = GetWindowLong(hWnd, GWL_ID);
            IntPtr hWndParent = GetParent(hWnd);
            StringBuilder title = new StringBuilder(128);
            SendDlgItemMessage(hWndParent, dwID, WM_GETTEXT, 128, title);
            return title;
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

       
        const int WM_GETTEXTLENGTH = 0x000E;


        // In general approach is not valid because dyalog grid is not standard win control and it is too hard to work with it
        // CAM and APL should be closed manually afterwards
        [TestMethod]
        public void TestMethod2()
        {
            Process.Start(@"F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Corporate Actions Manager.url");

            // As CAM screen is sub process of APL it is not main window
            //foreach (Process clsProcess in Process.GetProcesses())
            //{
            //    //if (clsProcess.MainWindowTitle == "SimCorp Dimension [Development] Dev (BOSET5-B)")
            //    {
            //        IntPtr[] windows = GetWindowHandlesForThread(clsProcess.Id);
            //        if (windows != null && windows.Length > 0)
            //            foreach (IntPtr hWnd in windows)
            //                Console.WriteLine("\twindow {0:x} text:{1} caption:{2}",
            //                    hWnd.ToInt32(), GetText(hWnd), GetEditText(hWnd));
            //    }
            //}

            IntPtr handle = IntPtr.Zero;
            bool found = false;
            while (!found)
            {
                foreach (KeyValuePair<IntPtr, string> item in GetOpenWindows())
                {
                    handle = item.Key;
                    string title = item.Value;
                    if (title.StartsWith("Corporate Actions Manager"))
                    {
                        found = true;
                        break;
                    }
                }
                Thread.Sleep(found ? 0 : 4000);
            }

            // CAM should be already started

            DesktopOptions options = new DesktopOptions();
            options.ApplicationPath = @"F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Corporate Actions Manager.url";
            options.DebugConnectToRunningApp = true;// will not launch application it self but start driver
            options.KeyboardSimulator = KeyboardSimulatorType.BasedOnWindowsFormsSendKeysClass;// needed to process SendKeys("{F5}") correctly
            WiniumDriver driver = new WiniumDriver(@"F:\ARB\GitHub\csharppractice\specflow\automate_win_app\winium\Winium.Desktop.Driver", options);

            IWebElement window = driver.FindElementByName("Corporate Actions Manager");
            String curhandle = driver.CurrentWindowHandle;
            window.SendKeys("{F5}");
            Thread.Sleep(500);
            var searchWindow = driver.FindElementByName("Search List - Corporate Actions Manager");
            driver.Keyboard.SendKeys("OLBR CAM");
            Thread.Sleep(500);
            searchWindow.SendKeys("{ENTER}");
            Thread.Sleep(500);
            var tab1=window.FindElement(By.Name("Holdings"));
            Thread.Sleep(500);
            tab1.Click();

            EnumChildWindows(handle, delegate (IntPtr hWnd, int lParam)
            {
                StringBuilder formDetails = new StringBuilder(256);

                StringBuilder ClassName = new StringBuilder(256);
                var nRet = GetClassName(hWnd, ClassName, ClassName.Capacity);

                // Get the size of the string required to hold the window title (including trailing null.) 
                Int32 titleSize = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();

                // If titleSize is 0, there is no title so return an empty string (or null)
                String editText = String.Empty;
                if (titleSize != 0)
                {
                    StringBuilder title = new StringBuilder(titleSize + 1);
                    SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);// expected "Holdings" but got "Holdings - Corporate Actions Manager (OLBR CAM;OLBR)"
                    editText = title.ToString();
                }

                RECT rct = new RECT();
                GetWindowRect(hWnd, ref rct);

                Console.WriteLine($"Control Caption : {editText}: hWnd : {hWnd.ToString()}: Class Name : {ClassName} : Left: {rct.Left} Top: {rct.Top} Right: {rct.Right} Bottom:{rct.Bottom}");
                Trace.WriteLine("Class Name : " + ClassName);
                return true;

            }, 0);
        }

        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
        public static IDictionary<IntPtr, string> GetOpenWindows()
        {
            IntPtr shellWindow = GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();
    }
}
