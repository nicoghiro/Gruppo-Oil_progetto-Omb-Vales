using GruppoOilPrototipo.view;
using System;
using System.IO.Ports;
using System.Threading;
using SerialPortLib;
using System.Text;

namespace GruppoOilPrototipo
{
    public class SerialPortReader
    {
        private FileMenager data;
        private Form1 form;
        private SerialPortInput port;
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
            port = new SerialPortInput();
            port.SetPort(SettingsMenager.Porta,8000);
            port.MessageReceived += delegate (object sender, MessageReceivedEventArgs args)
            {
                string line= Encoding.UTF8.GetString(args.Data);
                if (line != null)
                {
                    Data.Input(line);
                    Console.WriteLine(line); // Log the received data
                }
            };
        }

        public void start()
        {
            Data.AvviaMisurazione();
            port.Connect();
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
                port.Disconnect(); //close the serial port
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //catch any serial port closing error messages
            }
        }

        private void port_DataReceived(object sender, SerialPortLib.MessageReceivedEventArgs e)
        {
            
        }
    }
}
