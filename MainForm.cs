using System.Reflection;
using System.Runtime.InteropServices;

#nullable enable
#pragma warning disable IDE1006

namespace Windows_Task_Dialog_Generator
{
    public partial class MainForm : Form
    {
        [LibraryImport("user32.dll", EntryPoint = "SendMessageW")]
        private static partial IntPtr SendMessage(IntPtr hWnd, uint Msg, UIntPtr wParam, IntPtr lParam);

        public static string VERSION = "Error getting version";

        public MainForm()
        {
            InitializeComponent();

            VERSION = DetermineVersion();
            labelVersion.Text = "Version: " + VERSION;

            #if DEBUG
            buttonTest.Visible = true;
            #endif

            // Attach event handler to all radio buttons in the gbIcon group to enable/disable necessary controls when the radio button selection changes
            foreach ( Control control in flowIconSelect.Controls )
            {
                if ( control is RadioButton rb )
                {
                    rb.CheckedChanged += EnableDisableNecessaryControls;
                }
            }

            // Don't allow resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            CreateAndShowDialog();
        }

        private string DetermineVersion()
        {
            string version = string.Empty;
            version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown Version";

            // If the last digit is zero, remove it
            if ( version.EndsWith(".0") )
            {
                version = version.Substring(0, version.Length - 2);
            }

            return version;
        }

        private TaskDialogPage AssembleTaskDialogPage()
        {
            string captionText = txtTitle.Text;
            if ( string.IsNullOrEmpty(captionText) )
            {
                captionText = " "; // Add a single space to prevent it from defaulting to the executable file name
            }

            TaskDialogPage page = new TaskDialogPage()
            {
                Caption = captionText,
                Heading = txtHeading.Text,
                Text = txtMessage.Text,
                Footnote = new TaskDialogFootnote() { Text = txtFooter.Text },
                AllowCancel = true,
            };

            if ( !string.IsNullOrEmpty(txtExpandedInfo.Text) )
            {
                page.Expander = new TaskDialogExpander()
                {
                    Text = txtExpandedInfo.Text,
                    CollapsedButtonText = "Show details",
                    ExpandedButtonText = "Hide details",
                    Position = TaskDialogExpanderPosition.AfterFootnote
                };
            }

            if ( chkVerification.Checked )
            {
                page.Verification = new TaskDialogVerificationCheckBox()
                {
                    Text = textBoxVerification.Text,
                    Checked = false
                };
            }

            page.Buttons.Clear();
            if ( rbOk.Checked ) page.Buttons.Add(TaskDialogButton.OK);
            else if ( rbOkCancel.Checked )
            {
                page.Buttons.Add(TaskDialogButton.OK);
                page.Buttons.Add(TaskDialogButton.Cancel);
            }
            else if ( rbYesNo.Checked )
            {
                page.Buttons.Add(TaskDialogButton.Yes);
                page.Buttons.Add(TaskDialogButton.No);
            }
            else if ( rbYesNoCancel.Checked )
            {
                page.Buttons.Add(TaskDialogButton.Yes);
                page.Buttons.Add(TaskDialogButton.No);
                page.Buttons.Add(TaskDialogButton.Cancel);
            }
            else if ( rbAbortRetryIgnore.Checked )
            {
                TaskDialogButton abortButton = new TaskDialogButton("Abort");
                TaskDialogButton retryButton = new TaskDialogButton("Retry");
                TaskDialogButton ignoreButton = new TaskDialogButton("Ignore");

                page.Buttons.Add(abortButton);
                page.Buttons.Add(retryButton);
                page.Buttons.Add(ignoreButton);
            }
            else if ( rbRetryCancel.Checked )
            {
                page.Buttons.Add(TaskDialogButton.Retry);
                page.Buttons.Add(TaskDialogButton.Cancel);
            }

            return page;
        }

