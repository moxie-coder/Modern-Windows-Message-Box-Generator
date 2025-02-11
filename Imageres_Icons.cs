using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Windows_Task_Dialog_Generator
{
    public partial class Imageres_Icons : Form
    {
        private MainForm mainForm;
        private FlowLayoutPanel? previousPanelSelection = null;

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        // P/Invoke for EnumResourceNames to enumerate resource names
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool EnumResourceNames(IntPtr hModule, IntPtr lpszType, EnumResNameProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LoadImage(IntPtr hinst, IntPtr lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LockResource(IntPtr hResData);


        // Delegate for EnumResourceNames callback
        private delegate bool EnumResNameProc(IntPtr hModule, IntPtr lpszType, IntPtr lpszName, IntPtr lParam);

        public Imageres_Icons(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            LoadIcons();

            // Ensure the form is hidden instead of closed to avoid having to reload everything
            // Doing this only after all the icons are loaded
            this.FormClosing += OnFormClosing;
        }

        private async void LoadIcons()
        {
            string systemFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string imageresPath = Path.Combine(systemFolder, "imageres.dll");

            IntPtr hModule = LoadLibrary(imageresPath);
            if ( hModule == IntPtr.Zero )
            {
                MessageBox.Show("Failed to load " + imageresPath, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<int> iconGroupIds = new List<int>();
            EnumResourceNames(hModule, new IntPtr(14), (h, t, name, l) =>
            {
                iconGroupIds.Add((int)name);
                return true;
            }, IntPtr.Zero);

            await Task.Run(() =>
            {
                foreach ( int groupId in iconGroupIds )
                {
                    ExtractAndDisplayIcon(hModule, imageresPath, groupId);
                }
            });

            FreeLibrary(hModule);
        }

        private void ExtractAndDisplayIcon(IntPtr hModule, string imageresPath, int groupId)
        {
            IntPtr hResInfo = FindResource(hModule, new IntPtr(groupId), new IntPtr(14)); // RT_GROUP_ICON
            if ( hResInfo == IntPtr.Zero )
                return;

            IntPtr hResData = LoadResource(hModule, hResInfo);
            if ( hResData == IntPtr.Zero )
                return;

            IntPtr hGlobal = LockResource(hResData);
            if ( hGlobal == IntPtr.Zero )
                return;

            // Use LoadImage instead of ExtractIcon
            IntPtr hIcon = LoadImage(hModule, new IntPtr(groupId),
                    1, // IMAGE_ICON
                    0, 0, // Use actual size
                    0x00000040); // LR_DEFAULTSIZE

            if ( hIcon == IntPtr.Zero )
            {
                int error = Marshal.GetLastWin32Error();
                Debug.WriteLine($"LoadImage failed for ID {groupId} with error: {error}");
                return;
            }

            using ( Icon icon = Icon.FromHandle(hIcon) )
            {
                Icon iconCopy = (Icon)icon.Clone();
                DestroyIcon(hIcon);
                Bitmap bitmap = iconCopy.ToBitmap();

                FlowLayoutPanel containerPanel = new FlowLayoutPanel
                {
                    AutoSize = true,
                    Margin = new Padding(4),
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Size = new Size(56, 70),
                    Tag = groupId
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = bitmap,
                    Size = new Size(48, 48),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(0),
                    Tag = groupId
                };

                Label iconLabel = new Label
                {
                    Text = $"{groupId}",
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(0),
                    Width = pictureBox.Width
                };

                pictureBox.Click += IconClickHandler;
                iconLabel.Click += IconClickHandler;

                containerPanel.Controls.Add(pictureBox);
                containerPanel.Controls.Add(iconLabel);

                this.Invoke(() =>
                {
                    flowLayoutPanelMain.Controls.Add(containerPanel);
                });
            }
        }

        private void OnPanelClick(object? sender, EventArgs e, int iconIndex)
        {
            mainForm.SetCustomID(iconIndex);

            // Make the selected thing highlighted, and Unhighlight the previous selection
            if ( previousPanelSelection != null )
            {
                previousPanelSelection.BackColor = Color.Transparent;
            }

            if ( sender is FlowLayoutPanel panel )
            {
                panel.BackColor = Color.LightBlue;
                previousPanelSelection = panel;
            }
        }

        private void IconClickHandler(object? sender, EventArgs e)
        {
            if ( sender is Control control )
            {
                var containerPanel = control as FlowLayoutPanel ?? control.Parent as FlowLayoutPanel;
                if ( containerPanel?.Tag is int iconIndex )
                {
                    OnPanelClick(containerPanel, e, iconIndex);
                }
            }
        }

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        // P/Invoke for LoadLibrary and FreeLibrary
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FreeLibrary(IntPtr hModule);
    }
}
