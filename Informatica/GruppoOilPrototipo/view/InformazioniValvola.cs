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
            Serial_valv Ser = new Serial_valv(CMB_NumSer.Text);

            Inf_misurazioni Inf = new Inf_misurazioni();
            form1.webMenager.inf_misurazioni = Inf;
            form1.webMenager.Codice_seriale = Ser;
                this.Hide();
                form1.Show();
                this.Close();
         
        }

        private async void InformazioniValvola_Load(object sender, EventArgs e)
        {
            Serial_valv.avviaClient();
           List<string> SerNum= await Serial_valv.POP_SER();
            PopolaCmb(SerNum);   
           
        }
        public void PopolaCmb(List<string> SerNum)
        {
            foreach(string s in SerNum)
            {
                CMB_NumSer.Items.Add(s);
            }
            CMB_NumSer.SelectedIndex=1;
        }
        
        private void InformazioniValvola_FormClosing()
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CMB_NumSer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