        private void CreateAndShowDialog()
        {
            // Create the initial dialog page by adding buttons, but not yet setting the icon
            TaskDialogPage page = AssembleTaskDialogPage();

            TaskDialogIcon chosenIcon;
            if ( rbIconCustomFile.Checked )
            {
                TaskDialogIcon? customIcon = GetCustomIconFromPath();

                if ( customIcon != null )
                    chosenIcon = customIcon;
                else
                    return; // If error / invalid custom icon, return without showing the dialog
            }
            else if ( rbIconCustomID.Checked )
            {
                TaskDialogIcon? extractedIcon = GetCustomIconObjectFromID();

                if ( extractedIcon == null )
                    return; // If error / invalid custom icon, return without showing the dialog. Error will have been shown in GetCustomIconObjectFromID()
                else
                    chosenIcon = extractedIcon;
            }
            else
            {
                chosenIcon = DetermineChosenIconFromSelection();

                if (chosenIcon == TaskDialogIcon.None )
                {
                    page.Created += RemoveTitlebarIcon_OnCreated; // It will add a default icon to the title bar if none is selected, so we need to remove it
                }
            }

            // Directly set the icon if we don't need to specify a custom color bar
            if ( rbBarColorDefault.Checked )
            {
                page.Icon = chosenIcon;
            }
            // Otherwise we'll set the icon after the dialog is created, after creating it with the temporary color bar icon
            else
            {
                page = SetupIconUpdate(page);
            }

            page.Created += RemoveTitlebarIcon_OnCreated; // TESTING

            // Shows the actual dialog. Returns the button that was pressed
            TaskDialog.ShowDialog(page);
        }

        private TaskDialogPage SetupIconUpdate(TaskDialogPage page)
        {
            TaskDialogIcon temporaryColorBarIcon;

            if ( rbBarColorGreen.Checked )
                temporaryColorBarIcon = TaskDialogIcon.ShieldSuccessGreenBar;
            else if ( rbBarColorBlue.Checked )
                temporaryColorBarIcon = TaskDialogIcon.ShieldBlueBar;
            else if ( rbBarColorGray.Checked )
                temporaryColorBarIcon = TaskDialogIcon.ShieldGrayBar;
            else if ( rbBarColorRed.Checked )
                temporaryColorBarIcon = TaskDialogIcon.ShieldErrorRedBar;
            else if ( rbBarColorYellow.Checked )
                temporaryColorBarIcon = TaskDialogIcon.ShieldWarningYellowBar;
            else if ( rbBarColorNone.Checked )
                temporaryColorBarIcon = TaskDialogIcon.None;
            else
                temporaryColorBarIcon = TaskDialogIcon.None; // This should not happen since the radio buttons are mutually exclusive, but just in case

            // Use the temporary initial icon for the main icon to get the colored bar, then change it to the chosen icon after the dialog is created with SendMessage
            page.Icon = temporaryColorBarIcon;

            int chosenIconInt = DetermineChosenIconFromSelection_Int();

            // This will fire after the dialog is created
            page.Created += (sender, e) => UpdateIcon_OnCreated(sender, chosenIconInt);

            return page;
        }

        private static void RemoveTitlebarIcon_OnCreated(object? sender, EventArgs e)
        {
            TaskDialogPage? dialogPage = sender as TaskDialogPage;
            TaskDialog? dialog = dialogPage?.BoundDialog;
            if ( dialog != null )
            {
                IntPtr hwnd = dialog.Handle;
                try
                {
                    // Set the window title icon to null
                    SendMessage(hwnd, (uint)WM.WM_SETICON, (UIntPtr)WPARAM.ICON_BIG, IntPtr.Zero);
                    SendMessage(hwnd, (uint)WM.WM_SETICON, (UIntPtr)WPARAM.ICON_SMALL, IntPtr.Zero);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Error removing icon: " + ex.Message);
                }
            }
        }

        private static void UpdateIcon_OnCreated(object? sender, int chosenIconID)
        {
            TaskDialogPage? dialogPage = sender as TaskDialogPage;
            TaskDialog? dialog = dialogPage?.BoundDialog;
            if ( dialog != null )
            {
                IntPtr hwnd = dialog.Handle;
                try
                {
                    // We can update the icon using a SendMessage call. But we must specify the icon via ID, not an object or hIcon handle
                    // We do NOT use the negative of the ID, since the API is doing other stuff with the ID and handles it automatically
                    SendMessage(hwnd, (uint)TDM.UPDATE_ICON, UIntPtr.Zero, new IntPtr(chosenIconID));
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Error updating icon: " + ex.Message);
                }

            }
        }

        private int? ParseAndValidateCustomID()
        {
            int id;
            try
            {
                id = int.Parse(textBoxCustomIconMainID.Text);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Invalid icon ID. Please enter a valid integer. Error: \n\n" + ex);
                return null;
            }

            // Ensure the absolute value of the ID is within the valid range, since it can be negative
            if ( id < 0 || id > ushort.MaxValue )
            {
                MessageBox.Show("Invalid icon ID. Valid values are from 0 to 65535.");
                return null;
            }

            return id;
        }

