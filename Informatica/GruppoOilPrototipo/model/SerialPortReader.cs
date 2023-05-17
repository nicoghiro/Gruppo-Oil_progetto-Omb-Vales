using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private Form1 form;
        // Create the serial port with basic settings 
        private SerialPort port;
        public FileMenager Data
        {
            get { return data; }
            private set { data = value; }
        }
        public SerialPortReader(Form1 form)
        {
            this.form = form;
            Data = new FileMenager(form);
            port = new SerialPort(ScegliPorta(), 9600, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        public void start()
        {
            
            Data.AvviaMisurazione();
            port.Open();

        }
        public void stop()
        {
            
            port.Close();
            Data.FineMisurazione();

        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Get and Show a received line (all characters up to a serial New Line character)
            string line = port.ReadLine();
            if (line != null)
            {
                Data.Input(line);
            }

        }
        public string ScegliPorta()
        {
            string fileName = "porta.config"; // inserisci qui il nome del file
            string folderName = "Impostazioni"; // inserisci qui il nome della cartella
            string filePath = Path.Combine(Application.StartupPath, folderName, fileName);
            StreamReader sw = new StreamReader(filePath);
            string port = sw.ReadLine();
            sw.Close();
            if (String.IsNullOrEmpty(port))
            {
                port = "5";
            }
            port = port.Trim();
            port = port.Substring(port.Length - 1);

            return port;
        }
    }
}
