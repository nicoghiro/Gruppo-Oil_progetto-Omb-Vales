using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace GruppoOilPrototipo
{
    public class FileMenager
    {
        private string _nomeFile;
        private int _numeroMisurazioni;
        private string _nomeFoglio;
        public Excel.Application app;
        private Workbooks wbs;
        private Workbook wb;
        private Worksheet ws;
        private bool misurazioneAttiva;
        private Form1 form;
        public int NumeroMisurazioni
        {
            get { return _numeroMisurazioni; }
            private set { _numeroMisurazioni = value; }
        }
        public FileMenager(Form1 form)
        {
            
            this.form = form;
            
        }
        private void nuovoFile()
        {
            string dataFile = "";
            string[] tmp = DateTime.Now.ToString().Split(' ')[0].Split('/');
            dataFile = $"{tmp[0]}_{tmp[1]}_{tmp[2]}_";
            tmp = DateTime.Now.ToString().Split(' ')[1].Split(':');
            dataFile += $"{tmp[0]}.{tmp[1]}.{tmp[2]}";
            _nomeFile = "misurazioni" + dataFile + ".xlsx";
            _nomeFoglio = "Foglio1";
        }
        public void AvviaMisurazione()
        {
            if (!misurazioneAttiva)
            {
                    nuovoFile();
                    app = new Excel.Application();
                    NumeroMisurazioni = 1;
                    app.DisplayAlerts = false;
                    app.SheetsInNewWorkbook = 1;
                    object missing = System.Reflection.Missing.Value;
                    wbs = app.Workbooks;
                    wb = wbs.Add(missing);
                    ws = (Excel.Worksheet)(wb.Worksheets[1]);
                    ws.Name = _nomeFoglio;
                    misurazioneAttiva = true;
            }
            else throw new Exception("Misurazione già in corso");
        }
        public void Input(string line)
        {
            if (line != null)
            {
                scriviAppend(_nomeFile, line);
                NumeroMisurazioni++;
            }
            else { throw new Exception("Valore nullo"); }
        }
        private void scriviAppend(string filename, string content)
        {

            if (app != null)
            {
                try
                {
                    string orarioMisurazione = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "," + DateTime.Now.Millisecond.ToString();
                    ws.Cells[NumeroMisurazioni, "A"] = content.Split(';')[0];
                    ws.Cells[NumeroMisurazioni, "B"] = content.Split(';')[1];
                    ws.Cells[NumeroMisurazioni, "C"] = orarioMisurazione;
                    content+= ";" + orarioMisurazione + ";";
                    form.OttieniMisurazione(content);
                }
                catch (Exception ex)
                {
                    ws.Cells[NumeroMisurazioni, "A"] = "Errore nella misurazione";
                }
                wb.SaveAs($@"{AppDomain.CurrentDomain.BaseDirectory}Misurazioni\{_nomeFile}");
            }
            else throw new Exception("Misurazione non attiva");
        }
        public void FineMisurazione()
        {
           // if (misurazioneAttiva== true)
            //{
                wb.Save();
                wb.Close();
                wbs.Close();
                app.Application.Quit();
                app.Quit();
            Marshal.ReleaseComObject(wb);
            Marshal.ReleaseComObject(wbs);
            Marshal.ReleaseComObject(app);
            misurazioneAttiva = false;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            //} else
            //{
                //throw new Exception("Misurazione non avviata");
          //  }
            
        }
    }
}
