using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Task_Dialog_Generator
{
    

    public class CustomTaskDialog
    {
        private static readonly System.Windows.Forms.TaskDialogIcon shieldErrorBar = TaskDialogIcon.ShieldErrorRedBar;

        // Win32 Constants
        private const int TD_WARNING_ICON = 65535;
        private const int TD_ERROR_ICON = 65534;
        private const int TD_INFORMATION_ICON = 65533;
        private const int TD_SHIELD_ICON = 65532;

        [Flags]
        public enum TaskDialogFlags : uint
        {
            TDF_ENABLE_HYPERLINKS = 0x0001,
            TDF_USE_HICON_MAIN = 0x0002,
            TDF_USE_HICON_FOOTER = 0x0004,
            TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,
            TDF_SIZE_TO_CONTENT = 0x01000000
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TaskDialogConfig
        {
            public uint cbSize;
            public IntPtr hwndParent;
            public IntPtr hInstance;
            public TaskDialogFlags dwFlags;
            public uint dwCommonButtons;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszWindowTitle;
            public IntPtr hMainIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszMainInstruction;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszContent;
            public uint cButtons;
            public IntPtr pButtons;
            public int nDefaultButton;
            public uint cRadioButtons;
            public IntPtr pRadioButtons;
            public int nDefaultRadioButton;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszVerificationText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszExpandedInformation;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszExpandedControlText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszCollapsedControlText;
            public IntPtr hFooterIcon;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszFooter;
            public IntPtr pfCallback;
            public IntPtr lpCallbackData;
            public uint cxWidth;
        }

        [DllImport("comctl32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern int TaskDialogIndirect(
            ref TaskDialogConfig pTaskConfig,
            out int pnButton,
            out int pnRadioButton,
            out bool pfVerificationFlagChecked);

        public static void ShowCustomTaskDialog(string title, string mainInstruction, string content, Icon customIcon)
        {
            var config = new TaskDialogConfig
            {
                cbSize = (uint)Marshal.SizeOf(typeof(TaskDialogConfig)),
                hwndParent = IntPtr.Zero,
                hInstance = IntPtr.Zero,
                dwFlags = TaskDialogFlags.TDF_USE_HICON_MAIN | TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION | TaskDialogFlags.TDF_SIZE_TO_CONTENT,
                dwCommonButtons = 1, // OK button
                pszWindowTitle = title,
                hMainIcon = customIcon.Handle,  // Use custom icon
                pszMainInstruction = mainInstruction,
                pszContent = content,
                cxWidth = 0
            };

            // We can also set a footer icon with the shield/warning bar style
            config.hFooterIcon = new IntPtr(TD_SHIELD_ICON);  // This gives us the blue bar

            int button;
            int radioButton;
            bool verificationFlag;

            TaskDialogIndirect(ref config, out button, out radioButton, out verificationFlag);
        }

        public static void Test()
        {
            ShowCustomTaskDialog("Test", "This is a test", "This is the content", SystemIcons.Information);
        }

        // Example usage
        public static void ShowExample()
        {
            using ( Icon customIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath) )
            {
                ShowCustomTaskDialog(
                    "Custom Dialog",
                    "This is a custom TaskDialog",
                    "With both a custom icon and a shield bar!",
                    customIcon
                );
            }
        }
    }
}
