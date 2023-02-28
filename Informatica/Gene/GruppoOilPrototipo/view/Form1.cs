using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ar=new ArduinoReader(this);
            fm = ar.getFileMenager();
            
            dataGridView1.Columns.Add("p1", "Potenziometro 1");
            dataGridView1.Columns.Add("p2", "Potenziometro 2");
            dataGridView1.Columns.Add("om", "Ora misurazione");
            dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                ar.inzio();
                dataGridView1.Columns["p1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns["p2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns["om"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ar.fine();
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
    }
}
