﻿using GruppoOilPrototipo.view;
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
        ArduinoReader ar;
        FileMenager fm;
        bool misurazioneAttiva;
      
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ar=new ArduinoReader(this);
            fm = ar.getFileMenager();
            misurazioneAttiva = false;
            dataGridView1.Columns.Add("p1", "Potenziometro 1");
            dataGridView1.Columns.Add("p2", "Potenziometro 2");
            dataGridView1.Columns.Add("om", "Ora misurazione");
            dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            SettingsMenager sm = new SettingsMenager();
            StreamReader sr = new StreamReader(sm.FilePathPorta);
            string line = sr.ReadLine();
            sr.Close();
            if (line != null)
            {
                sm.SetPorta((decimal)int.Parse(line.Substring(line.Length - 1)));
            }
            else sm.SetPorta(5);
            sr = new StreamReader(sm.FilePathMax);
            line = sr.ReadLine();
            sr.Close();
            if (line != null)
            {
                sm.SetMax(int.Parse(line));
            }
            else sm.SetMax(100);
            SettingsMenager.Form = this;
            VisualizzaImpostazioni();
        }
        public void VisualizzaImpostazioni()
        {
            porta.Text ="Porta: " + SettingsMenager.Porta;
            misurazioni.Text = "Max misurazioni: " + SettingsMenager.MaxMisurazioni;
            
        }

        void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (misurazioneAttiva)
            {
                
                ar.fine();
                ar.getFileMenager().app.Quit();
                misurazioneAttiva = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!misurazioneAttiva)
            {
                dataGridView1.Rows.Clear();
            }
            try
            {
                ar.inzio();
                dataGridView1.Columns["p1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns["p2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
                misurazioneAttiva=true;
                avviaButton.Enabled=false;
                terminaButton.Enabled = true;
                opzioni.Enabled=false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
                try
                {
                    ar.fine();
                    ar.getFileMenager().app.Quit();
                    misurazioneAttiva = false;
                    avviaButton.Enabled = true;
                    terminaButton.Enabled = false;
                    opzioni.Enabled = true;
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
            
            
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
                    }));
                    return;
                }
            } catch(Exception ex)
            {
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
    }
}
