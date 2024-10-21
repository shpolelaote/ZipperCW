namespace ZipperCW
{
    partial class ZipperForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.archiveTabPage = new System.Windows.Forms.TabPage();
            this.unarchiveTabPage = new System.Windows.Forms.TabPage();
            this.archiveChooseFileTextBox = new System.Windows.Forms.TextBox();
            this.archiveChooseFileButton = new System.Windows.Forms.Button();
            this.archiveChooseDirectoryButton = new System.Windows.Forms.Button();
            this.archiveChooseDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.archiveButton = new System.Windows.Forms.Button();
            this.unarchiveChooseFileButton = new System.Windows.Forms.Button();
            this.unarchiveChooseFileTextBox = new System.Windows.Forms.TextBox();
            this.unarchiveChooseDicTextBox = new System.Windows.Forms.TextBox();
            this.unarchiveChooseDicButton = new System.Windows.Forms.Button();
            this.unarchiveChooseDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.unarchiveChooseDirectoryButton = new System.Windows.Forms.Button();
            this.unarchiveButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.archiveTabPage.SuspendLayout();
            this.unarchiveTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.archiveTabPage);
            this.tabControl.Controls.Add(this.unarchiveTabPage);
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(535, 263);
            this.tabControl.TabIndex = 0;
            // 
            // archiveTabPage
            // 
            this.archiveTabPage.Controls.Add(this.archiveButton);
            this.archiveTabPage.Controls.Add(this.archiveChooseDirectoryTextBox);
            this.archiveTabPage.Controls.Add(this.archiveChooseDirectoryButton);
            this.archiveTabPage.Controls.Add(this.archiveChooseFileButton);
            this.archiveTabPage.Controls.Add(this.archiveChooseFileTextBox);
            this.archiveTabPage.Location = new System.Drawing.Point(4, 25);
            this.archiveTabPage.Name = "archiveTabPage";
            this.archiveTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.archiveTabPage.Size = new System.Drawing.Size(527, 234);
            this.archiveTabPage.TabIndex = 0;
            this.archiveTabPage.Text = "archive";
            this.archiveTabPage.UseVisualStyleBackColor = true;
            // 
            // unarchiveTabPage
            // 
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseDirectoryTextBox);
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseDicTextBox);
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseFileTextBox);
            this.unarchiveTabPage.Controls.Add(this.unarchiveButton);
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseDirectoryButton);
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseDicButton);
            this.unarchiveTabPage.Controls.Add(this.unarchiveChooseFileButton);
            this.unarchiveTabPage.Location = new System.Drawing.Point(4, 25);
            this.unarchiveTabPage.Name = "unarchiveTabPage";
            this.unarchiveTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.unarchiveTabPage.Size = new System.Drawing.Size(527, 234);
            this.unarchiveTabPage.TabIndex = 1;
            this.unarchiveTabPage.Text = "unarchive";
            this.unarchiveTabPage.UseVisualStyleBackColor = true;
            // 
            // archiveChooseFileTextBox
            // 
            this.archiveChooseFileTextBox.Location = new System.Drawing.Point(37, 47);
            this.archiveChooseFileTextBox.Name = "archiveChooseFileTextBox";
            this.archiveChooseFileTextBox.Size = new System.Drawing.Size(301, 22);
            this.archiveChooseFileTextBox.TabIndex = 0;
            // 
            // archiveChooseFileButton
            // 
            this.archiveChooseFileButton.Location = new System.Drawing.Point(374, 46);
            this.archiveChooseFileButton.Name = "archiveChooseFileButton";
            this.archiveChooseFileButton.Size = new System.Drawing.Size(116, 23);
            this.archiveChooseFileButton.TabIndex = 1;
            this.archiveChooseFileButton.Text = "Choose file";
            this.archiveChooseFileButton.UseVisualStyleBackColor = true;
            this.archiveChooseFileButton.Click += new System.EventHandler(this.archiveChooseFileButton_Click);
            // 
            // archiveChooseDirectoryButton
            // 
            this.archiveChooseDirectoryButton.Location = new System.Drawing.Point(374, 102);
            this.archiveChooseDirectoryButton.Name = "archiveChooseDirectoryButton";
            this.archiveChooseDirectoryButton.Size = new System.Drawing.Size(133, 23);
            this.archiveChooseDirectoryButton.TabIndex = 2;
            this.archiveChooseDirectoryButton.Text = "Choose directory";
            this.archiveChooseDirectoryButton.UseVisualStyleBackColor = true;
            this.archiveChooseDirectoryButton.Click += new System.EventHandler(this.archiveChooseDirectoryButton_Click);
            // 
            // archiveChooseDirectoryTextBox
            // 
            this.archiveChooseDirectoryTextBox.Location = new System.Drawing.Point(37, 102);
            this.archiveChooseDirectoryTextBox.Name = "archiveChooseDirectoryTextBox";
            this.archiveChooseDirectoryTextBox.Size = new System.Drawing.Size(301, 22);
            this.archiveChooseDirectoryTextBox.TabIndex = 3;
            // 
            // archiveButton
            // 
            this.archiveButton.Location = new System.Drawing.Point(37, 184);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(75, 23);
            this.archiveButton.TabIndex = 4;
            this.archiveButton.Text = "Archive";
            this.archiveButton.UseVisualStyleBackColor = true;
            this.archiveButton.Click += new System.EventHandler(this.archiveButton_Click);
            // 
            // unarchiveChooseFileButton
            // 
            this.unarchiveChooseFileButton.Location = new System.Drawing.Point(389, 30);
            this.unarchiveChooseFileButton.Name = "unarchiveChooseFileButton";
            this.unarchiveChooseFileButton.Size = new System.Drawing.Size(132, 23);
            this.unarchiveChooseFileButton.TabIndex = 0;
            this.unarchiveChooseFileButton.Text = "File to unarchive...";
            this.unarchiveChooseFileButton.UseVisualStyleBackColor = true;
            this.unarchiveChooseFileButton.Click += new System.EventHandler(this.unarchiveChooseFileButton_Click);
            // 
            // unarchiveChooseFileTextBox
            // 
            this.unarchiveChooseFileTextBox.Location = new System.Drawing.Point(39, 30);
            this.unarchiveChooseFileTextBox.Name = "unarchiveChooseFileTextBox";
            this.unarchiveChooseFileTextBox.Size = new System.Drawing.Size(314, 22);
            this.unarchiveChooseFileTextBox.TabIndex = 1;
            // 
            // unarchiveChooseDicTextBox
            // 
            this.unarchiveChooseDicTextBox.Location = new System.Drawing.Point(39, 75);
            this.unarchiveChooseDicTextBox.Name = "unarchiveChooseDicTextBox";
            this.unarchiveChooseDicTextBox.Size = new System.Drawing.Size(314, 22);
            this.unarchiveChooseDicTextBox.TabIndex = 1;
            // 
            // unarchiveChooseDicButton
            // 
            this.unarchiveChooseDicButton.Location = new System.Drawing.Point(389, 75);
            this.unarchiveChooseDicButton.Name = "unarchiveChooseDicButton";
            this.unarchiveChooseDicButton.Size = new System.Drawing.Size(132, 23);
            this.unarchiveChooseDicButton.TabIndex = 0;
            this.unarchiveChooseDicButton.Text = "Dictionary...";
            this.unarchiveChooseDicButton.UseVisualStyleBackColor = true;
            this.unarchiveChooseDicButton.Click += new System.EventHandler(this.unarchiveChooseDicButton_Click);
            // 
            // unarchiveChooseDirectoryTextBox
            // 
            this.unarchiveChooseDirectoryTextBox.Location = new System.Drawing.Point(39, 130);
            this.unarchiveChooseDirectoryTextBox.Name = "unarchiveChooseDirectoryTextBox";
            this.unarchiveChooseDirectoryTextBox.Size = new System.Drawing.Size(314, 22);
            this.unarchiveChooseDirectoryTextBox.TabIndex = 2;
            // 
            // unarchiveChooseDirectoryButton
            // 
            this.unarchiveChooseDirectoryButton.Location = new System.Drawing.Point(389, 129);
            this.unarchiveChooseDirectoryButton.Name = "unarchiveChooseDirectoryButton";
            this.unarchiveChooseDirectoryButton.Size = new System.Drawing.Size(132, 23);
            this.unarchiveChooseDirectoryButton.TabIndex = 0;
            this.unarchiveChooseDirectoryButton.Text = "Directory to save...";
            this.unarchiveChooseDirectoryButton.UseVisualStyleBackColor = true;
            this.unarchiveChooseDirectoryButton.Click += new System.EventHandler(this.unarchiveChooseDirectoryButton_Click);
            // 
            // unarchiveButton
            // 
            this.unarchiveButton.Location = new System.Drawing.Point(39, 192);
            this.unarchiveButton.Name = "unarchiveButton";
            this.unarchiveButton.Size = new System.Drawing.Size(100, 23);
            this.unarchiveButton.TabIndex = 0;
            this.unarchiveButton.Text = "Unarchive";
            this.unarchiveButton.UseVisualStyleBackColor = true;
            this.unarchiveButton.Click += new System.EventHandler(this.unarchiveButton_Click);
            // 
            // ZipperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 275);
            this.Controls.Add(this.tabControl);
            this.Name = "ZipperForm";
            this.Text = "Zipper";
            this.Load += new System.EventHandler(this.ZipperForm_Load);
            this.tabControl.ResumeLayout(false);
            this.archiveTabPage.ResumeLayout(false);
            this.archiveTabPage.PerformLayout();
            this.unarchiveTabPage.ResumeLayout(false);
            this.unarchiveTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage archiveTabPage;
        private System.Windows.Forms.TabPage unarchiveTabPage;
        private System.Windows.Forms.Button archiveChooseFileButton;
        private System.Windows.Forms.TextBox archiveChooseFileTextBox;
        private System.Windows.Forms.TextBox archiveChooseDirectoryTextBox;
        private System.Windows.Forms.Button archiveChooseDirectoryButton;
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.TextBox unarchiveChooseDirectoryTextBox;
        private System.Windows.Forms.TextBox unarchiveChooseDicTextBox;
        private System.Windows.Forms.TextBox unarchiveChooseFileTextBox;
        private System.Windows.Forms.Button unarchiveButton;
        private System.Windows.Forms.Button unarchiveChooseDirectoryButton;
        private System.Windows.Forms.Button unarchiveChooseDicButton;
        private System.Windows.Forms.Button unarchiveChooseFileButton;
    }
}

