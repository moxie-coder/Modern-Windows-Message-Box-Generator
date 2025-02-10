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

            TaskDialogIcon mainIcon = TaskDialogIcon.None;

            if ( rbIconNone.Checked ) mainIcon = TaskDialogIcon.None;
            else if ( rbIconInformation.Checked ) mainIcon = TaskDialogIcon.Information;
            else if ( rbIconWarning.Checked ) mainIcon   = TaskDialogIcon.Warning;
            else if ( rbIconError.Checked ) mainIcon = TaskDialogIcon.Error;
            else if ( rbIconShield.Checked ) mainIcon = TaskDialogIcon.Shield;
            else if ( rbIconShieldBlueBar.Checked ) mainIcon = TaskDialogIcon.ShieldBlueBar;
            else if ( rbIconShieldGrayBar.Checked ) mainIcon = TaskDialogIcon.ShieldGrayBar;
            else if ( rbIconShieldWarningYellowBar.Checked ) mainIcon = TaskDialogIcon.ShieldWarningYellowBar;
            else if ( rbIconShieldErrorRedBar.Checked ) mainIcon = TaskDialogIcon.ShieldErrorRedBar;
            else if ( rbIconShieldSuccessGreenBar.Checked ) mainIcon = TaskDialogIcon.ShieldSuccessGreenBar;
            else if ( rbIconCustom.Checked )
            {
                TaskDialogIcon? customIcon = GetCustomIconFromPath();

                if ( customIcon != null )
                    mainIcon = customIcon;
                else
                    return;
            }

            TaskDialogIcon? initialIcon = null;
            int? mainIconInt = null;

            if ( rbBarColorNone.Checked )
            {
                initialIcon = null;
                page.Icon = mainIcon;
            }
            else
            {
                if ( rbBarColorGreen.Checked )
                    initialIcon = TaskDialogIcon.ShieldSuccessGreenBar;
                else if ( rbBarColorBlue.Checked )
                    initialIcon = TaskDialogIcon.ShieldBlueBar;
                else if ( rbBarColorGray.Checked )
                    initialIcon = TaskDialogIcon.ShieldGrayBar;
                else if ( rbBarColorRed.Checked )
                    initialIcon = TaskDialogIcon.ShieldErrorRedBar;
                else if ( rbBarColorYellow.Checked )
                    initialIcon = TaskDialogIcon.ShieldWarningYellowBar;
                else
                    initialIcon = null;

                // Use the initial icon for the main icon to get the colored bar
                page.Icon = initialIcon;

                // Then define what we will change the icon to when the dialog is shown after we get the colored bar to show
                mainIconInt = DetermineMainIconInt();
            }
            

            if ( initialIcon != null )
            {
                // Show the Task Dialog and get the result (as DialogResult)
                //TaskDialogButton result = TaskDialog.ShowDialog(page);
                page.Created += (sender, args) =>
                {
                    // This is called when the dialog is shown
                    // You can update the dialog here
                    TaskDialogPage? dialogPage = sender as TaskDialogPage;
                    TaskDialog? dialog = dialogPage?.BoundDialog;

                    if ( dialog != null )
                    {
                        IntPtr hwnd = dialog.Handle;
                        SendMessage(hwnd, (int)WinEnums.TDM.UPDATE_ICON, IntPtr.Zero, new IntPtr((int)mainIconInt));
                    }
                };
            }

            TaskDialogButton result = TaskDialog.ShowDialog(page);

            // Example of how to use the result
            if ( page.Verification is not null && page.Verification.Checked )
            {
                // The user checked the verification checkbox.  Store this preference!
                // (e.g., in application settings, a config file, etc.)
                Console.WriteLine("Verification was checked!"); // Replace with your persistence logic
            }
        }

        private int DetermineMainIconInt()
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
            else
                return 0;
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

        private void rbIconCustom_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the enabled state of the custom icon path text box and browse button
            groupBoxCustomIcon.Enabled = rbIconCustom.Checked;
            groupBoxBarColor.Enabled = !rbIconCustom.Checked;

            if ( rbIconCustom.Checked )
            {
                // If the custom icon is selected, disable the bar color options
                rbBarColorNone.Checked = true;
            }
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