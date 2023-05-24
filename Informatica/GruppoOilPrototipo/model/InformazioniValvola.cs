using GruppoOilPrototipo.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GruppoOilPrototipo.model
{
    public partial class InformazioniValvola : Form
    {
        private Form1 form1;
        public InformazioniValvola(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = idText.Text;
            string nome = nomeText.Text;
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(nome))
            {
                SettingsMenager sm = new SettingsMenager();
                sm.SetInfo(id, nome);
                this.Hide();
                form1.Show();
                this.Close();
            }
            else MessageBox.Show("Nome o ID non validi");
        }

        private void InformazioniValvola_Load(object sender, EventArgs e)
        {

        }
        
        private void InformazioniValvola_FormClosing()
        {

        }
    }
}
