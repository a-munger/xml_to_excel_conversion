using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace XML_To_Excel
{
    public partial class FileConversionForm : Form
    {
        private Timer timer;

        public FileConversionForm()
        {
            InitializeComponent();
        }

        private void uploadXmlBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openXmlFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                xmlFileName.Text = openXmlFile.FileName;
                //Do whatever you want
                //openFileDialog1.FileName .....
            }
        }

        private void uploadExcelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openExcelFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                xmlFileName.Text = openExcelFile.FileName;
                //Do whatever you want
                //openFileDialog1.FileName .....
            }

        }

        private void validateXmlBtn_Click(object sender, EventArgs e)
        {

            if (xmlFileName.Text == "" || xmlFileName.Text == null)
            {
                Label failLabel = new Label
                {
                    Text = "Please upload an XML file to validate.",
                    Location = new Point(97, 80),
                    AutoSize = true,
                    ForeColor = Color.Red
                };

                xmlToExcelGroup.Controls.Add(failLabel);

                timer = new Timer
                {
                    Interval = 3000 // Display the label for 3 seconds
                };
                timer.Tick += (s, args) =>
                {
                    // Remove the label and stop the timer
                    xmlToExcelGroup.Controls.Remove(failLabel);
                    failLabel.Dispose();
                    timer.Stop();
                    timer.Dispose();
                };
                // Start the timer
                timer.Start();

                return;
            }

            StringBuilder sb = new StringBuilder();

            string rawXml = File.ReadAllText(xmlFileName.Text);
            rawXml = rawXml.TrimStart('\uFEFF').Trim();

            // Escape invalid XML characters
            string sanitizedXml = EscapeXMLValue(rawXml);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(sanitizedXml));

            CreateExcelDocument(xmlDoc);

            bool isValid = true;

            if (isValid)
            {
                Label successLabel = new Label
                {
                    Text = "VALID!",
                    Location = new Point(97, 80),
                    AutoSize = true,
                    ForeColor = Color.Green
                };

                xmlToExcelGroup.Controls.Add(successLabel);

                timer = new Timer
                {
                    Interval = 3000 // Display the label for 3 seconds
                };
                timer.Tick += (s, args) =>
                {
                    // Remove the label and stop the timer
                    xmlToExcelGroup.Controls.Remove(successLabel);
                    successLabel.Dispose();
                    timer.Stop();
                    timer.Dispose();
                };
                // Start the timer
                timer.Start();
            }
        }

        public static string EscapeXMLValue(string xmlString)
        {

            if (xmlString == null)
                throw new ArgumentNullException("xmlString");

            return xmlString.Replace("&", "&amp;");//.Replace("'", "&apos;").Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
        }

        public static string UnescapeXMLValue(string xmlString)
        {
            if (xmlString == null)
                throw new ArgumentNullException("xmlString");


            return xmlString.Replace("&apos;", "'").Replace("&quot;", "\"").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
        }

        public static void CreateExcelDocument(XmlDocument xmlDoc)
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a worksheet
                var worksheet = package.Workbook.Worksheets.Add(xmlDoc.DocumentElement.Name);

                XmlNodeList childNodes = xmlDoc.DocumentElement.ChildNodes;

                int column = 1;
                int row = 2;
                string cellValue = string.Empty;

                foreach (XmlNode node in childNodes)
                {
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        if (row == 2)
                        {
                            var tempRow = row - 1;
                            worksheet.Cells[tempRow, column].Value = attr.Name;
                            worksheet.Cells[row, column].Value = attr.Value;
                        }
                        else
                        {
                            worksheet.Cells[row, column].Value = attr.Value;
                        }
                        column++;
                    }
                    column = 1;
                    row++;
                }

                // Save the Excel file
                var filePath = $"C:\\Users\\alexander.munger\\Documents\\Consultant Cert Update Docs\\Workview Exports\\{xmlDoc.DocumentElement.Name}.xlsx";
                File.WriteAllBytes(filePath, package.GetAsByteArray());

                MessageBox.Show($"Excel file created at {filePath}");
            }

        }
    }
}
