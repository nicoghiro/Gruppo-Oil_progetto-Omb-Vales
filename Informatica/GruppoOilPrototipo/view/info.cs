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
    public partial class info : Form
    {

        static private Form1 _form;
        public static Form1 Form
        {
            get { return _form; }
            set
            {
                if (value != null)
                {
                    _form = value;
                }
            }
        }
        public info()
        {
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {
         Nome.Text=SettingsMenager.Nome;    
         Id.Text=SettingsMenager.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsMenager sm=new SettingsMenager();
            sm.SetNome(Nome.Text);
            sm.SetId(Id.Text);
            Form.Inizio();
            this.Close();
        }
    }
}
