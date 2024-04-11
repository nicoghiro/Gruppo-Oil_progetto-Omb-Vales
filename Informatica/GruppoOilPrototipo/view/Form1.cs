using GruppoOilPrototipo.model;
using GruppoOilPrototipo.view;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GruppoOilPrototipo
{
    public partial class Form1 : Form
    {
        WebMenager webMenager = new WebMenager();
        ArduinoReader ar;
        Misurazioni mis = new Misurazioni();
        FileMenager fm;
        bool misurazioneAttiva;
      
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SettingsMenager sm = new SettingsMenager();
            ar =new ArduinoReader(this);
            fm = ar.getFileMenager();
            misurazioneAttiva = false;
            terminaButton.Enabled = false;
            dataGridView1.Columns.Add("p1", "Angolo");
            dataGridView1.Columns.Add("p2", "Coppia");
            dataGridView1.Columns.Add("om", "Ora misurazione");
            dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            SettingsMenager.Form = this;
            VisualizzaImpostazioni();
            OperatingSystem os = Environment.OSVersion;
            if (os.Platform == PlatformID.Unix)
            {
                apriCartellaButton.Hide();
            }
        }
        public void VisualizzaImpostazioni()
        {
            porta.Text ="Porta: " + SettingsMenager.Porta;
            misurazioni.Text = "Max misurazioni: " + SettingsMenager.MaxMisurazioni;
            id.Text = "ID: " + SettingsMenager.IDValvola;
            nome.Text = "Nome: " + SettingsMenager.NomeValvola;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!misurazioneAttiva)
            {
                dataGridView1.Rows.Clear();
            }
            
            //try
           // {
                InformazioniValvola inf = new InformazioniValvola(this);
                inf.ShowDialog();
                Start();
           // }

           /* catch (Exception ex)
            {
                fm.StopMisurazione();
                MessageBox.Show(ex.Message);
            }*/
            


        }
        public void Start()
        {
            ar.inzio();
            dataGridView1.Columns["p1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["p2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            misurazioneAttiva = true;
            avviaButton.Enabled = false;
            terminaButton.Enabled = true;
            opzioni.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
            
        }
        public void Stop()
        {
            ar.fine();
            
            misurazioneAttiva = false;
            avviaButton.Enabled = true;
            terminaButton.Enabled = false;
            opzioni.Enabled = true;
        }
        public void OttieniMisurazione(string content)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        
                        dataGridView1.Rows.Insert(0, content.Split(';'));
                        mis.Agg_mis(content);
                    }));
                    return;
                }
            } catch(Exception ex)
            {
                fm.StopMisurazione();
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start($@"{AppDomain.CurrentDomain.BaseDirectory}Misurazioni");
        }

        private void portaComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortaCom p = new PortaCom();
            p.Show();
        }

        private void mAXMisurazioniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MAXmisurazioni max = new MAXmisurazioni();
            max.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void terminaButton_Click(object sender, EventArgs e)
        {
            try
            {
                Stop();
               Uri destination= await webMenager.Invio_Dati(webMenager);
            }
            catch (Exception ex)
            {
                fm.StopMisurazione();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
