using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace csharp_serial
{
    public class ArduinoReader
    {
        SerialPortReader Reader;
        bool state = false;
        //false lettura in pausa , true lettura attiva
        public ArduinoReader(DataMenager data)
        {
            Reader = new SerialPortReader(data);
        }   
        public void inzio()
        {
            Reader.start();
        }
        public void fine()
        {
            Reader.stop();
        }
    }

   
}
