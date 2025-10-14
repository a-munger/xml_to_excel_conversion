namespace XML_To_Excel
{
    partial class FileConversionForm
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
            this.openXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.excelFileName = new System.Windows.Forms.TextBox();
            this.openExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.excelToXmlGroup = new System.Windows.Forms.GroupBox();
            this.uploadExcelBtn = new System.Windows.Forms.Button();
            this.conversionTabControl = new System.Windows.Forms.TabControl();
            this.xmlTabPage = new System.Windows.Forms.TabPage();
            this.xmlToExcelGroup = new System.Windows.Forms.GroupBox();
            this.validateXmlBtn = new System.Windows.Forms.Button();
            this.xmlFileName = new System.Windows.Forms.TextBox();
            this.uploadXmlBtn = new System.Windows.Forms.Button();
            this.excelTabPage = new System.Windows.Forms.TabPage();
            this.excelToXmlGroup.SuspendLayout();
            this.conversionTabControl.SuspendLayout();
            this.xmlTabPage.SuspendLayout();
            this.xmlToExcelGroup.SuspendLayout();
            this.excelTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // openXmlFile
            // 
            this.openXmlFile.FileName = "xmlFile";
            // 
            // excelFileName
            // 
            this.excelFileName.Location = new System.Drawing.Point(6, 49);
            this.excelFileName.Name = "excelFileName";
            this.excelFileName.Size = new System.Drawing.Size(431, 22);
            this.excelFileName.TabIndex = 5;
            // 
            // openExcelFile
            // 
            this.openExcelFile.FileName = "excelFile";
            // 
            // excelToXmlGroup
            // 
            this.excelToXmlGroup.Controls.Add(this.uploadExcelBtn);
            this.excelToXmlGroup.Controls.Add(this.excelFileName);
            this.excelToXmlGroup.Location = new System.Drawing.Point(6, 20);
            this.excelToXmlGroup.Name = "excelToXmlGroup";
            this.excelToXmlGroup.Size = new System.Drawing.Size(660, 100);
            this.excelToXmlGroup.TabIndex = 5;
            this.excelToXmlGroup.TabStop = false;
            this.excelToXmlGroup.Text = "Excel To XML";
            // 
            // uploadExcelBtn
            // 
            this.uploadExcelBtn.Location = new System.Drawing.Point(443, 48);
            this.uploadExcelBtn.Name = "uploadExcelBtn";
            this.uploadExcelBtn.Size = new System.Drawing.Size(123, 23);
            this.uploadExcelBtn.TabIndex = 6;
            this.uploadExcelBtn.Text = "Upload Excel";
            this.uploadExcelBtn.UseVisualStyleBackColor = true;
            this.uploadExcelBtn.Click += new System.EventHandler(this.uploadExcelBtn_Click);
            // 
            // conversionTabControl
            // 
            this.conversionTabControl.Controls.Add(this.xmlTabPage);
            this.conversionTabControl.Controls.Add(this.excelTabPage);
            this.conversionTabControl.Location = new System.Drawing.Point(12, 12);
            this.conversionTabControl.Name = "conversionTabControl";
            this.conversionTabControl.SelectedIndex = 0;
            this.conversionTabControl.Size = new System.Drawing.Size(820, 462);
            this.conversionTabControl.TabIndex = 5;
            // 
            // xmlTabPage
            // 
            this.xmlTabPage.Controls.Add(this.xmlToExcelGroup);
            this.xmlTabPage.Location = new System.Drawing.Point(4, 25);
            this.xmlTabPage.Name = "xmlTabPage";
            this.xmlTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.xmlTabPage.Size = new System.Drawing.Size(812, 433);
            this.xmlTabPage.TabIndex = 0;
            this.xmlTabPage.Text = "XML To Excel";
            this.xmlTabPage.UseVisualStyleBackColor = true;
            // 
            // xmlToExcelGroup
            // 
            this.xmlToExcelGroup.Controls.Add(this.validateXmlBtn);
            this.xmlToExcelGroup.Controls.Add(this.xmlFileName);
            this.xmlToExcelGroup.Controls.Add(this.uploadXmlBtn);
            this.xmlToExcelGroup.Location = new System.Drawing.Point(21, 31);
            this.xmlToExcelGroup.Name = "xmlToExcelGroup";
            this.xmlToExcelGroup.Size = new System.Drawing.Size(660, 149);
            this.xmlToExcelGroup.TabIndex = 4;
            this.xmlToExcelGroup.TabStop = false;
            this.xmlToExcelGroup.Text = "XML To Excel";
            // 
            // validateXmlBtn
            // 
            this.validateXmlBtn.Location = new System.Drawing.Point(6, 95);
            this.validateXmlBtn.Name = "validateXmlBtn";
            this.validateXmlBtn.Size = new System.Drawing.Size(110, 23);
            this.validateXmlBtn.TabIndex = 2;
            this.validateXmlBtn.Text = "Validate XML";
            this.validateXmlBtn.UseVisualStyleBackColor = true;
            this.validateXmlBtn.Click += new System.EventHandler(this.validateXmlBtn_Click);
            // 
            // xmlFileName
            // 
            this.xmlFileName.Location = new System.Drawing.Point(6, 44);
            this.xmlFileName.Name = "xmlFileName";
            this.xmlFileName.Size = new System.Drawing.Size(431, 22);
            this.xmlFileName.TabIndex = 1;
            // 
            // uploadXmlBtn
            // 
            this.uploadXmlBtn.Location = new System.Drawing.Point(443, 44);
            this.uploadXmlBtn.Name = "uploadXmlBtn";
            this.uploadXmlBtn.Size = new System.Drawing.Size(123, 23);
            this.uploadXmlBtn.TabIndex = 0;
            this.uploadXmlBtn.Text = "Upload XML";
            this.uploadXmlBtn.UseVisualStyleBackColor = true;
            this.uploadXmlBtn.Click += new System.EventHandler(this.uploadXmlBtn_Click);
            // 
            // excelTabPage
            // 
            this.excelTabPage.Controls.Add(this.excelToXmlGroup);
            this.excelTabPage.Location = new System.Drawing.Point(4, 25);
            this.excelTabPage.Name = "excelTabPage";
            this.excelTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.excelTabPage.Size = new System.Drawing.Size(812, 433);
            this.excelTabPage.TabIndex = 1;
            this.excelTabPage.Text = "Excel To XML";
            this.excelTabPage.UseVisualStyleBackColor = true;
            // 
            // FileConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 502);
            this.Controls.Add(this.conversionTabControl);
            this.Name = "FileConversionForm";
            this.Text = "XML and Excel File Conversion";
            this.excelToXmlGroup.ResumeLayout(false);
            this.excelToXmlGroup.PerformLayout();
            this.conversionTabControl.ResumeLayout(false);
            this.xmlTabPage.ResumeLayout(false);
            this.xmlToExcelGroup.ResumeLayout(false);
            this.xmlToExcelGroup.PerformLayout();
            this.excelTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button uploadExcelBtn;
        private System.Windows.Forms.OpenFileDialog openXmlFile;
        private System.Windows.Forms.OpenFileDialog openExcelFile;
        private System.Windows.Forms.TextBox excelFileName;
        private System.Windows.Forms.GroupBox excelToXmlGroup;
        private System.Windows.Forms.TabControl conversionTabControl;
        private System.Windows.Forms.TabPage xmlTabPage;
        private System.Windows.Forms.TabPage excelTabPage;
        private System.Windows.Forms.GroupBox xmlToExcelGroup;
        private System.Windows.Forms.Button validateXmlBtn;
        private System.Windows.Forms.TextBox xmlFileName;
        private System.Windows.Forms.Button uploadXmlBtn;
    }
}

