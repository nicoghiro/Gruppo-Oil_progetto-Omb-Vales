using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GruppoOilPrototipo.view
{
    public partial class PortaCom : Form
    {
        
        public PortaCom()
        {
            InitializeComponent();
            
        }

        private void PortaCom_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)int.Parse(SettingsMenager.Porta.Substring(SettingsMenager.Porta.Length-1));
        }
        
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsMenager st=new SettingsMenager();
            st.SetPorta(numericUpDown1.Value);
        }
    }
}
