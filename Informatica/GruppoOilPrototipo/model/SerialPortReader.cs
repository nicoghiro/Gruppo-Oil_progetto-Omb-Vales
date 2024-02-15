using GruppoOilPrototipo.view;
using System;
using System.IO.Ports;
using System.Threading;

namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private Form1 form;
        private SerialPort port;
        private Thread closeDownThread;

        public FileMenager Data
        {
            get { return data; }
            private set { data = value; }
        }

        public SerialPortReader(Form1 form)
        {
            this.form = form;
            Data = new FileMenager(form);
            port = new SerialPort(SettingsMenager.Porta, 9600, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public void start()
        {
            port.PortName = SettingsMenager.Porta;
            Data.AvviaMisurazione();
            port.Open();
            Console.WriteLine("Avvio riuscito");
        }

        public void stop()
        {
            closeDownThread = new Thread(CloseSerialOnExit);
            closeDownThread.Start();
            Console.WriteLine("Misurazione terminata");
            Data.FineMisurazione();
        }

        private void CloseSerialOnExit()
        {
            try
            {
                port.Close(); //close the serial port
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //catch any serial port closing error messages
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string line = port.ReadLine();
            if (line != null)
            {
                Data.Input(line);
                Console.WriteLine(line); // Log the received data
            }
        }
    }
}
