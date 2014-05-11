using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminarska
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            lblScore.Text = Bumper.poeni + " pts";
            
        }

       
        private void pbTryAgain2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

        private void pbQuit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



    }
}
