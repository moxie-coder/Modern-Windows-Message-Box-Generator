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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            flowIconSelect = new FlowLayoutPanel();
            rbIconNone = new RadioButton();
            rbIconInformation = new RadioButton();
            rbIconWarning = new RadioButton();
            rbIconShield = new RadioButton();
            rbIconError = new RadioButton();
            rbIconShieldBlueBar = new RadioButton();
            rbIconShieldGrayBar = new RadioButton();
            rbIconShieldErrorRedBar = new RadioButton();
            rbIconShieldWarningYellowBar = new RadioButton();
            rbIconShieldSuccessGreenBar = new RadioButton();
            rbIconCustomFile = new RadioButton();
            rbIconCustomID = new RadioButton();
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
            textBoxVerification = new TextBox();
            buttonImageResIcons = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            labelVersion = new Label();
            gbButtons.SuspendLayout();
            gbIcon.SuspendLayout();
            flowIconSelect.SuspendLayout();
            groupBoxCustomIconFile.SuspendLayout();
            groupBoxBarColor.SuspendLayout();
            groupBoxCustomIconID.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(5, 24);
            txtTitle.Margin = new Padding(5, 2, 5, 5);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(304, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtHeading
            // 
            txtHeading.Location = new Point(5, 76);
            txtHeading.Margin = new Padding(5, 2, 5, 5);
            txtHeading.Name = "txtHeading";
            txtHeading.Size = new Size(304, 23);
            txtHeading.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(5, 5);
            lblTitle.Margin = new Padding(5, 5, 5, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(33, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // lblHeading
            // 
            lblHeading.AutoSize = true;
            lblHeading.Location = new Point(5, 57);
            lblHeading.Margin = new Padding(5, 5, 5, 2);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(55, 15);
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
            gbButtons.Location = new Point(333, 13);
            gbButtons.Name = "gbButtons";
            gbButtons.Size = new Size(223, 175);
            gbButtons.TabIndex = 6;
            gbButtons.TabStop = false;
            gbButtons.Text = "Buttons";
            // 
            // rbRetryCancel
            // 
            rbRetryCancel.AutoSize = true;
            rbRetryCancel.Location = new Point(15, 142);
            rbRetryCancel.Name = "rbRetryCancel";
            rbRetryCancel.Size = new Size(93, 19);
            rbRetryCancel.TabIndex = 5;
            rbRetryCancel.TabStop = true;
            rbRetryCancel.Text = "Retry/Cancel";
            rbRetryCancel.UseVisualStyleBackColor = true;
            // 
            // rbAbortRetryIgnore
            // 
            rbAbortRetryIgnore.AutoSize = true;
            rbAbortRetryIgnore.Location = new Point(15, 117);
            rbAbortRetryIgnore.Name = "rbAbortRetryIgnore";
            rbAbortRetryIgnore.Size = new Size(126, 19);
            rbAbortRetryIgnore.TabIndex = 4;
            rbAbortRetryIgnore.TabStop = true;
            rbAbortRetryIgnore.Text = "Abort/Retry/Ignore";
            rbAbortRetryIgnore.UseVisualStyleBackColor = true;
            // 
            // rbYesNoCancel
            // 
            rbYesNoCancel.AutoSize = true;
            rbYesNoCancel.Location = new Point(15, 92);
            rbYesNoCancel.Name = "rbYesNoCancel";
            rbYesNoCancel.Size = new Size(104, 19);
            rbYesNoCancel.TabIndex = 3;
            rbYesNoCancel.TabStop = true;
            rbYesNoCancel.Text = "Yes/No/Cancel";
            rbYesNoCancel.UseVisualStyleBackColor = true;
            // 
            // rbYesNo
            // 
            rbYesNo.AutoSize = true;
            rbYesNo.Location = new Point(15, 67);
            rbYesNo.Name = "rbYesNo";
            rbYesNo.Size = new Size(63, 19);
            rbYesNo.TabIndex = 2;
            rbYesNo.TabStop = true;
            rbYesNo.Text = "Yes/No";
            rbYesNo.UseVisualStyleBackColor = true;
            // 
            // rbOkCancel
            // 
            rbOkCancel.AutoSize = true;
            rbOkCancel.Location = new Point(15, 42);
            rbOkCancel.Name = "rbOkCancel";
            rbOkCancel.Size = new Size(82, 19);
            rbOkCancel.TabIndex = 1;
            rbOkCancel.TabStop = true;
            rbOkCancel.Text = "OK/Cancel";
            rbOkCancel.UseVisualStyleBackColor = true;
            // 
            // rbOk
            // 
            rbOk.AutoSize = true;
            rbOk.Checked = true;
            rbOk.Location = new Point(15, 17);
            rbOk.Name = "rbOk";
            rbOk.Size = new Size(41, 19);
            rbOk.TabIndex = 0;
            rbOk.TabStop = true;
            rbOk.Text = "OK";
            rbOk.UseVisualStyleBackColor = true;
            // 
            // gbIcon
            // 
            gbIcon.Controls.Add(flowIconSelect);
            gbIcon.Location = new Point(576, 13);
            gbIcon.Name = "gbIcon";
            gbIcon.Size = new Size(225, 335);
            gbIcon.TabIndex = 7;
            gbIcon.TabStop = false;
            gbIcon.Text = "Icon";
            // 
            // flowIconSelect
            // 
            flowIconSelect.Controls.Add(rbIconNone);
            flowIconSelect.Controls.Add(rbIconInformation);
            flowIconSelect.Controls.Add(rbIconWarning);
            flowIconSelect.Controls.Add(rbIconShield);
            flowIconSelect.Controls.Add(rbIconError);
            flowIconSelect.Controls.Add(rbIconShieldBlueBar);
            flowIconSelect.Controls.Add(rbIconShieldGrayBar);
            flowIconSelect.Controls.Add(rbIconShieldErrorRedBar);
            flowIconSelect.Controls.Add(rbIconShieldWarningYellowBar);
            flowIconSelect.Controls.Add(rbIconShieldSuccessGreenBar);
            flowIconSelect.Controls.Add(rbIconCustomFile);
            flowIconSelect.Controls.Add(rbIconCustomID);
            flowIconSelect.Dock = DockStyle.Fill;
            flowIconSelect.FlowDirection = FlowDirection.TopDown;
            flowIconSelect.Location = new Point(3, 19);
            flowIconSelect.Name = "flowIconSelect";
            flowIconSelect.Padding = new Padding(4);
            flowIconSelect.Size = new Size(219, 313);
            flowIconSelect.TabIndex = 22;
            // 
            // rbIconNone
            // 
            rbIconNone.Checked = true;
            rbIconNone.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconNone.Location = new Point(4, 4);
            rbIconNone.Margin = new Padding(0);
            rbIconNone.Name = "rbIconNone";
            rbIconNone.Size = new Size(210, 24);
            rbIconNone.TabIndex = 0;
            rbIconNone.TabStop = true;
            rbIconNone.Text = "None";
            rbIconNone.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconNone.UseVisualStyleBackColor = true;
            // 
            // rbIconInformation
            // 
            rbIconInformation.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconInformation.Location = new Point(4, 28);
            rbIconInformation.Margin = new Padding(0);
            rbIconInformation.Name = "rbIconInformation";
            rbIconInformation.Size = new Size(210, 24);
            rbIconInformation.TabIndex = 1;
            rbIconInformation.Text = "Information";
            rbIconInformation.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconInformation.UseVisualStyleBackColor = true;
            // 
            // rbIconWarning
            // 
            rbIconWarning.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconWarning.Location = new Point(4, 52);
            rbIconWarning.Margin = new Padding(0);
            rbIconWarning.Name = "rbIconWarning";
            rbIconWarning.Size = new Size(210, 24);
            rbIconWarning.TabIndex = 2;
            rbIconWarning.Text = "Warning";
            rbIconWarning.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconWarning.UseVisualStyleBackColor = true;
            // 
            // rbIconShield
            // 
            rbIconShield.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShield.Location = new Point(4, 76);
            rbIconShield.Margin = new Padding(0);
            rbIconShield.Name = "rbIconShield";
            rbIconShield.Size = new Size(210, 24);
            rbIconShield.TabIndex = 3;
            rbIconShield.Text = "Shield";
            rbIconShield.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShield.UseVisualStyleBackColor = true;
            // 
            // rbIconError
            // 
            rbIconError.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconError.Location = new Point(4, 100);
            rbIconError.Margin = new Padding(0);
            rbIconError.Name = "rbIconError";
            rbIconError.Size = new Size(210, 24);
            rbIconError.TabIndex = 4;
            rbIconError.Text = "Error";
            rbIconError.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconError.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldBlueBar
            // 
            rbIconShieldBlueBar.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShieldBlueBar.Location = new Point(4, 132);
            rbIconShieldBlueBar.Margin = new Padding(0, 8, 0, 0);
            rbIconShieldBlueBar.Name = "rbIconShieldBlueBar";
            rbIconShieldBlueBar.Size = new Size(210, 24);
            rbIconShieldBlueBar.TabIndex = 5;
            rbIconShieldBlueBar.Text = "Shield - Blue Bar";
            rbIconShieldBlueBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShieldBlueBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldGrayBar
            // 
            rbIconShieldGrayBar.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShieldGrayBar.Location = new Point(4, 156);
            rbIconShieldGrayBar.Margin = new Padding(0);
            rbIconShieldGrayBar.Name = "rbIconShieldGrayBar";
            rbIconShieldGrayBar.Size = new Size(210, 24);
            rbIconShieldGrayBar.TabIndex = 6;
            rbIconShieldGrayBar.Text = "Shield - Gray Bar";
            rbIconShieldGrayBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShieldGrayBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldErrorRedBar
            // 
            rbIconShieldErrorRedBar.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShieldErrorRedBar.Location = new Point(4, 180);
            rbIconShieldErrorRedBar.Margin = new Padding(0);
            rbIconShieldErrorRedBar.Name = "rbIconShieldErrorRedBar";
            rbIconShieldErrorRedBar.Size = new Size(210, 24);
            rbIconShieldErrorRedBar.TabIndex = 7;
            rbIconShieldErrorRedBar.Text = "Shield Error";
            rbIconShieldErrorRedBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShieldErrorRedBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldWarningYellowBar
            // 
            rbIconShieldWarningYellowBar.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShieldWarningYellowBar.Location = new Point(4, 204);
            rbIconShieldWarningYellowBar.Margin = new Padding(0);
            rbIconShieldWarningYellowBar.Name = "rbIconShieldWarningYellowBar";
            rbIconShieldWarningYellowBar.Size = new Size(210, 24);
            rbIconShieldWarningYellowBar.TabIndex = 8;
            rbIconShieldWarningYellowBar.Text = "Shield Warning";
            rbIconShieldWarningYellowBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShieldWarningYellowBar.UseVisualStyleBackColor = true;
            // 
            // rbIconShieldSuccessGreenBar
            // 
            rbIconShieldSuccessGreenBar.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconShieldSuccessGreenBar.Location = new Point(4, 228);
            rbIconShieldSuccessGreenBar.Margin = new Padding(0);
            rbIconShieldSuccessGreenBar.Name = "rbIconShieldSuccessGreenBar";
            rbIconShieldSuccessGreenBar.Size = new Size(210, 24);
            rbIconShieldSuccessGreenBar.TabIndex = 9;
            rbIconShieldSuccessGreenBar.Text = "Shield Success";
            rbIconShieldSuccessGreenBar.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconShieldSuccessGreenBar.UseVisualStyleBackColor = true;
            // 
            // rbIconCustomFile
            // 
            rbIconCustomFile.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconCustomFile.Location = new Point(4, 260);
            rbIconCustomFile.Margin = new Padding(0, 8, 0, 0);
            rbIconCustomFile.Name = "rbIconCustomFile";
            rbIconCustomFile.Size = new Size(210, 24);
            rbIconCustomFile.TabIndex = 10;
            rbIconCustomFile.Text = "Custom (File)";
            rbIconCustomFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconCustomFile.UseVisualStyleBackColor = true;
            // 
            // rbIconCustomID
            // 
            rbIconCustomID.ImageAlign = ContentAlignment.MiddleLeft;
            rbIconCustomID.Location = new Point(4, 284);
            rbIconCustomID.Margin = new Padding(0);
            rbIconCustomID.Name = "rbIconCustomID";
            rbIconCustomID.Size = new Size(210, 24);
            rbIconCustomID.TabIndex = 11;
            rbIconCustomID.Text = "Custom (imageres.dll ID)";
            rbIconCustomID.TextImageRelation = TextImageRelation.ImageBeforeText;
            rbIconCustomID.UseVisualStyleBackColor = true;
            // 
            // btnShowDialog
            // 
            btnShowDialog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowDialog.Location = new Point(8, 464);
            btnShowDialog.Name = "btnShowDialog";
            btnShowDialog.Size = new Size(140, 42);
            btnShowDialog.TabIndex = 11;
            btnShowDialog.Text = "Show Dialog";
            btnShowDialog.UseVisualStyleBackColor = true;
            btnShowDialog.Click += btnShowDialog_Click;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(5, 161);
            lblFooter.Margin = new Padding(5, 5, 5, 2);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(44, 15);
            lblFooter.TabIndex = 4;
            lblFooter.Text = "Footer:";
            // 
            // txtFooter
            // 
            txtFooter.Location = new Point(5, 180);
            txtFooter.Margin = new Padding(5, 2, 5, 5);
            txtFooter.Name = "txtFooter";
            txtFooter.Size = new Size(304, 23);
            txtFooter.TabIndex = 5;
            // 
            // chkVerification
            // 
            chkVerification.AutoSize = true;
            chkVerification.Location = new Point(3, 3);
            chkVerification.Name = "chkVerification";
            chkVerification.Size = new Size(120, 19);
            chkVerification.TabIndex = 10;
            chkVerification.Text = "Show verification:";
            chkVerification.UseVisualStyleBackColor = true;
            // 
            // lblExpandedInfo
            // 
            lblExpandedInfo.AutoSize = true;
            lblExpandedInfo.Location = new Point(5, 213);
            lblExpandedInfo.Margin = new Padding(5, 5, 5, 2);
            lblExpandedInfo.Name = "lblExpandedInfo";
            lblExpandedInfo.Size = new Size(124, 15);
            lblExpandedInfo.TabIndex = 8;
            lblExpandedInfo.Text = "Expanded Information";
            // 
            // txtExpandedInfo
            // 
            txtExpandedInfo.Location = new Point(5, 232);
            txtExpandedInfo.Margin = new Padding(5, 2, 5, 5);
            txtExpandedInfo.Multiline = true;
            txtExpandedInfo.Name = "txtExpandedInfo";
            txtExpandedInfo.Size = new Size(304, 92);
            txtExpandedInfo.TabIndex = 9;
            // 
            // textBoxCustomIconPath
            // 
            textBoxCustomIconPath.Location = new Point(10, 23);
            textBoxCustomIconPath.Margin = new Padding(2);
            textBoxCustomIconPath.Name = "textBoxCustomIconPath";
            textBoxCustomIconPath.Size = new Size(224, 23);
            textBoxCustomIconPath.TabIndex = 12;
            // 
            // buttonBrowseCustomIcon
            // 
            buttonBrowseCustomIcon.Location = new Point(238, 23);
            buttonBrowseCustomIcon.Margin = new Padding(2);
            buttonBrowseCustomIcon.Name = "buttonBrowseCustomIcon";
            buttonBrowseCustomIcon.Size = new Size(78, 26);
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
            groupBoxCustomIconFile.Location = new Point(471, 357);
            groupBoxCustomIconFile.Margin = new Padding(2);
            groupBoxCustomIconFile.Name = "groupBoxCustomIconFile";
            groupBoxCustomIconFile.Padding = new Padding(2);
            groupBoxCustomIconFile.Size = new Size(330, 59);
            groupBoxCustomIconFile.TabIndex = 14;
            groupBoxCustomIconFile.TabStop = false;
            groupBoxCustomIconFile.Text = "Custom Icon (File)";
            // 
            // buttonTest
            // 
            buttonTest.Location = new Point(183, 432);
            buttonTest.Margin = new Padding(2);
            buttonTest.Name = "buttonTest";
            buttonTest.Size = new Size(78, 25);
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
            groupBoxBarColor.Location = new Point(470, 420);
            groupBoxBarColor.Margin = new Padding(2);
            groupBoxBarColor.Name = "groupBoxBarColor";
            groupBoxBarColor.Padding = new Padding(2);
            groupBoxBarColor.Size = new Size(332, 86);
            groupBoxBarColor.TabIndex = 16;
            groupBoxBarColor.TabStop = false;
            groupBoxBarColor.Text = "Bar Color";
            // 
            // rbBarColorNone
            // 
            rbBarColorNone.AutoSize = true;
            rbBarColorNone.Location = new Point(227, 27);
            rbBarColorNone.Margin = new Padding(2);
            rbBarColorNone.Name = "rbBarColorNone";
            rbBarColorNone.Size = new Size(86, 19);
            rbBarColorNone.TabIndex = 6;
            rbBarColorNone.Text = "Force None";
            rbBarColorNone.UseVisualStyleBackColor = true;
            // 
            // rbBarColorDefault
            // 
            rbBarColorDefault.AutoSize = true;
            rbBarColorDefault.Checked = true;
            rbBarColorDefault.Location = new Point(27, 27);
            rbBarColorDefault.Margin = new Padding(2);
            rbBarColorDefault.Name = "rbBarColorDefault";
            rbBarColorDefault.Size = new Size(63, 19);
            rbBarColorDefault.TabIndex = 5;
            rbBarColorDefault.TabStop = true;
            rbBarColorDefault.Text = "Default";
            rbBarColorDefault.UseVisualStyleBackColor = true;
            // 
            // rbBarColorGreen
            // 
            rbBarColorGreen.AutoSize = true;
            rbBarColorGreen.Location = new Point(97, 27);
            rbBarColorGreen.Margin = new Padding(2);
            rbBarColorGreen.Name = "rbBarColorGreen";
            rbBarColorGreen.Size = new Size(56, 19);
            rbBarColorGreen.TabIndex = 4;
            rbBarColorGreen.Text = "Green";
            rbBarColorGreen.UseVisualStyleBackColor = true;
            // 
            // rbBarColorRed
            // 
            rbBarColorRed.AutoSize = true;
            rbBarColorRed.Location = new Point(163, 27);
            rbBarColorRed.Margin = new Padding(2);
            rbBarColorRed.Name = "rbBarColorRed";
            rbBarColorRed.Size = new Size(45, 19);
            rbBarColorRed.TabIndex = 3;
            rbBarColorRed.Text = "Red";
            rbBarColorRed.UseVisualStyleBackColor = true;
            // 
            // rbBarColorYellow
            // 
            rbBarColorYellow.AutoSize = true;
            rbBarColorYellow.Location = new Point(97, 48);
            rbBarColorYellow.Margin = new Padding(2);
            rbBarColorYellow.Name = "rbBarColorYellow";
            rbBarColorYellow.Size = new Size(59, 19);
            rbBarColorYellow.TabIndex = 2;
            rbBarColorYellow.Text = "Yellow";
            rbBarColorYellow.UseVisualStyleBackColor = true;
            // 
            // rbBarColorGray
            // 
            rbBarColorGray.AutoSize = true;
            rbBarColorGray.Location = new Point(27, 48);
            rbBarColorGray.Margin = new Padding(2);
            rbBarColorGray.Name = "rbBarColorGray";
            rbBarColorGray.Size = new Size(49, 19);
            rbBarColorGray.TabIndex = 1;
            rbBarColorGray.Text = "Gray";
            rbBarColorGray.UseVisualStyleBackColor = true;
            // 
            // rbBarColorBlue
            // 
            rbBarColorBlue.AutoSize = true;
            rbBarColorBlue.Location = new Point(163, 48);
            rbBarColorBlue.Margin = new Padding(2);
            rbBarColorBlue.Name = "rbBarColorBlue";
            rbBarColorBlue.Size = new Size(48, 19);
            rbBarColorBlue.TabIndex = 0;
            rbBarColorBlue.Text = "Blue";
            rbBarColorBlue.UseVisualStyleBackColor = true;
            // 
            // groupBoxCustomIconID
            // 
            groupBoxCustomIconID.Controls.Add(textBoxCustomIconID);
            groupBoxCustomIconID.Enabled = false;
            groupBoxCustomIconID.Location = new Point(334, 420);
            groupBoxCustomIconID.Margin = new Padding(2);
            groupBoxCustomIconID.Name = "groupBoxCustomIconID";
            groupBoxCustomIconID.Padding = new Padding(2);
            groupBoxCustomIconID.Size = new Size(120, 55);
            groupBoxCustomIconID.TabIndex = 17;
            groupBoxCustomIconID.TabStop = false;
            groupBoxCustomIconID.Text = "Custom Icon (ID)";
            // 
            // textBoxCustomIconID
            // 
            textBoxCustomIconID.Location = new Point(15, 23);
            textBoxCustomIconID.Margin = new Padding(2);
            textBoxCustomIconID.Name = "textBoxCustomIconID";
            textBoxCustomIconID.Size = new Size(96, 23);
            textBoxCustomIconID.TabIndex = 14;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(5, 109);
            lblMessage.Margin = new Padding(5, 5, 5, 2);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(56, 15);
            lblMessage.TabIndex = 18;
            lblMessage.Text = "Message:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(5, 128);
            txtMessage.Margin = new Padding(5, 2, 5, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(304, 23);
            txtMessage.TabIndex = 19;
            // 
            // textBoxVerification
            // 
            textBoxVerification.Location = new Point(128, 2);
            textBoxVerification.Margin = new Padding(2);
            textBoxVerification.Name = "textBoxVerification";
            textBoxVerification.PlaceholderText = " Don't ask again";
            textBoxVerification.Size = new Size(176, 23);
            textBoxVerification.TabIndex = 20;
            // 
            // buttonImageResIcons
            // 
            buttonImageResIcons.Location = new Point(334, 479);
            buttonImageResIcons.Margin = new Padding(2);
            buttonImageResIcons.Name = "buttonImageResIcons";
            buttonImageResIcons.Size = new Size(120, 27);
            buttonImageResIcons.TabIndex = 21;
            buttonImageResIcons.Text = "View Icon IDs";
            buttonImageResIcons.UseVisualStyleBackColor = true;
            buttonImageResIcons.Click += buttonImageResIcons_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTitle);
            flowLayoutPanel1.Controls.Add(txtTitle);
            flowLayoutPanel1.Controls.Add(lblHeading);
            flowLayoutPanel1.Controls.Add(txtHeading);
            flowLayoutPanel1.Controls.Add(lblMessage);
            flowLayoutPanel1.Controls.Add(txtMessage);
            flowLayoutPanel1.Controls.Add(lblFooter);
            flowLayoutPanel1.Controls.Add(txtFooter);
            flowLayoutPanel1.Controls.Add(lblExpandedInfo);
            flowLayoutPanel1.Controls.Add(txtExpandedInfo);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(317, 374);
            flowLayoutPanel1.TabIndex = 22;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(chkVerification);
            flowLayoutPanel2.Controls.Add(textBoxVerification);
            flowLayoutPanel2.Location = new Point(3, 334);
            flowLayoutPanel2.Margin = new Padding(3, 5, 3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(306, 27);
            flowLayoutPanel2.TabIndex = 24;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.ForeColor = SystemColors.WindowFrame;
            labelVersion.Location = new Point(12, 443);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(51, 15);
            labelVersion.TabIndex = 23;
            labelVersion.Text = "Version: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 517);
            Controls.Add(labelVersion);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(buttonImageResIcons);
            Controls.Add(groupBoxCustomIconID);
            Controls.Add(groupBoxBarColor);
            Controls.Add(buttonTest);
            Controls.Add(groupBoxCustomIconFile);
            Controls.Add(btnShowDialog);
            Controls.Add(gbIcon);
            Controls.Add(gbButtons);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Task Dialog Generator";
            Load += MainForm_Load;
            gbButtons.ResumeLayout(false);
            gbButtons.PerformLayout();
            gbIcon.ResumeLayout(false);
            flowIconSelect.ResumeLayout(false);
            groupBoxCustomIconFile.ResumeLayout(false);
            groupBoxCustomIconFile.PerformLayout();
            groupBoxBarColor.ResumeLayout(false);
            groupBoxBarColor.PerformLayout();
            groupBoxCustomIconID.ResumeLayout(false);
            groupBoxCustomIconID.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
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
        private TextBox textBoxVerification;
        private Button buttonImageResIcons;
        private FlowLayoutPanel flowIconSelect;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelVersion;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}