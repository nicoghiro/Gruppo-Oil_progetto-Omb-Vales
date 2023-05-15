using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppoOilPrototipo
{
    public class ArduinoReader
    {
        SerialPortReader Reader;
        //false lettura in pausa , true lettura attiva
        public ArduinoReader(Form1 form)
        {
            Reader = new SerialPortReader(form);
        }
        public FileMenager getFileMenager()
        {
            if (Reader != null)
            {
                return Reader.Data;
            } else
            {
                throw new Exception("classe non istanziata");
            }
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
