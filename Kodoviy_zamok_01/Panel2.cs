using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kodoviy_zamok_01
{
    public partial class Panel2 : Form
    {
        public Panel2()
        {
            InitializeComponent();
            this.Show();
        }
        Panel1 form = new Panel1();
        public void Open_button_Click(object sender, EventArgs e)
        {
            if(form.richTextBox_Display.Text == "Locked" && form.timer1.Enabled==false)
            {
                form.Open_lock();
            }
        }
    }
}
