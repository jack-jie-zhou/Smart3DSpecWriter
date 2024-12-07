using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Forms
{
    public partial class DisplayIconForm : Form
    {
        public DisplayIconForm()
        {
            InitializeComponent();
        }

        public string FileName { get; internal set; }

        private void pb1_Click(object sender, EventArgs e)
        {

        }

        private void DisplayIconForm_Load(object sender, EventArgs e)
        {
            pb1.Image = Image.FromFile(FileName);
        }
    }
}
