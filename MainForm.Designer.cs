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
            txtMessage = new TextBox();
            lblTitle = new Label();
            lblMessage = new Label();
            gbButtons = new GroupBox();
            rbRetryCancel = new RadioButton();
            rbAbortRetryIgnore = new RadioButton();
            rbYesNoCancel = new RadioButton();
            rbYesNo = new RadioButton();
            rbOkCancel = new RadioButton();
            rbOk = new RadioButton();
            gbIcon = new GroupBox();
            rbIconError = new RadioButton();
            rbIconQuestion = new RadioButton();
            rbIconWarning = new RadioButton();
            rbIconInformation = new RadioButton();
            rbIconNone = new RadioButton();
            btnShowDialog = new Button();
            lblFooter = new Label();
            txtFooter = new TextBox();
            chkVerification = new CheckBox();
            lblExpandedInfo = new Label();
            txtExpandedInfo = new TextBox();
            gbButtons.SuspendLayout();
            gbIcon.SuspendLayout();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 31);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(300, 23);
            txtTitle.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 87);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(300, 23);
            txtMessage.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(32, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title:";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(12, 69);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(56, 15);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Message:";
            // 
            // gbButtons
            // 
            gbButtons.Controls.Add(rbRetryCancel);
            gbButtons.Controls.Add(rbAbortRetryIgnore);
            gbButtons.Controls.Add(rbYesNoCancel);
            gbButtons.Controls.Add(rbYesNo);
            gbButtons.Controls.Add(rbOkCancel);
            gbButtons.Controls.Add(rbOk);
            gbButtons.Location = new Point(330, 13);
            gbButtons.Name = "gbButtons";
            gbButtons.Size = new Size(200, 175);
            gbButtons.TabIndex = 6;
            gbButtons.TabStop = false;
            gbButtons.Text = "Buttons";
            // 
            // rbRetryCancel
            // 
            rbRetryCancel.AutoSize = true;
            rbRetryCancel.Location = new Point(15, 142);
            rbRetryCancel.Name = "rbRetryCancel";
            rbRetryCancel.Size = new Size(90, 19);
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
            rbAbortRetryIgnore.Size = new Size(125, 19);
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
            rbYesNoCancel.Size = new Size(102, 19);
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
            rbOkCancel.Size = new Size(80, 19);
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
            gbIcon.Controls.Add(rbIconError);
            gbIcon.Controls.Add(rbIconQuestion);
            gbIcon.Controls.Add(rbIconWarning);
            gbIcon.Controls.Add(rbIconInformation);
            gbIcon.Controls.Add(rbIconNone);
            gbIcon.Location = new Point(550, 13);
            gbIcon.Name = "gbIcon";
            gbIcon.Size = new Size(200, 175);
            gbIcon.TabIndex = 7;
            gbIcon.TabStop = false;
            gbIcon.Text = "Icon";
            // 
            // rbIconError
            // 
            rbIconError.AutoSize = true;
            rbIconError.Location = new Point(15, 117);
            rbIconError.Name = "rbIconError";
            rbIconError.Size = new Size(50, 19);
            rbIconError.TabIndex = 4;
            rbIconError.Text = "Error";
            rbIconError.UseVisualStyleBackColor = true;
            // 
            // rbIconQuestion
            // 
            rbIconQuestion.AutoSize = true;
            rbIconQuestion.Location = new Point(15, 92);
            rbIconQuestion.Name = "rbIconQuestion";
            rbIconQuestion.Size = new Size(73, 19);
            rbIconQuestion.TabIndex = 3;
            rbIconQuestion.Text = "Question";
            rbIconQuestion.UseVisualStyleBackColor = true;
            // 
            // rbIconWarning
            // 
            rbIconWarning.AutoSize = true;
            rbIconWarning.Location = new Point(15, 67);
            rbIconWarning.Name = "rbIconWarning";
            rbIconWarning.Size = new Size(70, 19);
            rbIconWarning.TabIndex = 2;
            rbIconWarning.Text = "Warning";
            rbIconWarning.UseVisualStyleBackColor = true;
            // 
            // rbIconInformation
            // 
            rbIconInformation.AutoSize = true;
            rbIconInformation.Location = new Point(15, 42);
            rbIconInformation.Name = "rbIconInformation";
            rbIconInformation.Size = new Size(87, 19);
            rbIconInformation.TabIndex = 1;
            rbIconInformation.Text = "Information";
            rbIconInformation.UseVisualStyleBackColor = true;
            // 
            // rbIconNone
            // 
            rbIconNone.AutoSize = true;
            rbIconNone.Checked = true;
            rbIconNone.Location = new Point(15, 17);
            rbIconNone.Name = "rbIconNone";
            rbIconNone.Size = new Size(54, 19);
            rbIconNone.TabIndex = 0;
            rbIconNone.TabStop = true;
            rbIconNone.Text = "None";
            rbIconNone.UseVisualStyleBackColor = true;
            // 
            // btnShowDialog
            // 
            btnShowDialog.Location = new Point(629, 388);
            btnShowDialog.Name = "btnShowDialog";
            btnShowDialog.Size = new Size(121, 33);
            btnShowDialog.TabIndex = 11;
            btnShowDialog.Text = "Show Dialog";
            btnShowDialog.UseVisualStyleBackColor = true;
            btnShowDialog.Click += btnShowDialog_Click;
            // 
            // lblFooter
            // 
            lblFooter.AutoSize = true;
            lblFooter.Location = new Point(12, 125);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(44, 15);
            lblFooter.TabIndex = 4;
            lblFooter.Text = "Footer:";
            // 
            // txtFooter
            // 
            txtFooter.Location = new Point(12, 143);
            txtFooter.Name = "txtFooter";
            txtFooter.Size = new Size(300, 23);
            txtFooter.TabIndex = 5;
            // 
            // chkVerification
            // 
            chkVerification.AutoSize = true;
            chkVerification.Location = new Point(12, 333);
            chkVerification.Name = "chkVerification";
            chkVerification.Size = new Size(115, 19);
            chkVerification.TabIndex = 10;
            chkVerification.Text = "Show verification";
            chkVerification.UseVisualStyleBackColor = true;
            // 
            // lblExpandedInfo
            // 
            lblExpandedInfo.AutoSize = true;
            lblExpandedInfo.Location = new Point(12, 181);
            lblExpandedInfo.Name = "lblExpandedInfo";
            lblExpandedInfo.Size = new Size(127, 15);
            lblExpandedInfo.TabIndex = 8;
            lblExpandedInfo.Text = "Expanded Information";
            // 
            // txtExpandedInfo
            // 
            txtExpandedInfo.Location = new Point(12, 199);
            txtExpandedInfo.Multiline = true;
            txtExpandedInfo.Name = "txtExpandedInfo";
            txtExpandedInfo.Size = new Size(300, 114);
            txtExpandedInfo.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(txtExpandedInfo);
            Controls.Add(lblExpandedInfo);
            Controls.Add(chkVerification);
            Controls.Add(txtFooter);
            Controls.Add(lblFooter);
            Controls.Add(btnShowDialog);
            Controls.Add(gbIcon);
            Controls.Add(gbButtons);
            Controls.Add(lblMessage);
            Controls.Add(lblTitle);
            Controls.Add(txtMessage);
            Controls.Add(txtTitle);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Task Dialog Generator";
            gbButtons.ResumeLayout(false);
            gbButtons.PerformLayout();
            gbIcon.ResumeLayout(false);
            gbIcon.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtMessage;
        private Label lblTitle;
        private Label lblMessage;
        private GroupBox gbButtons;
        private RadioButton rbRetryCancel;
        private RadioButton rbAbortRetryIgnore;
        private RadioButton rbYesNoCancel;
        private RadioButton rbYesNo;
        private RadioButton rbOkCancel;
        private RadioButton rbOk;
        private GroupBox gbIcon;
        private RadioButton rbIconError;
        private RadioButton rbIconQuestion;
        private RadioButton rbIconWarning;
        private RadioButton rbIconInformation;
        private RadioButton rbIconNone;
        private Button btnShowDialog;
        private Label lblFooter;
        private TextBox txtFooter;
        private CheckBox chkVerification;
        private Label lblExpandedInfo;
        private TextBox txtExpandedInfo;
    }
}