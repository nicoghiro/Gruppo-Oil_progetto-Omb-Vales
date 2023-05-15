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
            textBox1.Text = ScegliPorta();
        }

        private void PortaCom_Load(object sender, EventArgs e)
        {

        }
        private string ScegliPorta()
        {
            string fileName = "porta.txt"; // inserisci qui il nome del file
            string folderName = "porta"; // inserisci qui il nome della cartella
            string filePath = Path.Combine(Application.StartupPath, folderName, fileName);
            StreamReader sw = new StreamReader(filePath);
            string port = sw.ReadLine();
            sw.Close();
            port = port.Trim();
            port = port.ToUpper();
            string test = port.Substring(0, port.Length - 1);
            if (test != "COM")
            {
                throw new Exception("inserire porta valida");
            }
            else
            {
                return port;
            }
        }
        private string CambiaPorta()
        {
            string fileName = "porta.txt"; // inserisci qui il nome del file
            string folderName = "porta"; // inserisci qui il nome della cartella
            string filePath = Path.Combine(Application.StartupPath, folderName, fileName);
            StreamReader sw = new StreamReader(filePath);
            StreamWriter sr= new StreamWriter(filePath);
            
            string port = sw.ReadLine();
            sw.Close();
            port = port.Trim();
            port = port.ToUpper();
            string test = port.Substring(0, port.Length - 1);
            if (test != "COM")
            {
                throw new Exception("inserire porta valida");
            }
            else
            {
                return port;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
