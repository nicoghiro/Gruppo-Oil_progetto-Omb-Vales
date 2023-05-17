using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GruppoOilPrototipo.view
{
    public partial class MAXmisurazioni : Form
    {

        private SettingsMenager sm;
       
        public MAXmisurazioni()
        {
            InitializeComponent();
        }

        private void MAXmisurazioni_Load(object sender, EventArgs e)
        {
            sm = new SettingsMenager();
            numericUpDown1.Value = (decimal)sm.MaxMisurazioni;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sm.SetMax((int)numericUpDown1.Value);
        }
    }
}
