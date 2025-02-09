using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Windows_Task_Dialog_Generator
{
    public class CustomTaskDialog
    {
        // Win32 Constants for standard icons
        private const int TD_WARNING_ICON = 65535;
        private const int TD_ERROR_ICON = 65534;
        private const int TD_INFORMATION_ICON = 65533;
        private const int TD_SHIELD_ICON = 65532;

        // Constants for shield with bar icons (these are different from the standard shield!)
        private const int TD_SHIELD_BLUE_BAR = ushort.MaxValue - 4;          
        private const int TD_SHIELD_YELLOW_BAR = ushort.MaxValue - 5;        
        private const int TD_SHIELD_RED_BAR = ushort.MaxValue - 6;           
        private const int TD_SHIELD_GREEN_BAR = ushort.MaxValue - 7;         
        private const int TD_SHIELD_GRAY_BAR = ushort.MaxValue - 8;          

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
            // This is a union in the native struct, so we need both fields
            public IntPtr hMainIcon;      // HICON handle when TDF_USE_HICON_MAIN is set
            //public IntPtr pszMainIcon;  // Icon resource ID when TDF_USE_HICON_MAIN is not set
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
            // Another union in the native struct
            public IntPtr hFooterIcon;    // HICON handle when TDF_USE_HICON_FOOTER is set
            //public IntPtr pszFooterIcon; // Icon resource ID when TDF_USE_HICON_FOOTER is not set
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

        public static void ShowCustomTaskDialog(string title, string mainInstruction, string content, int standardIcon)
        {
            var config = new TaskDialogConfig
            {
                cbSize = (uint)Marshal.SizeOf(typeof(TaskDialogConfig)),
                hwndParent = IntPtr.Zero,
                hInstance = IntPtr.Zero,
                // Remove TDF_USE_HICON_MAIN since we're using a resource ID
                dwFlags = TaskDialogFlags.TDF_ALLOW_DIALOG_CANCELLATION | TaskDialogFlags.TDF_SIZE_TO_CONTENT,
                dwCommonButtons = 1, // OK button
                pszWindowTitle = title,
                hMainIcon = new IntPtr(standardIcon),  // Since TDF_USE_HICON_MAIN is not used, this is a resource ID, not truly a pointer
                pszMainInstruction = mainInstruction,
                pszContent = content,
                cxWidth = 0
            };

            int button;
            int radioButton;
            bool verificationFlag;

            TaskDialogIndirect(ref config, out button, out radioButton, out verificationFlag);
        }

        // Test method showing different bar colors
        public static void Test()
        {
            // Test with blue bar
            ShowCustomTaskDialog(
                title: "Blue Bar Test",
                mainInstruction: "Custom Icon with Blue Bar",
                content: "This shows a custom icon with the blue shield bar",
                standardIcon: TD_SHIELD_BLUE_BAR
            );

            // You can also try other colors by changing TD_SHIELD_BLUE_BAR to:
            // TD_SHIELD_YELLOW_BAR - For warning yellow bar
            // TD_SHIELD_RED_BAR - For error red bar
            // TD_SHIELD_GREEN_BAR - For success green bar
            // TD_SHIELD_GRAY_BAR - For gray bar
        }
    }
}