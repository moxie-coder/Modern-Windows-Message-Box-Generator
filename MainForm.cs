using System;
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
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            var page = new TaskDialogPage()
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

            if ( rbIconNone.Checked ) page.Icon = TaskDialogIcon.None;
            else if ( rbIconInformation.Checked ) page.Icon = TaskDialogIcon.Information;
            else if ( rbIconWarning.Checked ) page.Icon = TaskDialogIcon.Warning;
            else if ( rbIconError.Checked ) page.Icon = TaskDialogIcon.Error;
            else if ( rbIconShield.Checked ) page.Icon = TaskDialogIcon.Shield;
            else if ( rbIconShieldBlueBar.Checked ) page.Icon = TaskDialogIcon.ShieldBlueBar;
            else if ( rbIconShieldGrayBar.Checked ) page.Icon = TaskDialogIcon.ShieldGrayBar;
            else if ( rbIconShieldWarningYellowBar.Checked ) page.Icon = TaskDialogIcon.ShieldWarningYellowBar;
            else if ( rbIconShieldErrorRedBar.Checked ) page.Icon = TaskDialogIcon.ShieldErrorRedBar;
            else if ( rbIconShieldSuccessGreenBar.Checked ) page.Icon = TaskDialogIcon.ShieldSuccessGreenBar;
            if ( rbIconCustom.Checked )
            {
                TaskDialogIcon? customIcon = GetCustomIconFromPath();

                if ( customIcon != null )
                    page.Icon = customIcon;
                else
                    return;
            }

            // Show the Task Dialog and get the result (as DialogResult)
            TaskDialogButton result = TaskDialog.ShowDialog(page);  // Use DialogResult

            // Example of how to use the result
            if ( page.Verification is not null && page.Verification.Checked )
            {
                // The user checked the verification checkbox.  Store this preference!
                // (e.g., in application settings, a config file, etc.)
                Console.WriteLine("Verification was checked!"); // Replace with your persistence logic
            }

            // Using if/else instead of a switch case because that doesn't work
            // The TaskDialogButton properties are getters and therefore not constant, so they can't be used in a switch case
            // And the TaskDialogButton enum values it gets are not accessible so we can't use that either in a switch case
            if ( result == TaskDialogButton.Cancel )
            {
                Console.WriteLine("Cancel was clicked");
            }
            else if ( result == TaskDialogButton.OK )
            {
                Console.WriteLine("OK was clicked");
            }
            else if ( result == TaskDialogButton.Cancel )
            {
                Console.WriteLine("Cancel was clicked");
            }
            else if ( result == TaskDialogButton.Abort )
            {
                Console.WriteLine("Abort was clicked");
            }
            else if ( result == TaskDialogButton.Retry )
            {
                Console.WriteLine("Retry was clicked");
            }
            else if ( result == TaskDialogButton.Ignore )
            {
                Console.WriteLine("Ignore was clicked");
            }
            else if ( result == TaskDialogButton.Yes )
            {
                Console.WriteLine("Yes was clicked");
            }
            else if ( result == TaskDialogButton.No )
            {
                Console.WriteLine("No was clicked");
            }
        }

        private void buttonBrowseCustomIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff)|*.ico;*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tiff|Icon files (*.ico)|*.ico|All files (*.*)|*.*";
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
            // If it's another image type, try to convert to bitmap
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
        }
    }
}