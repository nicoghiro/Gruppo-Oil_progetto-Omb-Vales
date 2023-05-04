using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        public FileMenager Data
        {
            get { return data; }
            private set { data = value; }
        }
        public SerialPortReader(Form1 form)
        {
            Data = new FileMenager(form);
            port = new SerialPort(ScegliPorta(), 9600, Parity.None, 8, StopBits.One);
        }



        // Create the serial port with basic settings 
        private SerialPort port;
        public void start()

        {
            Data.AvviaMisurazione();
            //set the event handler
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            // Begin communications 
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
        private string ScegliPorta()
        {
            
        }
    }
}
