using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using OfficeOpenXml;

namespace XML_To_Excel
{
    public partial class FileConversionForm : Form
    {
        private Timer timer;
        private Control label;
        private XmlDocument xmlDoc;
        private XmlDocument xmlTemplateDoc;

        public FileConversionForm()
        {
            InitializeComponent();
            saveExcelBtn.Enabled = false;
        }

        #region Form Controls
        private void uploadXmlBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openXmlFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                xmlFileName.Text = openXmlFile.FileName;
            }
        }

        private void uploadExcelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openExcelFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                xmlFileName.Text = openExcelFile.FileName;
            }

        }

        private void uploadTemplateBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openTemplateFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                templateFileName.Text = openTemplateFile.FileName;
            }
        }

        #endregion

        private void validateXmlBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (xmlFileName.Text == "" || xmlFileName.Text == null)
                {
                    DisplayValidationMessage(true, true);
                }
                else
                {
                    string rawXml = File.ReadAllText(xmlFileName.Text);
                    rawXml = rawXml.TrimStart('\uFEFF').Trim();

                    // Escape invalid XML characters
                    string sanitizedXml = EscapeXMLValue(rawXml);

                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(new StringReader(sanitizedXml));

                    DisplayValidationMessage(true);

                    saveExcelBtn.Enabled = true;
                }

            }
            catch(Exception ex)
            {
                DisplayValidationMessage(false);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void saveExcelBtn_Click(object sender, EventArgs e)
        {
            saveExceFile.Filter = "Excel Files| *.xlsx";
            DialogResult result = saveExceFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                CreateExcelDocument(xmlDoc, saveExceFile.FileName);
            }
        }

        private void CreateExcelDocument(XmlDocument xmlDoc, String fileName)
        {
            ExcelPackage.License.SetNonCommercialOrganization("NDOT Noncommercial organization");

            string[] columns = BuildColumnList();

            // Create a new Excel package
            using (ExcelPackage package = new ExcelPackage())
            {
                XmlNode parentNode = null;

                if (xmlDoc.DocumentElement.Name == "export")
                {
                    parentNode = xmlDoc.DocumentElement.ChildNodes.Item(0);
                }
                else
                {
                    parentNode = xmlDoc.DocumentElement;
                }

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(parentNode.Name);

                XmlNodeList childNodes = parentNode.ChildNodes;

                int column = 1;
                int row = 2;

                foreach(string name in columns)
                {
                    worksheet.Cells[1, column].Value = name;
                    column++;
                }

                column = 1;

                foreach (XmlNode node in childNodes)
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        worksheet.Cells[row, column].Value = UnescapeXMLValue(node.Attributes[columns[i]]?.Value);
                        column++;
                    }
                    column = 1;
                    row++;
                }

                // Save the Excel file
                File.WriteAllBytes(fileName, package.GetAsByteArray());

                MessageBox.Show($"Excel file created at {fileName}");
            }

        }

        #region Helper Methods

        private string EscapeXMLValue(string xmlString)
        {

            if (xmlString == null)
                throw new ArgumentNullException("xmlString");

            return xmlString.Replace("&", "&amp;");
        }

        private string UnescapeXMLValue(string xmlString)
        {
            if (xmlString == null)
                return "";


            return xmlString.Replace("&amp;", "&");
        }

        private void DisplayValidationMessage(bool isValid, bool missingFile = false)
        {
            if(missingFile)
            {
                label = new Label
                {
                    Text = "Please upload an XML file to validate.",
                    Location = new Point(99, 190),
                    AutoSize = true,
                    ForeColor = Color.Red
                };
            }
            else if(!isValid)
            {

                label = new Label
                {
                    Text = "INVALID XML!",
                    Location = new Point(99, 190),
                    AutoSize = true,
                    ForeColor = Color.Red
                };
            }
            else
            {
                label = new Label
                {
                    Text = "VALID!",
                    Location = new Point(99, 190),
                    AutoSize = true,
                    ForeColor = Color.Green
                };
            }

            xmlToExcelGroup.Controls.Add(label);

            timer = new Timer
            {
                Interval = 3000 // Display the label for 3 seconds
            };
            timer.Tick += (s, args) =>
            {
                // Remove the label and stop the timer
                xmlToExcelGroup.Controls.Remove(label);
                label.Dispose();
                timer.Stop();
                timer.Dispose();
            };
            // Start the timer
            timer.Start();
        }

        private string[] BuildColumnList()
        {
            List<string> columns = new List<string>();

            string rawXml = File.ReadAllText(templateFileName.Text);
            rawXml = rawXml.TrimStart('\uFEFF').Trim();

            // Escape invalid XML characters
            string sanitizedXml = EscapeXMLValue(rawXml);

            xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load(new StringReader(sanitizedXml));

            XmlNode root = xmlTemplateDoc.DocumentElement;

            XmlNodeList nodes = root.SelectNodes("//TransferTemplate/InstanceMappings/InstanceMapping/AttributeMappings/XPathAttributeMapping");

            columns.Add("source-id");

            foreach (XmlNode node in nodes)
            {
                columns.Add(node.Attributes[0].Value);
            }

            return columns.ToArray();
        }

        #endregion
    }
}
