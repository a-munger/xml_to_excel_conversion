namespace XML_To_Excel
{
    partial class Form1
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
            this.uploadBtn = new System.Windows.Forms.Button();
            this.xmlFileName = new System.Windows.Forms.TextBox();
            this.openXmlFile = new System.Windows.Forms.OpenFileDialog();
            this.xmlToExcelPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.xmlToExcel = new System.Windows.Forms.RadioButton();
            this.excelToXml = new System.Windows.Forms.RadioButton();
            this.xmlToExcelLabel = new System.Windows.Forms.Label();
            this.xmlToExcelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uploadBtn
            // 
            this.uploadBtn.Location = new System.Drawing.Point(440, 40);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(123, 23);
            this.uploadBtn.TabIndex = 0;
            this.uploadBtn.Text = "Upload XML";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // xmlFileName
            // 
            this.xmlFileName.Location = new System.Drawing.Point(3, 40);
            this.xmlFileName.Name = "xmlFileName";
            this.xmlFileName.Size = new System.Drawing.Size(431, 22);
            this.xmlFileName.TabIndex = 1;
            // 
            // openXmlFile
            // 
            this.openXmlFile.FileName = "xmlFile";
            // 
            // xmlToExcelPanel
            // 
            this.xmlToExcelPanel.Controls.Add(this.xmlToExcelLabel);
            this.xmlToExcelPanel.Controls.Add(this.xmlFileName);
            this.xmlToExcelPanel.Controls.Add(this.uploadBtn);
            this.xmlToExcelPanel.Location = new System.Drawing.Point(12, 56);
            this.xmlToExcelPanel.Name = "xmlToExcelPanel";
            this.xmlToExcelPanel.Size = new System.Drawing.Size(776, 148);
            this.xmlToExcelPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 286);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 152);
            this.panel2.TabIndex = 2;
            // 
            // xmlToExcel
            // 
            this.xmlToExcel.AutoSize = true;
            this.xmlToExcel.Location = new System.Drawing.Point(69, 12);
            this.xmlToExcel.Name = "xmlToExcel";
            this.xmlToExcel.Size = new System.Drawing.Size(110, 20);
            this.xmlToExcel.TabIndex = 3;
            this.xmlToExcel.TabStop = true;
            this.xmlToExcel.Text = "XML To Excel";
            this.xmlToExcel.UseVisualStyleBackColor = true;
            // 
            // excelToXml
            // 
            this.excelToXml.AutoSize = true;
            this.excelToXml.Location = new System.Drawing.Point(308, 12);
            this.excelToXml.Name = "excelToXml";
            this.excelToXml.Size = new System.Drawing.Size(110, 20);
            this.excelToXml.TabIndex = 4;
            this.excelToXml.TabStop = true;
            this.excelToXml.Text = "Excel To XML";
            this.excelToXml.UseVisualStyleBackColor = true;
            // 
            // xmlToExcelLabel
            // 
            this.xmlToExcelLabel.AutoSize = true;
            this.xmlToExcelLabel.Location = new System.Drawing.Point(17, 10);
            this.xmlToExcelLabel.Name = "xmlToExcelLabel";
            this.xmlToExcelLabel.Size = new System.Drawing.Size(111, 20);
            this.xmlToExcelLabel.TabIndex = 2;
            this.xmlToExcelLabel.Text = "XML To Excel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.excelToXml);
            this.Controls.Add(this.xmlToExcel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.xmlToExcelPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.xmlToExcelPanel.ResumeLayout(false);
            this.xmlToExcelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.TextBox xmlFileName;
        private System.Windows.Forms.OpenFileDialog openXmlFile;
        private System.Windows.Forms.Panel xmlToExcelPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton xmlToExcel;
        private System.Windows.Forms.RadioButton excelToXml;
        private System.Windows.Forms.Label xmlToExcelLabel;
    }
}

