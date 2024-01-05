namespace Lethal_Company_Mod_Applier
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
            if (disposing && (components != null))
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
            PathTextBox = new TextBox();
            PathLabel = new Label();
            ApplyBtn = new Button();
            ClearBtn = new Button();
            DownloadButton = new Button();
            LogLabel = new Label();
            LogList = new ListBox();
            HelpLink = new LinkLabel();
            ModsListPanel = new FlowLayoutPanel();
            SelectedModsCheckListBox = new CheckedListBox();
            OpenCloseBtn = new Button();
            ModsListPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(12, 40);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.Size = new Size(426, 23);
            PathTextBox.TabIndex = 0;
            PathTextBox.TextChanged += PathTextBox_TextChanged;
            // 
            // PathLabel
            // 
            PathLabel.AutoSize = true;
            PathLabel.Location = new Point(12, 22);
            PathLabel.Name = "PathLabel";
            PathLabel.Size = new Size(160, 15);
            PathLabel.TabIndex = 1;
            PathLabel.Text = "Lethal Company Folder Path:";
            // 
            // ApplyBtn
            // 
            ApplyBtn.Enabled = false;
            ApplyBtn.Location = new Point(214, 80);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(95, 34);
            ApplyBtn.TabIndex = 2;
            ApplyBtn.Text = "Apply";
            ApplyBtn.UseVisualStyleBackColor = true;
            ApplyBtn.Click += ApplyBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.Enabled = false;
            ClearBtn.Location = new Point(315, 80);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(123, 34);
            ClearBtn.TabIndex = 3;
            ClearBtn.Text = "Remove All Mods";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(12, 80);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(95, 34);
            DownloadButton.TabIndex = 1;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // LogLabel
            // 
            LogLabel.AutoSize = true;
            LogLabel.Location = new Point(12, 123);
            LogLabel.Name = "LogLabel";
            LogLabel.Size = new Size(35, 15);
            LogLabel.TabIndex = 5;
            LogLabel.Text = "Logs:";
            // 
            // LogList
            // 
            LogList.CausesValidation = false;
            LogList.FormattingEnabled = true;
            LogList.ItemHeight = 15;
            LogList.Location = new Point(12, 141);
            LogList.Name = "LogList";
            LogList.Size = new Size(426, 109);
            LogList.TabIndex = 6;
            // 
            // HelpLink
            // 
            HelpLink.AutoSize = true;
            HelpLink.Location = new Point(406, 9);
            HelpLink.Name = "HelpLink";
            HelpLink.Size = new Size(32, 15);
            HelpLink.TabIndex = 7;
            HelpLink.TabStop = true;
            HelpLink.Text = "Help";
            HelpLink.LinkClicked += HelpLink_LinkClicked;
            // 
            // ModsListPanel
            // 
            ModsListPanel.AutoSize = true;
            ModsListPanel.Controls.Add(SelectedModsCheckListBox);
            ModsListPanel.FlowDirection = FlowDirection.TopDown;
            ModsListPanel.Location = new Point(9, 120);
            ModsListPanel.Name = "ModsListPanel";
            ModsListPanel.Size = new Size(432, 208);
            ModsListPanel.TabIndex = 8;
            ModsListPanel.Visible = false;
            // 
            // SelectedModsCheckListBox
            // 
            SelectedModsCheckListBox.FormattingEnabled = true;
            SelectedModsCheckListBox.Location = new Point(3, 3);
            SelectedModsCheckListBox.Name = "SelectedModsCheckListBox";
            SelectedModsCheckListBox.Size = new Size(426, 202);
            SelectedModsCheckListBox.TabIndex = 0;
            SelectedModsCheckListBox.ItemCheck += SelectedModsCheckListBox_ItemCheck;
            SelectedModsCheckListBox.SelectedIndexChanged += SelectedModsCheckListBox_SelectedIndexChanged;
            // 
            // OpenCloseBtn
            // 
            OpenCloseBtn.Enabled = false;
            OpenCloseBtn.Location = new Point(113, 80);
            OpenCloseBtn.Name = "OpenCloseBtn";
            OpenCloseBtn.Size = new Size(95, 34);
            OpenCloseBtn.TabIndex = 9;
            OpenCloseBtn.Text = "Select Mods";
            OpenCloseBtn.UseVisualStyleBackColor = true;
            OpenCloseBtn.Click += OpenCloseBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 272);
            Controls.Add(OpenCloseBtn);
            Controls.Add(ModsListPanel);
            Controls.Add(HelpLink);
            Controls.Add(LogList);
            Controls.Add(LogLabel);
            Controls.Add(DownloadButton);
            Controls.Add(ClearBtn);
            Controls.Add(ApplyBtn);
            Controls.Add(PathLabel);
            Controls.Add(PathTextBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Lethal Company Mod Applier";
            ModsListPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PathTextBox;
        private Label PathLabel;
        private Button ApplyBtn;
        private Button ClearBtn;
        private Button DownloadButton;
        private Label LogLabel;
        private ListBox LogList;
        private LinkLabel HelpLink;
        private FlowLayoutPanel ModsListPanel;
        private CheckedListBox SelectedModsCheckListBox;
        private Button OpenCloseBtn;
    }
}