        private TaskDialogIcon? GetCustomIconObjectFromID()
        {
            int? parsedID = ParseAndValidateCustomID();
            int id;

            if ( parsedID == null )
                return null;
            else
                id = (int)parsedID;

            // Get System.Drawing.Icon from the imageres.dll file of the given ID, then convert to TaskDialogIcon
            TaskDialogIcon extractedIcon;

            if ( id < 0 || id > ushort.MaxValue )
            {
                MessageBox.Show("Invalid icon ID. Valid values are from 0 to 65535.");
                return null;
            }
            else
            {
                string winPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
                string imageresPath = Path.Combine(winPath, "imageres.dll");

                // When extracting icons from imageres.dll, we need to use the negative of the ID
                Icon? imageresIcon = System.Drawing.Icon.ExtractIcon(imageresPath, -1 * id);

                if ( imageresIcon != null )
                {
                    extractedIcon = new TaskDialogIcon(imageresIcon);
                }
                else
                {
                    MessageBox.Show($"No icon found in imageres.dll with ID {id}");
                    return null;
                }

                if ( extractedIcon != null )
                {
                    return extractedIcon;
                }
                else
                {
                    MessageBox.Show("Error loading icon.");
                    return null;
                }
            }
        }

        private static Image? GetIconImageFromImageRes(int id, int size)
        {
            string winPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            string imageresPath = Path.Combine(winPath, "imageres.dll");
            try
            {
                return Icon.ExtractIcon(imageresPath, -1 * id, size).ToBitmap(); // Negative ID to extract from imageres.dll
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading icon: " + ex.Message);
                return null;
            }
        }

