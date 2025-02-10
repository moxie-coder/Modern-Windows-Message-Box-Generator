using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

#nullable enable

namespace Windows_Task_Dialog_Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            buttonTest.Visible = true;
#endif
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            CreateAndShowDialog();
        }

        private TaskDialogPage AssembleTaskDialogPage()
        {
            TaskDialogPage page = new TaskDialogPage()
            {
                Caption = txtTitle.Text,
                Heading = txtMessage.Text,
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
                    Text = "Don't ask me this again",
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
                var abortButton = new TaskDialogButton("Abort");
                var retryButton = new TaskDialogButton("Retry");
                var ignoreButton = new TaskDialogButton("Ignore");

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

            // Shows the actual dialog. Returns the button that was pressed
            TaskDialogButton result = TaskDialog.ShowDialog(page);
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
            else if (rbBarColorNone.Checked )
                temporaryColorBarIcon = TaskDialogIcon.None;
            else
                temporaryColorBarIcon = TaskDialogIcon.None; // This should not happen since the radio buttons are mutually exclusive, but just in case

            // Use the temporary initial icon for the main icon to get the colored bar, then change it to the chosen icon after the dialog is created with SendMessage
            page.Icon = temporaryColorBarIcon;

            int chosenIconInt = DetermineChosenIconFromSelection_Int();

            // This will fire after the dialog is created
            page.Created += (sender, e) => UpdateIcon_OnCreated(sender, e, chosenIconInt);

            return page;
        }

        private void UpdateIcon_OnCreated(object? sender, EventArgs e, int chosenIconID)
        {
            TaskDialogPage? dialogPage = sender as TaskDialogPage;
            TaskDialog? dialog = dialogPage?.BoundDialog;
            if ( dialog != null )
            {
                IntPtr hwnd = dialog.Handle;
                // We can update the icon using a SendMessage call. But we must specify the icon via ID, not an object or hIcon handle
                SendMessage(hwnd, (int)WinEnums.TDM.UPDATE_ICON, IntPtr.Zero, new IntPtr(chosenIconID));
            }
        }

        private int? ParseAndValidateCustomID()
        {
            int id;
            try
            {
                id = int.Parse(textBoxCustomIconID.Text);
            }
            catch ( Exception ex )
            {
                MessageBox.Show("Invalid icon ID. Please enter a valid integer. Error: \n\n" + ex);
                return null;
            }

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

                Icon? imageresIcon = System.Drawing.Icon.ExtractIcon(imageresPath, id);

                if ( imageresIcon != null )
                    extractedIcon = new TaskDialogIcon(imageresIcon);
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
                return (int)WinEnums.StandardIcons.Warning;
            else if ( rbIconError.Checked )
                return (int)WinEnums.StandardIcons.Error;
            else if ( rbIconInformation.Checked )
                return (int)WinEnums.StandardIcons.Information;
            else if ( rbIconShield.Checked )
                return (int)WinEnums.StandardIcons.Shield;
            else if ( rbIconShieldBlueBar.Checked )
                return (int)WinEnums.ShieldIcons.BlueBar;
            else if ( rbIconShieldGrayBar.Checked )
                return (int)WinEnums.ShieldIcons.GrayBar;
            else if ( rbIconShieldWarningYellowBar.Checked )
                return (int)WinEnums.ShieldIcons.YellowBar;
            else if ( rbIconShieldErrorRedBar.Checked )
                return (int)WinEnums.ShieldIcons.RedBar;
            else if ( rbIconShieldSuccessGreenBar.Checked )
                return (int)WinEnums.ShieldIcons.GreenBar;

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
                return (int)WinEnums.StandardIcons.None;
        }

        private void buttonBrowseCustomIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff)|*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff|Icon files (*.ico)|*.ico|Icon From Exe (*.exe)|*.exe|All files (*.*)|*.*";
            if ( openFileDialog.ShowDialog() == DialogResult.OK )
            {
                textBoxCustomIconPath.Text = openFileDialog.FileName;
            }
        }

        private TaskDialogIcon? GetCustomIconFromPath()
        {
            String filePath = textBoxCustomIconPath.Text;

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
                    using ( Image img = Image.FromFile(filePath) )
                    {
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

        private void EnableDisableNecessaryControls()
        {
            groupBoxCustomIconFile.Enabled = rbIconCustomFile.Checked; // Enable the custom file path group box if the custom file radio button is checked
            groupBoxBarColor.Enabled = !rbIconCustomFile.Checked; // We cannot use bar colors with custom icons from a file, only an imageRes.dll ID
            groupBoxCustomIconID.Enabled = !rbIconCustomFile.Checked; // Custom ID and custom file are mutually exclusive

            if ( rbIconCustomFile.Checked )
            {
                // If the custom icon is selected, disable the bar color options
                rbBarColorDefault.Checked = true;
            }
        }

        private void rbIconCustomFile_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableNecessaryControls();
        }

        private void rbIconCustomID_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableNecessaryControls();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            CustomTaskDialog.Test();
            //TaskDialogIconExtractor.GetShieldSuccessGreenBarIcon();
            //TaskDialogIcon test = TaskDialogIcon.ShieldSuccessGreenBar;'
            //TaskDialogStandardIcon testIcon = TaskDialogStandardIcon.ShieldSuccessGreenBar;

            //bool testVar = true;
        }

        
    }
}