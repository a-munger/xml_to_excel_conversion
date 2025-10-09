using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_To_Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openXmlFile.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                xmlFileName.Text = openXmlFile.FileName;
                //Do whatever you want
                //openFileDialog1.FileName .....
            }
        }
    }
}
