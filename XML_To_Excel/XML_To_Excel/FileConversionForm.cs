using System;
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
            CreateExcelDocument(xmlDoc);
        }

        private static void CreateExcelDocument(XmlDocument xmlDoc)
        {
            ExcelPackage.License.SetNonCommercialOrganization("NDOT Noncommercial organization");

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

                foreach (XmlNode node in childNodes)
                {
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        if (row == 2)
                        {
                            var tempRow = row - 1;
                            worksheet.Cells[tempRow, column].Value = attr.Name;
                            worksheet.Cells[row, column].Value = UnescapeXMLValue(attr.Value);
                        }
                        else
                        {
                            worksheet.Cells[row, column].Value = UnescapeXMLValue(attr.Value);
                        }
                        column++;
                    }
                    column = 1;
                    row++;
                }

                // Save the Excel file
                var filePath = $"C:\\Users\\alexander.munger\\Documents\\Consultant Cert Update Docs\\Workview Exports\\{parentNode.Name}.xlsx";
                File.WriteAllBytes(filePath, package.GetAsByteArray());

                MessageBox.Show($"Excel file created at {filePath}");
            }

        }

        #region Helper Methods

        private static string EscapeXMLValue(string xmlString)
        {

            if (xmlString == null)
                throw new ArgumentNullException("xmlString");

            return xmlString.Replace("&", "&amp;");//.Replace("'", "&apos;").Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
        }

        private static string UnescapeXMLValue(string xmlString)
        {
            if (xmlString == null)
                throw new ArgumentNullException("xmlString");


            return xmlString.Replace("&amp;", "&"); //.Replace("&quot;", "\"").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&apos;", "'");
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

        #endregion


    }
}