        // Set the icons on the radio buttons to the actual icons
        private void SetRadioIcons()
        {
            // Get display DPI
            float dpiX = CreateGraphics().DpiX;
            float dpiScale = dpiX / 96f;


            // Icon IDs aren't necessarily the same as the enum values, so we need to get the actual icon from the imageres.dll file
            List<(RadioButton, int)> radioButtonsWithIcons =
            [
                (rbIconInformation,            81),
                (rbIconWarning,                84),
                (rbIconError,                  98),
                (rbIconShield,                 78),
                (rbIconShieldBlueBar,          78),
                (rbIconShieldGrayBar,          78),
                (rbIconShieldWarningYellowBar, 107),
                (rbIconShieldErrorRedBar,      105),
                (rbIconShieldSuccessGreenBar,  106)
            ];

            foreach ( (RadioButton? radioButton, int iconID) in radioButtonsWithIcons )
            {
                int ScaledSize = (int)((16) * dpiScale);
                radioButton.Image = GetIconImageFromImageRes(iconID, ScaledSize);
                radioButton.ImageAlign = ContentAlignment.MiddleLeft;
                radioButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetRadioIcons();
        }

        private TaskDialogIcon DetermineChosenIconFromSelection()
        {
            TaskDialogIcon chosenIcon = TaskDialogIcon.None;

            if ( rbIconNone.Checked ) chosenIcon = TaskDialogIcon.None;
            else if ( rbIconInformation.Checked ) chosenIcon = TaskDialogIcon.Information;
            else if ( rbIconWarning.Checked ) chosenIcon = TaskDialogIcon.Warning;
            else if ( rbIconError.Checked ) chosenIcon = TaskDialogIcon.Error;
            else if ( rbIconShield.Checked ) chosenIcon = TaskDialogIcon.Shield;
            else if ( rbIconShieldBlueBar.Checked ) chosenIcon = TaskDialogIcon.ShieldBlueBar;
            else if ( rbIconShieldGrayBar.Checked ) chosenIcon = TaskDialogIcon.ShieldGrayBar;
            else if ( rbIconShieldWarningYellowBar.Checked ) chosenIcon = TaskDialogIcon.ShieldWarningYellowBar;
            else if ( rbIconShieldErrorRedBar.Checked ) chosenIcon = TaskDialogIcon.ShieldErrorRedBar;
            else if ( rbIconShieldSuccessGreenBar.Checked ) chosenIcon = TaskDialogIcon.ShieldSuccessGreenBar;

            return chosenIcon;
        }

        private int DetermineChosenIconFromSelection_Int()
        {
            if ( rbIconWarning.Checked )
                return (int)StandardIcons.Warning;
            else if ( rbIconError.Checked )
                return (int)StandardIcons.Error;
            else if ( rbIconInformation.Checked )
                return (int)StandardIcons.Information;
            else if ( rbIconShield.Checked )
                return (int)StandardIcons.Shield;
            else if ( rbIconShieldBlueBar.Checked )
                return (int)ShieldIcons.BlueBar;
            else if ( rbIconShieldGrayBar.Checked )
                return (int)ShieldIcons.GrayBar;
            else if ( rbIconShieldWarningYellowBar.Checked )
                return (int)ShieldIcons.YellowBar;
            else if ( rbIconShieldErrorRedBar.Checked )
                return (int)ShieldIcons.RedBar;
            else if ( rbIconShieldSuccessGreenBar.Checked )
                return (int)ShieldIcons.GreenBar;

            // For custom icon ID
            else if ( rbIconCustomID.Checked )
            {
                int? parsedID = ParseAndValidateCustomID();
                if ( parsedID == null )
                    return 0;
                else
                    return (int)parsedID;
            }

            else
                return (int)StandardIcons.None;
        }

        private void buttonBrowseCustomIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff)|*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff|Icon files (*.ico)|*.ico|Icon From Exe (*.exe)|*.exe|All files (*.*)|*.*"
            };

            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                textBoxCustomIconMainPath.Text = openFileDialog.FileName;
            }
        }

        private TaskDialogIcon? GetCustomIconFromPath()
        {
            String filePath = textBoxCustomIconMainPath.Text;

            // Strip quotes if present
            filePath = filePath.Trim('"');

            // Get the file path from the text box, and get info about the file type
            if ( string.IsNullOrEmpty(filePath) )
            {
                MessageBox.Show("No custom icon path specified.");
                return null;
            }
            if ( !File.Exists(filePath) )
            {
                MessageBox.Show("Custom icon path does not exist.");
                return null;
            }

            Icon? icon;
            TaskDialogIcon taskDialogIcon;

            // If it's an icon file, we can use it directly
            if ( Path.GetExtension(filePath).Equals(".ico", StringComparison.CurrentCultureIgnoreCase) )
            {
                try
                {
                    icon = new Icon(filePath);
                    taskDialogIcon = new TaskDialogIcon(icon);
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Error loading icon: " + ex.Message);
                    return null;
                }
            }
            // If it's an EXE, try to load the main icon
            else if ( Path.GetExtension(filePath).Equals(".exe", StringComparison.CurrentCultureIgnoreCase) )
            {
                try
                {
                    icon = Icon.ExtractAssociatedIcon(filePath);
                    if ( icon != null )
                    {
                        taskDialogIcon = new TaskDialogIcon(icon);
                    }
                    else
                    {
                        MessageBox.Show("Error loading icon: No icon found in EXE");
                        return null;
                    }

                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Error loading icon: " + ex.Message);
                    return null;
                }
            }

            // If it's another image type or file, try to convert to bitmap
            else
            {
                try
                {
                    using Image img = Image.FromFile(filePath);
                    if ( img is Bitmap bitmap )
                    {
                        taskDialogIcon = new TaskDialogIcon(bitmap);
                    }
                    else
                    {
                        MessageBox.Show("Unsupported image format.");
                        return null;
                    }
                }
                catch ( OutOfMemoryException )
                {
                    MessageBox.Show("The file is not a valid image. Must be one of the following: ICO, BMP, GIF, JPG, PNG or TIFF");
                    return null;
                }
                catch ( Exception ex )
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                    return null;
                }
            }

            return taskDialogIcon;
        }

        public void SetCustomID(int id)
        {
            textBoxCustomIconMainID.Text = id.ToString();
        }

        private void EnableDisableNecessaryControls(object? sender, EventArgs e)
        {
            groupBoxCustomIconMainFile.Enabled = rbIconCustomFile.Checked; // Enable the custom file path group box if the custom file radio button is checked
            groupBoxBarColor.Enabled = !rbIconCustomFile.Checked; // We cannot use bar colors with custom icons from a file, only an imageRes.dll ID
            groupBoxCustomIconMainID.Enabled = rbIconCustomID.Checked; // Custom ID and custom file are mutually exclusive

            if ( rbIconCustomFile.Checked )
            {
                // If the custom icon is selected, disable the bar color options
                rbBarColorDefault.Checked = true;
            }
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            //CustomTaskDialog.Test();
            //TaskDialogIconExtractor.GetShieldSuccessGreenBarIcon();
            //TaskDialogIcon test = TaskDialogIcon.ShieldSuccessGreenBar;'
            //TaskDialogStandardIcon testIcon = TaskDialogStandardIcon.ShieldSuccessGreenBar;

            //bool testVar = true;
        }

        private void buttonImageResIcons_Click(object sender, EventArgs e)
        {
            // Check if the form is already open or already created
            foreach ( Form form in Application.OpenForms )
            {
                if ( form is Imageres_Icons )
                {
                    form.Show();
                    form.BringToFront();
                    return;
                }
            }

            // Open the Imageres_Icons form
            Imageres_Icons imageresIcons = new Imageres_Icons(this);
            imageresIcons.Show();
        }
    }
}
