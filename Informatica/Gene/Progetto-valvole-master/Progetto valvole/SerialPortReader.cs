using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private FileMenager Data
        {
            get { return data; }
            set { data= value; }
        }
        public SerialPortReader()
        {
            Data = new FileMenager();
            port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
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
    }
}
