namespace Windows_Task_Dialog_Generator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            txtHeading = new TextBox();
            lblTitle = new Label();
            lblHeading = new Label();
            gbButtons = new GroupBox();
            rbRetryCancel = new RadioButton();
            rbAbortRetryIgnore = new RadioButton();
            rbYesNoCancel = new RadioButton();
            rbYesNo = new RadioButton();
            rbOkCancel = new RadioButton();
            rbOk = new RadioButton();
            gbIcon = new GroupBox();
            rbIconCustomID = new RadioButton();
            rbIconCustomFile = new RadioButton();
            rbIconShieldSuccessGreenBar = new RadioButton();
            rbIconShieldWarningYellowBar = new RadioButton();
            rbIconShieldErrorRedBar = new RadioButton();
            rbIconShieldGrayBar = new RadioButton();
            rbIconShieldBlueBar = new RadioButton();
            rbIconError = new RadioButton();
            rbIconShield = new RadioButton();
            rbIconWarning = new RadioButton();
            rbIconInformation = new RadioButton();
            rbIconNone = new RadioButton();
            btnShowDialog = new Button();
            lblFooter = new Label();
            txtFooter = new TextBox();
            chkVerification = new CheckBox();
            lblExpandedInfo = new Label();
            txtExpandedInfo = new TextBox();
            textBoxCustomIconPath = new TextBox();
            buttonBrowseCustomIcon = new Button();
            groupBoxCustomIconFile = new GroupBox();
            buttonTest = new Button();
            groupBoxBarColor = new GroupBox();
            rbBarColorNone = new RadioButton();
            rbBarColorDefault = new RadioButton();
            rbBarColorGreen = new RadioButton();
            rbBarColorRed = new RadioButton();
            rbBarColorYellow = new RadioButton();
            rbBarColorGray = new RadioButton();
            rbBarColorBlue = new RadioButton();
            groupBoxCustomIconID = new GroupBox();
            textBoxCustomIconID = new TextBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            gbButtons.SuspendLayout();
            gbIcon.SuspendLayout();
            groupBoxCustomIconFile.SuspendLayout();
            groupBoxBarColor.SuspendLayout();
            groupBoxCustomIconID.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(17, 52);
            txtTitle.Margin = new Padding(4, 5, 4, 5);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(427, 31);
            txtTitle.TabIndex = 1;
            // 
            // txtHeading
            // 
            txtHeading.Location = new Point(17, 123);
            txtHeading.Margin = new Padding(4, 5, 4, 5);
            txtHeading.Name = "txtHeading";
            txtHeading.Size = new Size(427, 31);
            txtHeading.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(17, 22);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(48, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Location = new Point(17, 93);
            lblHeading.Margin = new Padding(4, 0, 4, 0);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(83, 25);
            lblHeading.TabIndex = 2;
            lblHeading.Text = "Heading:";
            // 
            // gbButtons
            // 
            gbButtons.Controls.Add(rbRetryCancel);
            gbButtons.Controls.Add(rbAbortRetryIgnore);
            gbButtons.Controls.Add(rbYesNoCancel);
            gbButtons.Controls.Add(rbYesNo);
            gbButtons.Controls.Add(rbOkCancel);
            gbButtons.Controls.Add(rbOk);
            gbButtons.Location = new Point(471, 22);
            gbButtons.Margin = new Padding(4, 5, 4, 5);
            gbButtons.Name = "gbButtons";
            gbButtons.Padding = new Padding(4, 5, 4, 5);
            gbButtons.Size = new Size(286, 292);
            gbButtons.TabIndex = 6;
            gbButtons.TabStop = false;
            gbButtons.Text = "Buttons";
            // 
            // rbRetryCancel
            // 
            rbRetryCancel.AutoSize = true;
            rbRetryCancel.Location = new Point(21, 237);
            rbRetryCancel.Margin = new Padding(4, 5, 4, 5);
            rbRetryCancel.Name = "rbRetryCancel";
            rbRetryCancel.Size = new Size(135, 29);
            rbRetryCancel.TabIndex = 5;
            rbRetryCancel.TabStop = true;
            rbRetryCancel.Text = "Retry/Cancel";
            rbRetryCancel.UseVisualStyleBackColor = true;
            // 
            // rbAbortRetryIgnore
            // 
            rbAbortRetryIgnore.AutoSize = true;
            rbAbortRetryIgnore.Location = new Point(21, 195);
            rbAbortRetryIgnore.Margin = new Padding(4, 5, 4, 5);
            rbAbortRetryIgnore.Name = "rbAbortRetryIgnore";
            rbAbortRetryIgnore.Size = new Size(189, 29);
            rbAbortRetryIgnore.TabIndex = 4;
            rbAbortRetryIgnore.TabStop = true;
            rbAbortRetryIgnore.Text = "Abort/Retry/Ignore";
            rbAbortRetryIgnore.UseVisualStyleBackColor = true;
            // 
            // rbYesNoCancel
            // 
            rbYesNoCancel.AutoSize = true;
            rbYesNoCancel.Location = new Point(21, 153);
            rbYesNoCancel.Margin = new Padding(4, 5, 4, 5);
            rbYesNoCancel.Name = "rbYesNoCancel";
            rbYesNoCancel.Size = new Size(151, 29);
            rbYesNoCancel.TabIndex = 3;
            rbYesNoCancel.TabStop = true;
            rbYesNoCancel.Text = "Yes/No/Cancel";
            rbYesNoCancel.UseVisualStyleBackColor = true;
            // 
            // rbYesNo
            // 
            rbYesNo.AutoSize = true;
            rbYesNo.Location = new Point(21, 112);
            rbYesNo.Margin = new Padding(4, 5, 4, 5);
            rbYesNo.Name = "rbYesNo";
            rbYesNo.Size = new Size(93, 29);
            rbYesNo.TabIndex = 2;
            rbYesNo.TabStop = true;
            rbYesNo.Text = "Yes/No";
            rbYesNo.UseVisualStyleBackColor = true;
            // 
            // rbOkCancel
            // 
            rbOkCancel.AutoSize = true;
            rbOkCancel.Location = new Point(21, 70);
            rbOkCancel.Margin = new Padding(4, 5, 4, 5);
            rbOkCancel.Name = "rbOkCancel";
            rbOkCancel.Size = new Size(119, 29);
            rbOkCancel.TabIndex = 1;
            rbOkCancel.TabStop = true;
            rbOkCancel.Text = "OK/Cancel";
            rbOkCancel.UseVisualStyleBackColor = true;
            // 
            // rbOk
            // 
            rbOk.AutoSize = true;
            rbOk.Checked = true;
            rbOk.Location = new Point(21, 28);
            rbOk.Margin = new Padding(4, 5, 4, 5);
            rbOk.Name = "rbOk";
            rbOk.Size = new Size(61, 29);
            rbOk.TabIndex = 0;
            rbOk.TabStop = true;
            rbOk.Text = "OK";
            rbOk.UseVisualStyleBackColor = true;
            // 
            // gbIcon
            // 
            gbIcon.Controls.Add(rbIconCustomID);
            gbIcon.Controls.Add(rbIconCustomFile);
            gbIcon.Controls.Add(rbIconShieldSuccessGreenBar);
            gbIcon.Controls.Add(rbIconShieldWarningYellowBar);
            gbIcon.Controls.Add(rbIconShieldErrorRedBar);
            gbIcon.Controls.Add(rbIconShieldGrayBar);
            gbIcon.Controls.Add(rbIconShieldBlueBar);
            gbIcon.Controls.Add(rbIconError);
            gbIcon.Controls.Add(rbIconShield);
            gbIcon.Controls.Add(rbIconWarning);
            gbIcon.Controls.Add(rbIconInformation);
            gbIcon.Controls.Add(rbIconNone);
            gbIcon.Location = new Point(786, 22);
            gbIcon.Margin = new Padding(4, 5, 4, 5);
            gbIcon.Name = "gbIcon";
            gbIcon.Padding = new Padding(4, 5, 4, 5);
            gbIcon.Size = new Size(321, 437);
            gbIcon.TabIndex = 7;
            gbIcon.TabStop = false;
            gbIcon.Text = "Icon";
            // 
            // rbIconCustomID
            // 
            rbIconCustomID.AutoSize = true;
            rbIconCustomID.Location = new Point(21, 398);
            rbIconCustomID.Margin = new Padding(4, 5, 4, 5);
            rbIconCustomID.Name = "rbIconCustomID";
            rbIconCustomID.Size = new Size(232, 29);
            rbIconCustomID.TabIndex = 11;
            rbIconCustomID.Text = "Custom (imageres.dll ID)";
            rbIconCustomID.UseVisualStyleBackColor = true;
            rbIconCustomID.CheckedChanged += rbIconCustomID_CheckedChanged;
            // 
            // rbIconCustomFile
            // 
            rbIconCustomFile.AutoSize = true;
            rbIconCustomFile.Location = new Point(21, 370);
            rbIconCustomFile.Margin = new Padding(4, 5, 4, 5);
            rbIconCustomFile.Name = "rbIconCustomFile";
            rbIconCustomFile.Size = new Size(140, 29);
            rbIconCustomFile.TabIndex = 10;
            rbIconCustomFile.Text = "Custom (File)";
            rbIconCustomFile.UseVisualStyleBackColor = true;
            rbIconCustomFile.CheckedChanged += rbIconCustomFile_CheckedChanged;
            // 
            // rbIconShieldSuccessGreenBar
            // 
            rbIconShieldSuccessGreenBar.AutoSize = true;
            rbIconShieldSuccessGreenBar.Location = new Point(21, 320);
            rbIconShieldSuccessGreenBar.Margin = new Padding(4, 5, 4, 5);
            rbIconShieldSuccessGreenBar.Name = "rbIconShieldSuccessGreenBar";
            rbIconShieldSuccessGreenBar.Size = new Size(151, 29);
            rbIconShieldSuccessGreenBar.TabIndex = 9;
            rbIconShieldSuccessGreenBar.Text = "Shield Success";
            rbIconShieldSuccessGreenBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldWarningYellowBar
            // 
            rbIconShieldWarningYellowBar.AutoSize = true;
            rbIconShieldWarningYellowBar.Location = new Point(21, 260);
            rbIconShieldWarningYellowBar.Margin = new Padding(4, 5, 4, 5);
            rbIconShieldWarningYellowBar.Name = "rbIconShieldWarningYellowBar";
            rbIconShieldWarningYellowBar.Size = new Size(156, 29);
            rbIconShieldWarningYellowBar.TabIndex = 8;
            rbIconShieldWarningYellowBar.Text = "Shield Warning";
            rbIconShieldWarningYellowBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldErrorRedBar
            // 
            rbIconShieldErrorRedBar.AutoSize = true;
            rbIconShieldErrorRedBar.Location = new Point(21, 290);
            rbIconShieldErrorRedBar.Margin = new Padding(4, 5, 4, 5);
            rbIconShieldErrorRedBar.Name = "rbIconShieldErrorRedBar";
            rbIconShieldErrorRedBar.Size = new Size(128, 29);
            rbIconShieldErrorRedBar.TabIndex = 7;
            rbIconShieldErrorRedBar.Text = "Shield Error";
            rbIconShieldErrorRedBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldGrayBar
            // 
            rbIconShieldGrayBar.AutoSize = true;
            rbIconShieldGrayBar.Location = new Point(21, 230);
            rbIconShieldGrayBar.Margin = new Padding(4, 5, 4, 5);
            rbIconShieldGrayBar.Name = "rbIconShieldGrayBar";
            rbIconShieldGrayBar.Size = new Size(168, 29);
            rbIconShieldGrayBar.TabIndex = 6;
            rbIconShieldGrayBar.Text = "Shield - Gray Bar";
            rbIconShieldGrayBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldBlueBar
            // 
            rbIconShieldBlueBar.AutoSize = true;
            rbIconShieldBlueBar.Location = new Point(21, 200);
            rbIconShieldBlueBar.Margin = new Padding(4, 5, 4, 5);
            rbIconShieldBlueBar.Name = "rbIconShieldBlueBar";
            rbIconShieldBlueBar.Size = new Size(165, 29);
            rbIconShieldBlueBar.TabIndex = 5;
            rbIconShieldBlueBar.Text = "Shield - Blue Bar";
            rbIconShieldBlueBar.UseVisualStyleBackColor = true;
            // 
            // rbIconError
            // 
            rbIconError.AutoSize = true;
            rbIconError.Location = new Point(21, 120);
            rbIconError.Margin = new Padding(4, 5, 4, 5);
            rbIconError.Name = "rbIconError";
            rbIconError.Size = new Size(75, 29);
            rbIconError.TabIndex = 4;
            rbIconError.Text = "Error";
            rbIconError.UseVisualStyleBackColor = true;
            // 
            // rbIconShield
            // 
            rbIconShield.AutoSize = true;
            rbIconShield.Location = new Point(21, 170);
            rbIconShield.Margin = new Padding(4, 5, 4, 5);
            rbIconShield.Name = "rbIconShield";
            rbIconShield.Size = new Size(85, 29);
            rbIconShield.TabIndex = 3;
            rbIconShield.Text = "Shield";
            rbIconShield.UseVisualStyleBackColor = true;
            // 
            // rbIconWarning
            // 
            rbIconWarning.AutoSize = true;
            rbIconWarning.Location = new Point(21, 90);
            rbIconWarning.Margin = new Padding(4, 5, 4, 5);
            rbIconWarning.Name = "rbIconWarning";
            rbIconWarning.Size = new Size(103, 29);
            rbIconWarning.TabIndex = 2;
            rbIconWarning.Text = "Warning";
            rbIconWarning.UseVisualStyleBackColor = true;
            // 
            // rbIconInformation
            // 
            rbIconInformation.AutoSize = true;
            rbIconInformation.Location = new Point(21, 60);
            rbIconInformation.Margin = new Padding(4, 5, 4, 5);
            rbIconInformation.Name = "rbIconInformation";
            rbIconInformation.Size = new Size(131, 29);
            rbIconInformation.TabIndex = 1;
            rbIconInformation.Text = "Information";
            rbIconInformation.UseVisualStyleBackColor = true;
            // 
            // rbIconNone
            // 
            rbIconNone.AutoSize = true;
            rbIconNone.Checked = true;
            rbIconNone.Location = new Point(21, 30);
            rbIconNone.Margin = new Padding(4, 5, 4, 5);
            rbIconNone.Name = "rbIconNone";
            rbIconNone.Size = new Size(80, 29);
            rbIconNone.TabIndex = 0;
            rbIconNone.TabStop = true;
            rbIconNone.Text = "None";
            rbIconNone.UseVisualStyleBackColor = true;
            // 
            // btnShowDialog
            // 
            btnShowDialog.Location = new Point(22, 690);
            btnShowDialog.Margin = new Padding(4, 5, 4, 5);
            btnShowDialog.Name = "btnShowDialog";
            btnShowDialog.Size = new Size(173, 55);
            btnShowDialog.TabIndex = 11;
            btnShowDialog.Text = "Show Dialog";
            btnShowDialog.UseVisualStyleBackColor = true;
            btnShowDialog.Click += btnShowDialog_Click;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(17, 234);
            lblFooter.Margin = new Padding(4, 0, 4, 0);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(68, 25);
            lblFooter.TabIndex = 4;
            lblFooter.Text = "Footer:";
            // 
            // txtFooter
            // 
            txtFooter.Location = new Point(17, 264);
            txtFooter.Margin = new Padding(4, 5, 4, 5);
            txtFooter.Name = "txtFooter";
            txtFooter.Size = new Size(427, 31);
            txtFooter.TabIndex = 5;
            // 
            // chkVerification
            // 
            chkVerification.AutoSize = true;
            chkVerification.Location = new Point(17, 555);
            chkVerification.Margin = new Padding(4, 5, 4, 5);
            chkVerification.Name = "chkVerification";
            chkVerification.Size = new Size(173, 29);
            chkVerification.TabIndex = 10;
            chkVerification.Text = "Show verification";
            chkVerification.UseVisualStyleBackColor = true;
            // 
            // lblExpandedInfo
            // 
            lblExpandedInfo.AutoSize = true;
            lblExpandedInfo.Location = new Point(17, 328);
            lblExpandedInfo.Margin = new Padding(4, 0, 4, 0);
            lblExpandedInfo.Name = "lblExpandedInfo";
            lblExpandedInfo.Size = new Size(189, 25);
            lblExpandedInfo.TabIndex = 8;
            lblExpandedInfo.Text = "Expanded Information";
            // 
            // txtExpandedInfo
            // 
            txtExpandedInfo.Location = new Point(17, 358);
            txtExpandedInfo.Margin = new Padding(4, 5, 4, 5);
            txtExpandedInfo.Multiline = true;
            txtExpandedInfo.Name = "txtExpandedInfo";
            txtExpandedInfo.Size = new Size(427, 187);
            txtExpandedInfo.TabIndex = 9;
            // 
            // textBoxCustomIconPath
            // 
            textBoxCustomIconPath.Location = new Point(17, 39);
            textBoxCustomIconPath.Name = "textBoxCustomIconPath";
            textBoxCustomIconPath.Size = new Size(317, 31);
            textBoxCustomIconPath.TabIndex = 12;
            // 
            // buttonBrowseCustomIcon
            // 
            buttonBrowseCustomIcon.Location = new Point(340, 37);
            buttonBrowseCustomIcon.Name = "buttonBrowseCustomIcon";
            buttonBrowseCustomIcon.Size = new Size(112, 34);
            buttonBrowseCustomIcon.TabIndex = 13;
            buttonBrowseCustomIcon.Text = "Browse";
            buttonBrowseCustomIcon.UseVisualStyleBackColor = true;
            buttonBrowseCustomIcon.Click += buttonBrowseCustomIcon_Click;
            // 
            // groupBoxCustomIconFile
            // 
            groupBoxCustomIconFile.Controls.Add(textBoxCustomIconPath);
            groupBoxCustomIconFile.Controls.Add(buttonBrowseCustomIcon);
            groupBoxCustomIconFile.Enabled = false;
            groupBoxCustomIconFile.Location = new Point(635, 467);
            groupBoxCustomIconFile.Name = "groupBoxCustomIconFile";
            groupBoxCustomIconFile.Size = new Size(472, 89);
            groupBoxCustomIconFile.TabIndex = 14;
            groupBoxCustomIconFile.TabStop = false;
            groupBoxCustomIconFile.Text = "Custom Icon (File)";
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(22, 630);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(112, 34);
            buttonTest.TabIndex = 15;
            buttonTest.Text = "Test";
            buttonTest.UseVisualStyleBackColor = true;
            buttonTest.Visible = false;
            buttonTest.Click += buttonTest_Click;
            // 
            // groupBoxBarColor
            // 
            groupBoxBarColor.Controls.Add(rbBarColorNone);
            groupBoxBarColor.Controls.Add(rbBarColorDefault);
            groupBoxBarColor.Controls.Add(rbBarColorGreen);
            groupBoxBarColor.Controls.Add(rbBarColorRed);
            groupBoxBarColor.Controls.Add(rbBarColorYellow);
            groupBoxBarColor.Controls.Add(rbBarColorGray);
            groupBoxBarColor.Controls.Add(rbBarColorBlue);
            groupBoxBarColor.Location = new Point(633, 572);
            groupBoxBarColor.Name = "groupBoxBarColor";
            groupBoxBarColor.Size = new Size(474, 132);
            groupBoxBarColor.TabIndex = 16;
            groupBoxBarColor.TabStop = false;
            groupBoxBarColor.Text = "Bar Color";
            // 
            // rbBarColorNone
            // 
            rbBarColorNone.AutoSize = true;
            rbBarColorNone.Location = new Point(324, 45);
            rbBarColorNone.Name = "rbBarColorNone";
            rbBarColorNone.Size = new Size(128, 29);
            rbBarColorNone.TabIndex = 6;
            rbBarColorNone.Text = "Force None";
            rbBarColorNone.UseVisualStyleBackColor = true;
            // 
            // rbBarColorDefault
            // 
            rbBarColorDefault.AutoSize = true;
            rbBarColorDefault.Checked = true;
            rbBarColorDefault.Location = new Point(39, 45);
            rbBarColorDefault.Name = "rbBarColorDefault";
            rbBarColorDefault.Size = new Size(94, 29);
            rbBarColorDefault.TabIndex = 5;
            rbBarColorDefault.TabStop = true;
            rbBarColorDefault.Text = "Default";
            rbBarColorDefault.UseVisualStyleBackColor = true;
            // 
            // rbBarColorGreen
            // 
            rbBarColorGreen.AutoSize = true;
            rbBarColorGreen.Location = new Point(138, 45);
            rbBarColorGreen.Name = "rbBarColorGreen";
            rbBarColorGreen.Size = new Size(83, 29);
            rbBarColorGreen.TabIndex = 4;
            rbBarColorGreen.Text = "Green";
            rbBarColorGreen.UseVisualStyleBackColor = true;
            // 
            // rbBarColorRed
            // 
            rbBarColorRed.AutoSize = true;
            rbBarColorRed.Location = new Point(233, 45);
            rbBarColorRed.Name = "rbBarColorRed";
            rbBarColorRed.Size = new Size(67, 29);
            rbBarColorRed.TabIndex = 3;
            rbBarColorRed.Text = "Red";
            rbBarColorRed.UseVisualStyleBackColor = true;
            // 
            // rbBarColorYellow
            // 
            rbBarColorYellow.AutoSize = true;
            rbBarColorYellow.Location = new Point(138, 80);
            rbBarColorYellow.Name = "rbBarColorYellow";
            rbBarColorYellow.Size = new Size(86, 29);
            rbBarColorYellow.TabIndex = 2;
            rbBarColorYellow.Text = "Yellow";
            rbBarColorYellow.UseVisualStyleBackColor = true;
            // 
            // rbBarColorGray
            // 
            rbBarColorGray.AutoSize = true;
            rbBarColorGray.Location = new Point(39, 80);
            rbBarColorGray.Name = "rbBarColorGray";
            rbBarColorGray.Size = new Size(73, 29);
            rbBarColorGray.TabIndex = 1;
            rbBarColorGray.Text = "Gray";
            rbBarColorGray.UseVisualStyleBackColor = true;
            // 
            // rbBarColorBlue
            // 
            rbBarColorBlue.AutoSize = true;
            rbBarColorBlue.Location = new Point(233, 80);
            rbBarColorBlue.Name = "rbBarColorBlue";
            rbBarColorBlue.Size = new Size(70, 29);
            rbBarColorBlue.TabIndex = 0;
            rbBarColorBlue.Text = "Blue";
            rbBarColorBlue.UseVisualStyleBackColor = true;
            // 
            // groupBoxCustomIconID
            // 
            groupBoxCustomIconID.Controls.Add(textBoxCustomIconID);
            groupBoxCustomIconID.Enabled = false;
            groupBoxCustomIconID.Location = new Point(471, 347);
            groupBoxCustomIconID.Name = "groupBoxCustomIconID";
            groupBoxCustomIconID.Size = new Size(183, 102);
            groupBoxCustomIconID.TabIndex = 17;
            groupBoxCustomIconID.TabStop = false;
            groupBoxCustomIconID.Text = "Custom Icon (ID)";
            // 
            // textBoxCustomIconID
            // 
            textBoxCustomIconID.Location = new Point(21, 46);
            textBoxCustomIconID.Name = "textBoxCustomIconID";
            textBoxCustomIconID.Size = new Size(135, 31);
            textBoxCustomIconID.TabIndex = 14;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(17, 160);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(86, 25);
            lblMessage.TabIndex = 18;
            lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(17, 190);
            txtMessage.Margin = new Padding(4, 5, 4, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(427, 31);
            txtMessage.TabIndex = 19;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 768);
            Controls.Add(lblMessage);
            Controls.Add(txtMessage);
            Controls.Add(groupBoxCustomIconID);
            Controls.Add(groupBoxBarColor);
            Controls.Add(buttonTest);
            Controls.Add(groupBoxCustomIconFile);
            Controls.Add(txtExpandedInfo);
            Controls.Add(lblExpandedInfo);
            Controls.Add(chkVerification);
            Controls.Add(txtFooter);
            Controls.Add(lblFooter);
            Controls.Add(btnShowDialog);
            Controls.Add(gbIcon);
            Controls.Add(gbButtons);
            Controls.Add(lblHeading);
            Controls.Add(lblTitle);
            Controls.Add(txtHeading);
            Controls.Add(txtTitle);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Task Dialog Generator";
            gbButtons.ResumeLayout(false);
            gbButtons.PerformLayout();
            gbIcon.ResumeLayout(false);
            gbIcon.PerformLayout();
            groupBoxCustomIconFile.ResumeLayout(false);
            groupBoxCustomIconFile.PerformLayout();
            groupBoxBarColor.ResumeLayout(false);
            groupBoxBarColor.PerformLayout();
            groupBoxCustomIconID.ResumeLayout(false);
            groupBoxCustomIconID.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtHeading;
        private Label lblTitle;
        private Label lblHeading;
        private GroupBox gbButtons;
        private RadioButton rbRetryCancel;
        private RadioButton rbAbortRetryIgnore;
        private RadioButton rbYesNoCancel;
        private RadioButton rbYesNo;
        private RadioButton rbOkCancel;
        private RadioButton rbOk;
        private GroupBox gbIcon;
        private RadioButton rbIconError;
        private RadioButton rbIconShield;
        private RadioButton rbIconWarning;
        private RadioButton rbIconInformation;
        private RadioButton rbIconNone;
        private Button btnShowDialog;
        private Label lblFooter;
        private TextBox txtFooter;
        private CheckBox chkVerification;
        private Label lblExpandedInfo;
        private TextBox txtExpandedInfo;
        private RadioButton rbIconShieldSuccessGreenBar;
        private RadioButton rbIconShieldWarningYellowBar;
        private RadioButton rbIconShieldErrorRedBar;
        private RadioButton rbIconShieldGrayBar;
        private RadioButton rbIconShieldBlueBar;
        private RadioButton rbIconCustomFile;
        private TextBox textBoxCustomIconPath;
        private Button buttonBrowseCustomIcon;
        private GroupBox groupBoxCustomIconFile;
        private Button buttonTest;
        private GroupBox groupBoxBarColor;
        private RadioButton rbBarColorRed;
        private RadioButton rbBarColorYellow;
        private RadioButton rbBarColorGray;
        private RadioButton rbBarColorBlue;
        private RadioButton rbBarColorDefault;
        private RadioButton rbBarColorGreen;
        private RadioButton rbIconCustomID;
        private GroupBox groupBoxCustomIconID;
        private TextBox textBoxCustomIconID;
        private RadioButton rbBarColorNone;
        private Label lblMessage;
        private TextBox txtMessage;
    }
}